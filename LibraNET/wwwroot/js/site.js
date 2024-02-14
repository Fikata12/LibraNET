function onBlur() {
    const form = document.getElementById("search-form");
    const searchForm = Object.fromEntries(new FormData(form));

    if (searchForm.SearchString === '' || searchForm.SearchString === null) {
        form.submit();
    }
};