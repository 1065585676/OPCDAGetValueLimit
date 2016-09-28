using Softing.OPCToolbox.Client;

namespace DATest
{
    class MyDaSession : DaSession
    {
        public MyDaSession(string url) : base(url)
        {
            ShutdownRequest += new ShutdownEventHandler(HandleServerShutdown);
        }

        public static bool HandleServerShutdown(ObjectSpaceElement sender, string reason)
        {
            //MessagePassingTools.PushOneMessage(sender + " Shutdown - " + reason);
            return true; // reconnection will be performed
        } // end HandleServerShutdown
    }
}
