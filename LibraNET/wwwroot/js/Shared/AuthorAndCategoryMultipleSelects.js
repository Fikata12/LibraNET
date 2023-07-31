$('#multiple-select-field-authors').select2({
    theme: "bootstrap-5",
    width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
    placeholder: $(this).data('placeholder'),
    closeOnSelect: false,
});
$('#multiple-select-field-categories').select2({
    theme: "bootstrap-5",
    width: $(this).data('width') ? $(this).data('width') : $(this).hasClass('w-100') ? '100%' : 'style',
    placeholder: $(this).data('placeholder'),
    closeOnSelect: false,
});

var lastValidAuthor = null;

$('#multiple-select-field-categories').change(function (event) {

    if ($(this).val().length >= 5) {

        $(this).val(lastValidAuthor);
    } else {
        lastValidAuthor = $(this).val();
    }
});

var lastValidAuthor = null;

$('#multiple-select-field-authors').change(function (event) {

    if ($(this).val().length >= 5) {

        $(this).val(lastValidAuthor);
    } else {
        lastValidAuthor = $(this).val();
    }
});