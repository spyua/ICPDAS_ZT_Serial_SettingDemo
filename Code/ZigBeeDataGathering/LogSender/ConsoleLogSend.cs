using System;

namespace LogSender
{
    public class ConsoleLogSend : ILog
    {
     
        public ConsoleLogSend()
        {
        }

        public void A(string title, string content)
        {
         
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void D(string title, string content)
        {
         
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void E(string title, string content)
        {
         
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void I(string title, string content)
        {
          
            Console.WriteLine("【" + title + "】" + ":" + content);
        }
    }
}
