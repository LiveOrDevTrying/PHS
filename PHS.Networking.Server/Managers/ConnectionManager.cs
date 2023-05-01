using PHS.Networking.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PHS.Networking.Server.Managers
{
    public class ConnectionManager<T> where T : IConnection
    {
        protected ConcurrentDictionary<string, T> _connections =
            new ConcurrentDictionary<string, T>();

        public ConnectionManager()
        {
        }

        public ConnectionManager(ConcurrentDictionary<string, T> connections)
        {
            _connections = new ConcurrentDictionary<string, T>();
            foreach (var item in connections)
            {
                _connections.TryAdd(item.Key, item.Value);
            }
        }

        public virtual IEnumerable<T> GetAllConnections()
        {
            return _connections.Values;
        }
        public virtual ConcurrentDictionary<string, T> GetAllConnectionsDictionary()
        {
            return _connections;
        }
        public virtual bool GetConnection(string id, out T connection)
        {
            return _connections.TryGetValue(id, out connection);
        }
        public virtual bool AddConnection(string id, T connection)
        {
            return _connections.TryAdd(id, connection);
        }
        public virtual bool RemoveConnection(string id)
        {
            return _connections.TryRemove(id, out var _);
        }
        public virtual int CountConnections()
        {
            return _connections.Count;
        }
    }
}
