const appUrl = "http://localhost:52935/api/messages";
let senderName = null;

$('#choose').click(function (event) {

    chooseUser();
});
$('#reset').click(function (event) {

    resetUser()
});
$("#send").click(function (event) {

    sendMessage()

});

window.setInterval(function () {
    loadMessages();
}, 1000);

function renderMessage(data) {
    $("#messages").empty();

    for (var item of data) {

        let msg = item.content;
        let usr = item.user;
        $("#messages").append(
            '<div class= "message d-flex justify-content-start" > <strong>' + usr + '</strong>: ' + msg + '</div >');

    }
};

function chooseUser() {
    let currentUser = $("#username").val();
    if (currentUser.length === 0) {
        alert("Username cannot be empty!")
        return;
    }
    $("#choose-data").addClass("d-none");
    $("#reset-data").removeClass("d-none");
    $("#username-choice").text(currentUser);
}

function resetUser() {
    currentUser = null;

    $("#username").val("");
    $("#choose-data").removeClass("d-none");
    $("#username-choice").text(currentUser);
    $("#reset-data").addClass("d-none");
}

function loadMessages() {
    $.get({
        url: appUrl,
        success: function success(data) {
            renderMessage(data);
        },
        error: function error(error) {
            console.log(error)
        }
    });
};

function sendMessage() {
    var usernameSend = $("#username").val();

    if (usernameSend.length === 0) {
        alert("Cannot send a message before to choose an Username!");
        return;
    }
    var messageSend = $("#message").val();
    if (messageSend.length === 0) {
        alert("Cannot send an emtpy message!");
        return;
    }
    let sms = { content: messageSend, username: usernameSend };
    console.log(messageSend);
    console.log(usernameSend);
    console.log(sms);
    $.post({
        url: appUrl,
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify({ content: messageSend, username: usernameSend }),
        success: function () {
            resetUser();
            $('#message').empty();
            console.log("send");
        },

        error: console.log("not send")
    });
    loadMessages();
}