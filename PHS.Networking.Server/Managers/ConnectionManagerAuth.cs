using PHS.Networking.Server.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PHS.Networking.Server.Managers
{
    public abstract class ConnectionManagerAuth<Z, A> : ConnectionManager<Z> where Z : IIdentity<A>
    {
        protected ConcurrentDictionary<A, ConnectionManager<Z>> _users =
            new ConcurrentDictionary<A, ConnectionManager<Z>>();

        public virtual bool AddIdentity(Z identity)
        {
            AddConnection(identity.ConnectionId, identity);

            if (!_users.TryGetValue(identity.UserId, out var userOriginal))
            {
                userOriginal = new ConnectionManager<Z>();
                if (!_users.TryAdd(identity.UserId, userOriginal))
                {
                    return false;
                }
            }

            var userNew = new ConnectionManager<Z>(userOriginal.GetAllConnectionsDictionary());
            userNew.AddConnection(identity.ConnectionId, identity);
            return _users.TryUpdate(identity.UserId, userNew, userOriginal);
        }
        public override bool RemoveConnection(string id)
        {
            _connections.TryRemove(id, out var _);

            try
            {
                A userToRemove = default;
                bool removeUser = false;
                foreach (var user in _users)
                {
                    if (user.Value.RemoveConnection(id))
                    {
                        if (user.Value.CountConnections() == 0)
                        {
                            userToRemove = user.Key;
                            removeUser = true;
                            break;
                        }

                        return true;
                    }
                }

                if (removeUser)
                {
                    _users.TryRemove(userToRemove, out var _);
                    return true;
                }
            }
            catch
            { }

            return false;
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
