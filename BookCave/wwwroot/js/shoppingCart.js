$(document).ready(function () {
  // Developer key from Google
  const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

  const book = document.querySelector("#details-isbn").innerHTML;

  const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${book}&key=${key}`;

  $.get(googleURL,(data) => {
      const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;

      const cover = `<img class="media-object" src="${imageURL}" style="width: 72px; height: 72px;">`;
      
      $("#details-cover").append(cover);
  });
});