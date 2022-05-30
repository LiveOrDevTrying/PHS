using PHS.Networking.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

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

        public virtual IEnumerable<T> GetAll()
        {
            return _connections.Values.ToArray();
        }
        public virtual ConcurrentDictionary<string, T> GetAllDictionary()
        {
            return _connections;
        }
        public virtual T Get(string id)
        {
            return _connections.TryGetValue(id, out var connection) ? connection : default;
        }
        public bool Add(string id, T connection)
        {
            return _connections.TryAdd(id, connection);
        }
        public virtual bool Remove(string id)
        {
            return _connections.TryRemove(id, out var _);
        }
        public virtual int Count()
        {
            return _connections.Skip(0).Count();
        }
    }
}
