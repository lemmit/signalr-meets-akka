using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRMeetsAkka.Hubs
{
    public abstract class LifeCycleLoggerHub : Hub
    {
        public LifeCycleLoggerHub()
        {
            Debug.WriteLine("[Hub created] {0}",
                DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"));
        }

        public override Task OnConnected()
        {
            Debug.WriteLine("[{0}] Client '{1}' connected.",
                DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                Debug.WriteLine("[{0}] Client {1} explicitly closed the connection.",
                    DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);
            }
            else
            {
                Debug.WriteLine("[{0}] Client {1} timed out .",
                    DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);
            }

            return base.OnDisconnected(stopCalled);
        }

    }
}