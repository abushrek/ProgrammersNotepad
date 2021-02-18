using Microsoft.Extensions.DependencyInjection;

namespace ProgrammersNotepad.DAL.Installers.Interfaces
{
    public interface IInstaller
    {
        void Install(IServiceCollection serviceCollection);
    }
}