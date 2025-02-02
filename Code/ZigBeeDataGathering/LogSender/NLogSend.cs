﻿using Akka.Event;
using System;

namespace LogSender
{
    public class NLogSend : ILog
    {
        private ILoggingAdapter _nlog;       // Nlog

        public NLogSend(ILoggingAdapter nlog = null)
        {
            _nlog = nlog;
        }

        public void A(string title, string content)
        {
            _nlog.Warning("【" + title + "】" + ":" + content);
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void D(string title, string content)
        {
            _nlog.Debug("【" + title + "】" + ":" + content);
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void E(string title, string content)
        {
            _nlog.Error("【" + title + "】" + ":" + content);
            Console.WriteLine("【" + title + "】" + ":" + content);
        }

        public void I(string title, string content)
        {
            _nlog.Info("【" + title + "】" + ":" + content);
            Console.WriteLine("【" + title + "】" + ":" + content);
        }
    }
}
