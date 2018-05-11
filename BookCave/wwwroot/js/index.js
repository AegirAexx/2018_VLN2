$(document).ready(function () {
  // Developer key from Google
  const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

      $('.isbn').each(function(){
        const book = $(this).text();
    
        const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${book}`;
        
        $.get(googleURL,(data) => {
          const imageURL = data.items[0].volumeInfo.imageLinks.Thumbnail;
    
          const cover = `<img class="card-img-top " src="${imageURL}" alt="Card image cap">`;
          
          $(this).parent().find(".thumbnail").append(cover);
  });
});
});