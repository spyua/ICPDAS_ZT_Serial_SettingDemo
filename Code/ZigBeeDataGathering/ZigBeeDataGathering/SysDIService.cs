using Akka.Actor;
using Akka.DI.Extensions.DependencyInjection;
using Akka.Event;
using AkkaSysBase;
using AkkaSysBase.Base;
using LogSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using ZigBeeDataGathering.ZigBee;

namespace ZigBeeDataGathering
{
    public class SysDIService
    {
        private readonly IServiceCollection _service;
        private readonly IConfiguration _configuration;

        public SysDIService(IServiceCollection service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public IServiceCollection Inject()
        {
            _service.AddSingleton<ISysAkkaManager>(p =>
            {
                var akkaSys = _configuration["AkkaConfigure:AkaSysName"];
                var akkaPort = _configuration["AkkaConfigure:AkaSysPort"];

                var actSystem = ActorSystem.Create(akkaSys, AkkaPara.Config(akkaPort));

                actSystem.UseServiceProvider(p);
                return new SysAkkaManager(actSystem);
            });
            _service.AddScoped(p => {
                var akkaManager = p.GetService<ISysAkkaManager>();
                var consoleLog = new ConsoleLogSend();
                return new ZigBeeMgr(akkaManager, consoleLog);
            });

            _service.AddScoped(p => {
                var akkaManager = p.GetService<ISysAkkaManager>();
                var ipPoint = NewIPPoint("ZigBee");
                var consoleLog = new ConsoleLogSend();
                return new ZigBeeClient(ipPoint, consoleLog);
            });

            return _service;
        }


        private SysIP NewIPPoint(string sysName)
        {
            var localIp = _configuration[$"AkkaConfigure:{sysName}:LocalIp"];
            var localPort = _configuration[$"AkkaConfigure:{sysName}:LocalPort"];
            var remoteIp = _configuration[$"AkkaConfigure:{sysName}:RemoteIp"];
            var remotePort = _configuration[$"AkkaConfigure:{sysName}:RemotePort"];

            var ipPoint = new SysIP
            {
                LocalIpEndPoint = new IPEndPoint(IPAddress.Parse(localIp), Int32.Parse(localPort)),
                RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(remoteIp), Int32.Parse(remotePort))
            };

            return ipPoint;
        }

      
    }
}
