const fileInput = document.querySelector('input[type="file"]');

const urlParts = window.location.href.split('/');
let bookId = urlParts[urlParts.length - 1];

$.get("/Admin/Book/Image/" + bookId, async function (data, status) {

	let imageName = data;
	if (imageName) {
		let url = "/Images/Books/" + imageName;

		const response = await fetch(url);
		const blob = await response.blob();

		const file = new File([blob], imageName, { type: blob.type });

		const dataTransfer = new DataTransfer();
		dataTransfer.items.add(file);
		fileInput.files = dataTransfer.files;
	}
});