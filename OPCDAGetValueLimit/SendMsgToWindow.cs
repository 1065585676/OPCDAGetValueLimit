using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DATest
{
    class SendMsgToWindow
    {
        private static Queue<string> messageQueue = new Queue<string>();

        public static void PushMessage(string value)
        {
            if (messageQueue.Count > 1000) messageQueue.Dequeue();
            messageQueue.Enqueue(value);
        }

        public static string PopMessage()
        {
            return (messageQueue.Count > 0) ? messageQueue.Dequeue() : "";
        }
    }
}
