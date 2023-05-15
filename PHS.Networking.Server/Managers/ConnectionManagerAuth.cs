using PHS.Networking.Server.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PHS.Networking.Server.Managers
{
    public abstract class ConnectionManagerAuth<Z, A> : ConnectionManager<Z> where Z : IIdentity<A>
    {
        protected ConcurrentDictionary<A, ConnectionManager<Z>> _users =
            new ConcurrentDictionary<A, ConnectionManager<Z>>();

        public virtual IEnumerable<Z> GetAllConnectionsForUser(A id)
        {
            if (_users.TryGetValue(id, out var user))
            {
                return user.GetAllConnections();
            }

            return System.Array.Empty<Z>();
        }

        public virtual bool AddUser(Z identity)
        {
            if (AddConnection(identity.ConnectionId, identity))
            {
                if (!_users.TryGetValue(identity.UserId, out var user))
                {
                    user = new ConnectionManager<Z>();
                    if (!_users.TryAdd(identity.UserId, user))
                    {
                        return false;
                    }
                }

                return user.AddConnection(identity.ConnectionId, identity);
            }

            return false;
        }
        public override bool RemoveConnection(string id)
        {
            var user = _users.FirstOrDefault(x => x.Value.GetConnection(id, out var _));
            
            var success = _connections.TryRemove(id, out var _);

            if (user.Value.RemoveConnection(id) && user.Value.CountConnections() == 0)
            {
                _users.TryRemove(user.Key, out var _);
            }

            return success;
        }

        public IEnumerable<Z> GetAll(A id)
        {
            if (_users.TryGetValue(id, out var user))
            {
                return user.GetAllConnections();
            }

            return System.Array.Empty<Z>();
        }
    }
}
