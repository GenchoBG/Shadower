function addPost(post) {
    $("#importantPosts")
        .append($("<tr>")
            .attr("id", "post-" + post.id)
            .append($("<td>").text(new Date(post.uploadedDateTime).toLocaleString()))
            .append($("<td>").append(`<a href="${post.link}" style="color:white; text-decoration: none !important;" target="_blank">${post.link}</a>`))
            .append($("<td>").append($("<a>").attr("onclick", "archive(" + post.id + ")").text("Archive").addClass("btn btn-outline-danger"))));

    $("#empty").hide();
}

function archive(id) {
    $.ajax({
        method: "post",
        url: '/Posts/Archive/' + id,
        success: function() {
            $("#post-" + id).remove();
        },
        error: function (req, status, err) {
            console.log("something went wrong");
            console.log(status);
            console.log(err);
            console.log(req);
        }
    });
}

function populateTable() {
    let showArchived = $("#archived").text() == "true";

    let url = '/Posts/GetImportant';
    if (showArchived) {
        url += '?archived=true';
    }

    $.ajax({
        method: "get",
        url: url,
        success: function (data) {

            for (let post of data) {
                addPost(post);
            }
            if (data.length === 0) {
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
