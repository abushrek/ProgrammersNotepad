using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.API.Configurators.Interfaces
{
    public interface IConfigurator
    {
        IServiceCollection Service { get; }
        ServiceProvider ServiceProvider { get; }
        void Configure(params IInstaller[] installers);
    }
}