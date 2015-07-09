using Castle.Windsor;
using Castle.Windsor.Installer;
using ServiceLayer;
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var program = container.Resolve<IController>();

            var msg = Console.ReadLine();
            while (msg != "exit")
            {
                program.ProcessCommand(msg);
                msg = Console.ReadLine();
            }

        }
    }
}
