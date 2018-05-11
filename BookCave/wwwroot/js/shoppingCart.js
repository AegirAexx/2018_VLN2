$(document).ready(function () {
  // Developer key from Google
  const key = "AIzaSyBAnYjI3ZTTYIPGedsL7TYsgV0Emwgo_oI";

      $('.isbn').each(function(){
        const book = $(this).text();
    
        const googleURL = `https://www.googleapis.com/books/v1/volumes?q=${book}&key=${key}`;
        
        $.get(googleURL,(data) => {
          const imageURL = data.items[0].volumeInfo.imageLinks.smallThumbnail;
    
          const cover = `<img class="media-object" src="${imageURL}" style="width: 80px; height: 120px;">`;
          
          $(this).parent().find(".thumbnail").append(cover);
  });
});
});