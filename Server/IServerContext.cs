using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface IServerContext
    {
        void RegisterService(string serviceName, Action<BaseMsg> handler);
        void InvokeService(BaseMsg msg);
    }

    public class ServerContext : IServerContext
    {
        private Dictionary<string, Action<BaseMsg>> serviceHandlers = new Dictionary<string, Action<BaseMsg>>();

        public void RegisterService(string serviceName, Action<BaseMsg> handler)
        {
            serviceHandlers.Add(serviceName, handler);
        }

        public void InvokeService(BaseMsg msg)
        {
            serviceHandlers[msg.Type](msg);
        }
    }
}
