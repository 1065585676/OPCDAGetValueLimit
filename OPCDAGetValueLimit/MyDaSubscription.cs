using Softing.OPCToolbox.Client;

namespace DATest
{
    class MyDaSubscription : DaSubscription
    {
        public MyDaSubscription(uint updateRate, MyDaSession parentSession) : base(updateRate, parentSession)
        {
        }
    }
}
