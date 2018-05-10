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

    // ***AJAX TOP TEN MYNDIR***
    function getTopTen(){
    // $("#top-ten-nigger").click(() => { 

        // Developer key from Google
        const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

        // ------
        const book1 = document.querySelector("#top-ten-isbn-1").innerHTML;

        const googleURL1 = `https://www.googleapis.com/books/v1/volumes?q=${book1}&key=${key}`;

        $.get(googleURL1,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-1").append(event);
        });
        // ------
        // ------
        const book2 = document.querySelector("#top-ten-isbn-2").innerHTML;

        const googleURL2 = `https://www.googleapis.com/books/v1/volumes?q=${book2}&key=${key}`;

        $.get(googleURL2,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-2").append(event);
        });
        // ------
        // ------
        const book3 = document.querySelector("#top-ten-isbn-3").innerHTML;

        const googleURL3 = `https://www.googleapis.com/books/v1/volumes?q=${book3}&key=${key}`;

        $.get(googleURL3,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-3").append(event);
        });
        // ------
        // ------
        const book4 = document.querySelector("#top-ten-isbn-4").innerHTML;

        const googleURL4 = `https://www.googleapis.com/books/v1/volumes?q=${book4}&key=${key}`;

        $.get(googleURL4,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-4").append(event);
        });
        // ------
        // ------
        const book5 = document.querySelector("#top-ten-isbn-5").innerHTML;

        const googleURL5 = `https://www.googleapis.com/books/v1/volumes?q=${book5}&key=${key}`;

        $.get(googleURL5,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-5").append(event);
        });
        // ------
        // ------
        const book6 = document.querySelector("#top-ten-isbn-6").innerHTML;

        const googleURL6 = `https://www.googleapis.com/books/v1/volumes?q=${book6}&key=${key}`;

        $.get(googleURL6,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-6").append(event);
        });
        // ------
        // ------
        const book7 = document.querySelector("#top-ten-isbn-7").innerHTML;

        const googleURL7 = `https://www.googleapis.com/books/v1/volumes?q=${book7}&key=${key}`;

        $.get(googleURL7,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-7").append(event);
        });
        // ------
        // ------
        const book8 = document.querySelector("#top-ten-isbn-8").innerHTML;

        const googleURL8 = `https://www.googleapis.com/books/v1/volumes?q=${book8}&key=${key}`;

        $.get(googleURL8,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-8").append(event);
        });
        // ------
        // ------
        const book9 = document.querySelector("#top-ten-isbn-9").innerHTML;

        const googleURL9 = `https://www.googleapis.com/books/v1/volumes?q=${book9}&key=${key}`;

        $.get(googleURL9,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-9").append(event);
        });
        // ------
        // ------
        const book10 = document.querySelector("#top-ten-isbn-10").innerHTML;

        const googleURL10 = `https://www.googleapis.com/books/v1/volumes?q=${book10}&key=${key}`;

        $.get(googleURL10,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
            
            const event = `<img class="img-fluid d-block" src="${imageURL}">`;

            $("#top-ten-10").append(event);
        });
        // ------

        
    });

});
