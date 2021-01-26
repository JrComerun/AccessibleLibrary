let nav = document.querySelector("nav");
let navButton = document.querySelector(".button-nav");
let selected= $(".selected")

$(document).ready(function(){
  $(window).scroll(function(){
    if($(window).scrollTop()>60){
      nav.classList.add("nav-scrool");
      $(".header-content").css("padding-top","150px")
    }
    else{
      nav.classList.remove("nav-scrool");
      $(".header-content").css("padding-top","110px")
    }
  });
})