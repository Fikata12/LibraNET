document.addEventListener("DOMContentLoaded", function () {
    let quantityInputs = document.querySelectorAll(".QuantityInput");
    for (var quantityInput of quantityInputs) {
        quantityInput.addEventListener("change", function (e) {
            let form = e.target.parentElement;
            if (form) {
                form.submit();
            }
        });
    }

    let htmlElement = document.querySelector('html');
    htmlElement.style.scrollBehavior = 'auto';
});
