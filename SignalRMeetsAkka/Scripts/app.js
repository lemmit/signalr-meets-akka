(function () {
    console.log("Start");
    var hub = $.connection.testHub;
    
    //hub.client.tell does not work, beware
    hub.client.answer = function (message, messageId) {
        console.log("Message received, id: " + messageId);
        console.log(message);
    };
    $.connection.hub.start().done(function () {
        console.log("Hup opened");
        var path = "/echo";
        var msg = { "Message": "Ping" };
        var msgType = "SignalRMeetsAkka.Echo";
        console.log("Send(" + path + ", " + JSON.stringify(msg) + ", " + msgType);
        hub.server.send(path, msg, msgType);
        var uuid = "t45t8u34r8h3u984ur9384r";
        console.log("Ask(" + path + ", " + JSON.stringify(msg) + ", " + msgType + ", " + uuid);
        hub.server.ask(path, msg, msgType, uuid);
    });
})();