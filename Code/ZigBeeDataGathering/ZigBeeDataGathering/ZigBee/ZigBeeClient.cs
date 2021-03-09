using Akka.IO;
using AkkaSysBase;
using AkkaSysBase.Base;
using Core;
using LogSender;
using Model;
using System;

namespace ZigBeeDataGathering.ZigBee
{
    public class ZigBeeClient : BaseClientActor
    {
        private ILog _log;

        public ZigBeeClient(SysIP akkaSysIp, ILog log) : base(akkaSysIp, log)
        {
            _log = log;
        }

        protected override void TcpReceivedData(Tcp.Received msg)
        {
            base.TcpReceivedData(msg);

            var bytes = msg.Data.ToArray();

            try
            {
                var dataModel = bytes.RawDeserialize(typeof(ModBusTCPModel), true) as ModBusTCPModel;
                _log.I("Rcv Obj", dataModel.ToString());
            }
            catch (Exception e)
            {
                _log.E("Error", e.ToString());
            }
        }
    }
}
