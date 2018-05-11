$(document).ready(function () {
  // Developer key from Google
  const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

  const bookISBN = document.querySelector("#details-isbn").innerHTML;
  let tempID = document.querySelector("#details-id").innerHTML;
  const bookID = parseInt(tempID);

  const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${bookISBN}`;

  $.get(googleURL,(data) => {
      const imageURL = data.items[0].volumeInfo.imageLinks.thumbnail;
      const text = data.items[0].volumeInfo.description;

      const cover = `<img class="img-fluid d-block mx-auto img-thumbnail" src="${imageURL}">`;
      
      $("#details-cover").append(cover);
      $("#details-description").append(text);
      console.log("haha");
  });

  $("#add-to-cart").click(() =>  { 

    $.post("http://localhost:5000/ShoppingCart/Add", bookID, (data, status) => {
      alert(`Added with ISBN:"${bookISBN}" and id:"${bookID}"`);
    });
    
  });
});




