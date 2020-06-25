var connection = null;

$(document).ready(function () {
    connection = new signalR.HubConnectionBuilder().withUrl("/Notifications").build();

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("DisplayNotification", function () {
        displayNotification();
        console.log("DADASDSADA");
    });

    connection.on("UpdateFoundFaces", function (date, link, id) {
        addPost({ uploadedDateTime: date, link: link, id: id });
    });
});