using System;
using System.Collections.Generic;

namespace SignalRMeetsAkka
{
    public class ServiceLocator
    {
        private static Dictionary<Type, object> _services =
                                    new Dictionary<Type,object>();

        public static void Register<T>(object obj)
        {
            _services[typeof (T)] = obj;
        }

        public static T Resolve<T>()
        {
            return (T)_services[typeof (T)];
        }
    }
}