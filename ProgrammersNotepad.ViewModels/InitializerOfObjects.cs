using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.API.Configurators;
using ProgrammersNotepad.API.Configurators.Interfaces;
using ProgrammersNotepad.BL.Installers;
using ProgrammersNotepad.DAL.Installers;
using ProgrammersNotepad.ViewModels.Installer;

namespace ProgrammersNotepad.ViewModels
{
    public class InitializerOfObjects
    {
        private static IConfigurator _configurator;

        public static T GetService<T>()
        {
            return ServiceProviderServiceExtensions.GetService<T>(_configurator.ServiceProvider);
        }

        public static void Initialize(IServiceCollection service)
        {
            if (service != null)
            {
                _configurator = new ProgrammersNotepadConfigurator(service);
                _configurator.Configure(new DalInstaller(), new BlInstaller(), new ViewModelsInstaller());
            }
        }
    }
}