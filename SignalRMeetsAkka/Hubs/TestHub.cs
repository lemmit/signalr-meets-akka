using System;
using Akka.Actor;

namespace SignalRMeetsAkka.Hubs
{
    public class TestHub : LifeCycleLoggerHub
    {
        private readonly ActorSystem _actorSystem = ServiceLocator.Resolve<ActorSystem>();
        private readonly MessageMapper _mapper = ServiceLocator.Resolve<MessageMapper>();

        private string CreateFullPath(string actorPath)
        {
            return "akka://" + _actorSystem.Name + "/user" + actorPath;
        }

        public void Send(string path, object obj, string messageTypeName)
        {
            var message = _mapper.Map(obj, messageTypeName);
            var fullPath = CreateFullPath(path);
            _actorSystem.ActorSelection(fullPath).Tell(message);
        }

        public void Ask(string path, object obj, string messageTypeName, string messageId)
        {
            var message = _mapper.Map(obj, messageTypeName);
            var fullPath = CreateFullPath(path);
            var result = _actorSystem.ActorSelection(fullPath)
                                     .Ask(message).Result;
            //hub.client.tell does not work, beware
            Clients.Caller.answer(result, messageId);
        }
    }
}