using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.API.Configurators.Interfaces;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.API.Configurators
{
    public abstract class BaseConfigurator:IConfigurator
    {
        public IServiceCollection Service { get; }
        public ServiceProvider ServiceProvider { protected set; get; }

        protected BaseConfigurator(IServiceCollection service)
        {
            Service = service;
        }

        public virtual void Configure(params IInstaller[] installers)
        {
            foreach (IInstaller installer in installers)
            {
                installer.Install(Service);
            }
            ServiceProvider = Service.BuildServiceProvider();
        }
    }
}