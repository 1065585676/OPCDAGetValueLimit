using Softing.OPCToolbox;
using Softing.OPCToolbox.Client;
using System.IO;
using System;

namespace DATest
{
    class MyDaItem : DaItem
    {
        public MyDaItem(string itemId, MyDaSubscription parentSubscription) : base(itemId, parentSubscription)
        {
            ValueChanged += new ValueChangedEventHandler(HandleValueChanged);
        }

        public static void HandleValueChanged(DaItem aDaItem, ValueQT aValue)
        {
            if (!MainWindow.isStopWatchValueChangeEvent)
            {
                File.AppendAllText(@"./change.txt", "Value changed:" + String.Format("{0,-19} {1} {2,-50} ", aDaItem.Id, "-", aValue.ToString()) + "\r\n");
                SendMsgToWindow.PushMessage(aDaItem.Id + "@" + aValue.ToString());
            }
        } // end HandleValueChanged
    }
}
