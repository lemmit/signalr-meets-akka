using System.Diagnostics;
using Akka.Actor;

namespace SignalRMeetsAkka
{
    public class Echo
    {
        public Echo(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
    
    public class EchoActor : ReceiveActor
    {
        public EchoActor()
        {
            Receive<Echo>(echo =>
            {
                Debug.WriteLine("Echo: " + echo.Message
                                + "\nSender: " + Sender.Path);
                Sender.Tell(echo, Self);
            });
        }
    }
}