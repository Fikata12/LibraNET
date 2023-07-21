var inputLeft = document.getElementById("input-left");
var inputRight = document.getElementById("input-right");

var thumbLeft = document.querySelector(".slider > .thumb.left");
var thumbRight = document.querySelector(".slider > .thumb.right");
var range = document.querySelector(".slider > .range");

var amountLeft = document.getElementById('amount-left')
var amountRight = document.getElementById('amount-right')

function setLeftValue() {
    var min = parseInt(inputLeft.min);
    var max = parseInt(inputLeft.max);

    inputLeft.value = Math.min(parseInt(inputLeft.value), parseInt(inputRight.value) - 1);

    var percent = ((inputLeft.value - min) / (max - min)) * 100;

    thumbLeft.style.left = percent + "%";
    range.style.left = percent + "%";
    amountLeft.innerText = inputLeft.value;
}

function setRightValue() {
    var min = parseInt(inputRight.min);
    var max = parseInt(inputRight.max);

    inputRight.value = Math.max(parseInt(inputRight.value), parseInt(inputLeft.value) + 1);

    var percent = ((inputRight.value - min) / (max - min)) * 100;

    amountRight.innerText = inputRight.value;
    thumbRight.style.right = (100 - percent) + "%";
    range.style.right = (100 - percent) + "%";
}

setLeftValue();
setRightValue();

inputLeft.addEventListener("input", setLeftValue);
inputRight.addEventListener("input", setRightValue);

let filterbar = document.querySelector("#filterbar");
let filterbtn = document.querySelector("#filter-btn");

document.addEventListener("DOMContentLoaded", function () {
    if (localStorage.getItem("areFiltersShown") == null) {
        filterbar.classList.remove("collapse");
        filterbar.classList.add("show");
        localStorage.setItem('areFiltersShown', true);
    }

    let areFiltersShown = JSON.parse(localStorage.getItem("areFiltersShown"));

    if (areFiltersShown) {
        filterbar.classList.remove("collapse");
        filterbar.classList.add("show");
        filterbtn.textContent = "Hide filters";
        return;
    }

    filterbtn.textContent = "Show filters";
})

filterbar.addEventListener('hide.bs.collapse', function () {
    localStorage.setItem('areFiltersShown', false);

    $('#filter-btn').html("Show filters");
})

filterbar.addEventListener('show.bs.collapse', function () {
    localStorage.setItem('areFiltersShown', true);

    $('#filter-btn').html("Hide filters");
})

function submitForm() {
    document.getElementById("filterForm").submit();
}

function resetFilters() {
    let checkboxes = document.querySelectorAll("#filterbar input[type=checkbox]:checked");
    for (const checkbox of checkboxes) {
        checkbox.checked = false;
    }

    inputLeft.value = inputLeft.min;
    inputRight.value = inputRight.max;

    submitForm();
}
