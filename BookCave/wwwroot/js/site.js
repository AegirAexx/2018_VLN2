/*global $ */
$(document).ready(() => {

    // ***HEADER NAVIGATION***
    $('.menu > ul > li:has( > ul)').addClass('menu-dropdown-icon');
    //Checks if li has sub (ul) and adds class for toggle icon - just an UI


    $('.menu > ul > li > ul:not(:has(ul))').addClass('normal-sub');
    //Checks if drodown menu's li elements have anothere level (ul), if not the dropdown is shown as regular dropdown, not a mega menu (thanks Luka Kladaric)

    $(".menu > ul").before("<a asp-area=\"\" asp-controller=\"Home\" asp-action=\"Index\" class=\"menu-mobile\">BookCave</a>");

    //Adds menu-mobile class (for mobile toggle menu) before the normal menu
    //Mobile menu is hidden if width is more then 959px, but normal menu is displayed
    //Normal menu is hidden if width is below 959px, and jquery adds mobile menu
    //Done this way so it can be used with wordpress without any trouble

    $(".menu > ul > li").hover(function (e) {
        if ($(window).width() > 943) {
            $(this).children("ul").stop(true, false).fadeToggle(150);
            e.preventDefault();
        }
    });
    //If width is more than 943px dropdowns are displayed on hover

    $(".menu > ul > li").click(function () {
        if ($(window).width() <= 943) {
            $(this).children("ul").fadeToggle(150);
        }
    });
    //If width is less or equal to 943px dropdowns are displayed on click (thanks Aman Jain from stackoverflow)

    $(".menu-mobile").click(function (e) {
        $(".menu > ul").toggleClass('show-on-mobile');
        e.preventDefault();
    });
    //when clicked on mobile-menu, normal menu is shown as a list, classic rwd menu story (thanks mwl from stackoverflow)

    ///BookDetails
    $('#write-review').click(function(){
        console.log("test")
        $("#comment").show();
        $("#writeReview").hide();
    });

    // ***DETAILS***
    //Hér fyrir neðan er js fyrir details síðu
    $("ul.menu-items > li").on("click",function(){
        $("ul.menu-items > li").removeClass("active");
        $(this).addClass("active");
    })


    $(function () {
        $('[data-toggle="popover"]').popover()
    })
      
      
    $("#payment-button").click(function(e) {
    
        // Fetch form to apply Bootstrap validation
        var form = $(this).parents('form');
        
        if (form[0].checkValidity() === false) {
        e.preventDefault();
        e.stopPropagation();
        }
        else {
        // Perform ajax submit here
        form.submit();
        }
        
        form.addClass('was-validated');
    });

});
