#SignalR meets Akka.NET

An investigation about how to communicate from client-side Javascript with Akka.Net actors (and back) using SignalR hubs.

The message is sent to Hub, mapped to proper type and sent to ActorSystem. Answer from ActorSystem is sent back to the SignalR client browser.

Actors are added in a standard way:
	

    actorSystem.ActorOf<ActorType>('actorName');

Mapping are added as simply as:

    var mapper = new MessageMapper()
							    .Add<YourMessageType>();
					
Then JS side:

    var path = "/echo";
    var msg = { "YourField": "Example" };
    var msgType = "Namespace.Message";
    hub.server.ask('actorPath', msg, 	msgType, "uuid");
	
The handler for response messages is 'answer' function:

    hub.client.answer = function (message, messageId) {...}
	
Read the code for more.

This code should not be used for production in any case. It's a prototype and contains some not-so-good practices (ServiceLocator, no proper error handling)

Twitter: https://twitter.com/LemmIT
