using AkkaSysBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZigBeeDataGathering.ZigBee;

namespace ZigBeeDataGathering
{
    public class Bootstrapper
    {
        private IServiceProvider _provider;

        public Bootstrapper()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsetting.json").Build(); ;

            var sysDI = new SysDIService(new ServiceCollection(), config);
            var serviceContainer = sysDI.Inject();
            _provider = serviceContainer.BuildServiceProvider();
        }

        public void Run()
        {
            var akkaSys = _provider.GetService<ISysAkkaManager>();
            akkaSys.CreateActor<ZigBeeMgr>();  
            
        }

    }
}
