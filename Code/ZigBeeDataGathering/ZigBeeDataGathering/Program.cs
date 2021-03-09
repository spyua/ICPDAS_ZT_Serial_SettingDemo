using System;

namespace ZigBeeDataGathering
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            Console.WriteLine("123");
            Console.ReadKey();
        }
    }
}
