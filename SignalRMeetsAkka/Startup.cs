using Owin;
using Akka.Actor;

namespace SignalRMeetsAkka
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var actorSystem = ActorSystem.Create("TestSystem");
            actorSystem.ActorOf<EchoActor>("echo");

            //register message types
            var mapper = new MessageMapper()
                                .Add<Echo>();

            ServiceLocator.Register<ActorSystem>(actorSystem);
            ServiceLocator.Register<MessageMapper>(mapper);

            app.MapSignalR();
        }
    }
}