using AkkaSysBase;
using AkkaSysBase.Base;
using LogSender;

namespace ZigBeeDataGathering.ZigBee
{
    public class ZigBeeMgr : BaseActor
    {
        public ZigBeeMgr(ISysAkkaManager akkaManager, ILog log) : base(log)
        {

            akkaManager.CreateChildActor<ZigBeeClient>(Context);
        }

    }
}
