$(document).ready(function () {
  // ***************************************************
  //            Main Mobile Navigation on Button
  //****************************************************
    let openNav = $("#Nav-open-btn")
    let closeNav = $("#Nav-close-btn")
    openNav.click(function () {
        $("#nav-mobile").css("transform","translateX(0%)")
        $("#nav-mobile").css("transition","ease 0.7s")
    })
    closeNav.click(function () {
        $("#nav-mobile").css("transform","translateX(100%)")
        $("#nav-mobile").css("transition","ease 0.7s")
    })


  // ***************************************************
  //            Add Book Navigation on Scrool
  //****************************************************
    let nav = document.querySelector(".nav-mobile2");
  $(window).scroll(function(){
    if($(window).scrollTop()>120){
      nav.classList.add("nav-scrool2");
    }
    else{
      nav.classList.remove("nav-scrool2");
    }
  });
})

 