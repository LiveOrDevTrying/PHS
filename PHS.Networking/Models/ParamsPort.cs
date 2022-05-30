using System;

namespace PHS.Networking.Models
{
    public abstract class ParamsPort : Params
    {
        public int Port { get; protected set; }

        public ParamsPort(int port)
        {
            if (port <= 0)
            {
                throw new ArgumentException("Port is not valid");
            }

            Port = port;
        }
    }
}
