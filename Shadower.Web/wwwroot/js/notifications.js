var connection = null;

$(document).ready(function() {
    connection = new signalR.HubConnectionBuilder().withUrl("/Notifications").build();

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("UpdateFoundFaces", function (date, link) {
        addPost({ uploadedDateTime: date, link: link });
    });
});