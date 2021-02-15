//*********************************************************
//                       Add Bookmark
//*********************************************************
let bookmark = document.querySelectorAll(".bookmark-a");
bookmark.forEach((b) => {
    b.addEventListener("click", function () {
        let bookmarId = b.nextElementSibling.value
        bookmark.forEach((b2) => {
            if (b.nextElementSibling.value == b2.nextElementSibling.value) {
                if (b2.children[0].classList.contains("far")) {
                    b2.children[0].classList.replace("far", "fas")
                }
                else {
                    b2.children[0].classList.replace("fas", "far")
                }
            }
        })
        $.ajax({
            url: `/Profile/BookMark/` + bookmarId,
            type: "Post",
        });
    })
})






//$(document).on('click', bookmark, function () {
//    if (userAuthorized) {
//        bookmarkInp = $(".bookmark-input").val()
//        bookmark = $(".bookmark-a")

//       
//    }
    
//})