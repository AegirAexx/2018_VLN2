$(document).ready(function () {
  // Developer key from Google
  const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

  const book = document.querySelector("#details-isbn").innerHTML;

  const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${book}&key=${key}`;

  $.get(googleURL,(data) => {
      const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
      
      const event = `<img class="img-fluid d-block mx-auto img-thumbnail" src="${imageURL}">`;

      $("#details-cover").append(event);
  });
});




