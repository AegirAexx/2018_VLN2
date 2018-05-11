using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using BookCave.Models;
using System.Security.Authentication;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using Amazon.S3;
using BookCave.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BookCave.Controllers
{
    public class ManageController : Controller
    {
        IConfigurationRoot _config;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; 
        public string _imageBucket = "";
        IAmazonS3 _s3Client; 
        public ManageController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IAmazonS3 s3Client)
        {
            _config = Helpers.Config.Load();
            _signInManager = signInManager;
            _userManager = userManager;
            _s3Client = s3Client;
            _imageBucket = _config["Aws:S3:ImageBucket"];
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new IndexViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsEmailConfirmed = user.EmailConfirmed,
                StatusMessage = StatusMessage
            };
            
            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model, IFormFile ImageData)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new AuthenticationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new AuthenticationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new AuthenticationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            StatusMessage = "Your profile has been updated";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }

            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new AuthenticationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Your password has been changed.";

            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new AuthenticationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            var model = new SetPasswordViewModel { StatusMessage = StatusMessage };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await _userManager.AddPasswordAsync(user, model.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                AddErrors(addPasswordResult);
                return View(model);
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            StatusMessage = "Your password has been set.";

            return RedirectToAction(nameof(SetPassword));
        }

        [Authorize]
        [HttpGet]
         public async Task<IActionResult> EditProfile()
        {
            S3Helper s3Helper = new S3Helper(_s3Client);

            var user = await _userManager.GetUserAsync(User);

            var img = s3Helper.GetUrl(_imageBucket, "images/" + user.Image);
            ViewBag.Image = img.ToString();

            return View(new EditProfileViewModel {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                FavoriteBook = user.FavoriteBook,
                Image = user.Image
            });
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model, IFormFile ImageData)
        {
            var user = await _userManager.GetUserAsync(User);

            // Save ImageData
            Stream fileStream = null;
            var contentType = "";
            if (ImageData != null)  // ImageData er: IFormFile ImageData
            {
                contentType = ImageData.ContentType;
                fileStream = ImageData.OpenReadStream();
                var ImageExtension = ImageData.FileName.Substring(ImageData.FileName.LastIndexOf(".")).ToLower();
                var ImageName = user.Id; // gæti verið t.d. userid?

                //Save Image to bucket
                // Add Image to S3 bucket
                S3Helper s3Helper = new S3Helper(_s3Client);
                await s3Helper.SaveFile(_imageBucket, "images/" + ImageName + ImageExtension, fileStream, S3CannedACL.PublicRead, contentType);


                model.Image = ImageName + ImageExtension;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.FavoriteBook = model.FavoriteBook;
            user.Image = model.Image;

            await _userManager.UpdateAsync(user);


            return View(model);
        }


        [HttpGet]
 
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}