
$(document).ready(function () {
    // Developer key from Google
    const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";
  
        $('.isbn').each(function(){
          const book = $(this).text();
      
          const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${book}`;
          
          $.get(googleURL,(data) => {
            const imageURL = data.items[0].volumeInfo.imageLinks.smallThumbnail;
      
            const cover = `<img class="img-fluid d-block" src="${imageURL}">`;
            
            $(this).parent().find(".thumbnail").append(cover);
          });
        });
});