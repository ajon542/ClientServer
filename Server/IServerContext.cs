using System;
using System.Collections.Generic;

namespace Server
{
    /// <summary>
    /// Interface for invoking services from the client or server.
    /// </summary>
    public interface IServerContext
    {
        /// <summary>
        /// Register a service.
        /// </summary>
        /// <param name="serviceName">The service identifier.</param>
        /// <param name="handler">The service handler.</param>
        void RegisterService(string serviceName, Action<BaseMsg> handler);

        /// <summary>
        /// Invoke the service.
        /// </summary>
        /// <param name="msg">The parameters for the service.</param>
        void InvokeService(BaseMsg msg);
    }

    /// <summary>
    /// Implementation of the service handlers.
    /// </summary>
    public class ServerContext : IServerContext
    {
        /// <summary>
        /// The service handlers.
        /// </summary>
        private Dictionary<string, Action<BaseMsg>> serviceHandlers = new Dictionary<string, Action<BaseMsg>>();

        /// <summary>
        /// Register a service.
        /// </summary>
        /// <param name="serviceName">The service identifier.</param>
        /// <param name="handler">The service handler.</param>
        public void RegisterService(string serviceName, Action<BaseMsg> handler)
        {
            if (!serviceHandlers.ContainsKey(serviceName))
            {
                serviceHandlers.Add(serviceName, handler);
            }
            else
            {
                Console.WriteLine("Can't have multiple handlers for the service [{0}].");
            }
        }

        /// <summary>
        /// Invoke the service.
        /// </summary>
        /// <param name="msg">The parameters for the service.</param>
        public void InvokeService(BaseMsg msg)
        {
            if (serviceHandlers.ContainsKey(msg.Type))
            {
                serviceHandlers[msg.Type](msg);
            }
            else
            {
                Console.WriteLine("The service [{0}] does not exist.");
            }
        }
    }
}
