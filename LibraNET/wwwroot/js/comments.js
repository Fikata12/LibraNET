var connection = new signalR.HubConnectionBuilder().withUrl("/commentsHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveComment", function (username, comment, dateTime) {
    const newComment = document.createElement("div");

    const urlParts = window.location.href.split('/');
    let bookId = urlParts[urlParts.length - 1];

    let count = 0;
    $.get("https://localhost:7219/Book/CommentsCount/" + bookId, async function (data, status) {

        count = Number(data);
        if (count == 0) {
            document.getElementById("comments").innerHTML = "";
        }


        newComment.innerHTML =
            `<div class="my-2">
		    <div>
			    <p class="h6 fw-bold d-inline-flex">${username}</p>
		    	<span class="text-muted">${dateTime}</span>
		    </div>
		    <p>${comment}</p>
		    <hr />
	    </div>`;

        document.getElementById("comments").prepend(newComment);
    });
});
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("commentForm").addEventListener("submit", function (e) {
    let comment = document.getElementById("comment");
    let commentValue = comment.value;
    commentValue = commentValue.trim();

    if (commentValue.length > 0 && commentValue.length <= 300) {

        connection.invoke("SendComment", commentValue).catch(function (err) {
            console.error(err.toString());
        });
    }
});