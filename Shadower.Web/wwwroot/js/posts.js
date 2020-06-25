function addPost(post) {
    $("#importantPosts").append($("<tr>").append($("<td>").text(post.uploadedDateTime)).append($("<td>").text(post.link)));
}

function populateTable() {
    $.ajax({
        method: "get",
        url: '/Posts/GetImportant',
        success: function (data) {
            for (let post of data) {
                addPost(post);
            }
        },
        error: function (req, status, err) {
            console.log("something went wrong");
            console.log(status);
            console.log(err);
            console.log(req);
        }
    });
}

window.onload = populateTable;