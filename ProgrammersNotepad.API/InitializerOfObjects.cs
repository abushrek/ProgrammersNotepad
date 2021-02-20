using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.API.Configurators;
using ProgrammersNotepad.API.Configurators.Interfaces;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.API
{
    public class InitializerOfObjects
    {
        private static IConfigurator _configurator;

        public static T GetService<T>()
        {
            return _configurator.ServiceProvider.GetService<T>();
        }

        public static void Initialize(IServiceCollection service, params IInstaller[] installers)
        {
            if (service != null)
            {
                _configurator = new ProgrammersNotepadConfigurator(service);
                _configurator.Configure(installers);
            }
        }
    }
}