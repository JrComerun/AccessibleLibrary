$(document).ready(function () {
    // ***************************************************
    //               Child Category Show
    //****************************************************
    let Categories = document.querySelectorAll(".main-category")
    let childCategories = document.querySelectorAll(".childCategories")
    Categories.forEach((e) => {
        e.addEventListener("click", function () {
            this.nextElementSibling.classList.add("show")
        })
    })
    childCategories.forEach((a) => {
        document.body.addEventListener("click", function () {
            if (a.classList.contains("show")) {
                a.classList.remove("show")
            }
        }, true)
    })
})