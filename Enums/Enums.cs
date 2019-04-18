namespace PHS.Core.Enums
{
    public enum ActionType
    {
        BroadcastAllConnectedClients,
        BroadcastAccountConnections,
        SendToClient,
        SendToServer
    }

    public enum MessageEventType
    {
        Sent,
        Receive
    }

    public enum ArgsType
    {
        Connection,
        Message,
        Error
    }

    public enum ConnectionEventType
    {
        Connected,
        Disconnect,
        ServerStart,
        ServerStop,
        Connecting,
        MaxConnectionsReached
    }
}
