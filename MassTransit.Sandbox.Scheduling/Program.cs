using System;

namespace MassTransit.Sandbox.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Scheduling.SchedulingBus.Start();
                Console.ReadKey();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
