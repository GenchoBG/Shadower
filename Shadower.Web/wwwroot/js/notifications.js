var connection = null;

$(document).ready(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/Notifications").build();

    connection.on("UpdateFoundFaces", function (date, link) {
        addPost({ uploadedDateTime: date, link: link });
    });
});