using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Installers
{
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("ServiceLayer").Pick().WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Data").Pick().If(t => !t.Name.Contains("DataContext")).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Data").Pick().If(t => t.Name.Contains("DataContext")).WithServiceAllInterfaces().LifestyleSingleton());
        }
    }

}
