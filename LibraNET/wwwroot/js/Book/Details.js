$(document).ready(function () {
    let inputRate = document.querySelector("input[name=Rating]")
    let rating = 0;

    if (inputRate.value == 0) {
        rating = 5;
    }
    else {
        rating = inputRate.value;
    }

    $(".full-star-ratings").rateYo({
        rating: rating
    });
});

$(".full-star-ratings").on("rateyo.set", function (e, data) {

    let input = document.querySelector("input[name=Rating]")
    input.value = data.rating;
    document.querySelector("#rating-form").submit();
});

document.querySelector("#AddToCartBtn").addEventListener("click", function () {
    document.querySelector("#AddToCartForm").submit();
});