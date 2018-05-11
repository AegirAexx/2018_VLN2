$(document).ready(function () {
    // Developer key from Google
    const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

    // BOOK 1
    const book1 = document.querySelector("#top-ten-isbn-1").innerHTML;

    const googleURL1 = `https://www.googleapis.com/books/v1/volumes?q=${book1}&key=${key}`;

    $.get(googleURL1,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-1").append(event);
    });
    // BOOK 2
    const book2 = document.querySelector("#top-ten-isbn-2").innerHTML;

    const googleURL2 = `https://www.googleapis.com/books/v1/volumes?q=${book2}&key=${key}`;

    $.get(googleURL2,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-2").append(event);
    });
    // BOOK 3
    const book3 = document.querySelector("#top-ten-isbn-3").innerHTML;

    const googleURL3 = `https://www.googleapis.com/books/v1/volumes?q=${book3}&key=${key}`;

    $.get(googleURL3,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-3").append(event);
    });
    // BOOK 4
    const book4 = document.querySelector("#top-ten-isbn-4").innerHTML;

    const googleURL4 = `https://www.googleapis.com/books/v1/volumes?q=${book4}&key=${key}`;

    $.get(googleURL4,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-4").append(event);
    });
    // BOOK 5
    const book5 = document.querySelector("#top-ten-isbn-5").innerHTML;

    const googleURL5 = `https://www.googleapis.com/books/v1/volumes?q=${book5}&key=${key}`;

    $.get(googleURL5,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-5").append(event);
    });
    // BOOK 6
    const book6 = document.querySelector("#top-ten-isbn-6").innerHTML;

    const googleURL6 = `https://www.googleapis.com/books/v1/volumes?q=${book6}&key=${key}`;

    $.get(googleURL6,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-6").append(event);
    });
    // BOOK 7
    const book7 = document.querySelector("#top-ten-isbn-7").innerHTML;

    const googleURL7 = `https://www.googleapis.com/books/v1/volumes?q=${book7}&key=${key}`;

    $.get(googleURL7,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-7").append(event);
    });
    // BOOK 8
    const book8 = document.querySelector("#top-ten-isbn-8").innerHTML;

    const googleURL8 = `https://www.googleapis.com/books/v1/volumes?q=${book8}&key=${key}`;

    $.get(googleURL8,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-8").append(event);
    });
    // BOOK 9
    const book9 = document.querySelector("#top-ten-isbn-9").innerHTML;

    const googleURL9 = `https://www.googleapis.com/books/v1/volumes?q=${book9}&key=${key}`;

    $.get(googleURL9,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-9").append(event);
    });
    // BOOK 10
    const book10 = document.querySelector("#top-ten-isbn-10").innerHTML;

    const googleURL10 = `https://www.googleapis.com/books/v1/volumes?q=${book10}&key=${key}`;

    $.get(googleURL10,(data) => {
        const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
        
        const event = `<img class="img-fluid d-block" src="${imageURL}">`;

        $("#top-ten-10").append(event);
    });
});