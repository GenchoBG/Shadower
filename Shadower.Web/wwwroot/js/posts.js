function addPost(post) {
    $("#importantPosts")
        .append($("<tr>")
            .append($("<td>").text(post.uploadedDateTime))
            .append($("<td>").text(post.link))
            .append($("<td>").append($("<a>").attr("href", "/Posts/Archive/" + post.id).text("Archive").addClass("btn btn-outline-danger"))));



    $("#empty").hide();
}

function populateTable() {
    // show loading thingy

    $.ajax({
        method: "get",
        url: '/Posts/GetImportant',
        success: function (data) {
            // hide loading thingy

            for (let post of data) {
                addPost(post);
            }
            if (data.length == 0) {
                $("#empty").show();
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