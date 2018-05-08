using System;
using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService : IUserServices
    {

    public void ProcessUser(RegisterViewModel model)  ///Used to check user input in RegisterViewModel -Arnar
    {
      if (string.IsNullOrEmpty(model.Email)) 
      {
          throw new Exception("Email is missing");
      }
    if (string.IsNullOrEmpty(model.FirstName)) 
      {
          throw new Exception("First name is missing");
      }
    if (string.IsNullOrEmpty(model.LastName)) 
      {
          throw new Exception("Last name is missing");
      }
    if (string.IsNullOrEmpty(model.Password)) 
      {
          throw new Exception("Password is missing");
      }
    }

    public void ProcessLogin(LoginViewModel user)
    {
    if (string.IsNullOrEmpty(user.Email)) 
        {
            throw new Exception("Email is missing");
        }
    if (string.IsNullOrEmpty(user.Password)) 
        {
            throw new Exception("Password is missing");
        }
    }
  }
}