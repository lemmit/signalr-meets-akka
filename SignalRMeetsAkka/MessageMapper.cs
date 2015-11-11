using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SignalRMeetsAkka
{
    internal class MessageMapper
    {
        private readonly Dictionary<string, Func<JObject, object>> _dist;

        public MessageMapper()
        {
            _dist = new Dictionary<string, Func<JObject, object>>();
        }

        public MessageMapper Add<T>()
        {
            _dist.Add(typeof(T).FullName, message => message.ToObject<T>());
            return this;
        }

        public object Map(object @object, string messageTypeName)
        {
            var jobj = (JObject)@object;
            return Map(jobj, messageTypeName);
        }

        public object Map(JObject jObject, string messageTypeName)
        {
            var mappedObj = _dist[messageTypeName](jObject);
            return mappedObj;
        }
    }
}