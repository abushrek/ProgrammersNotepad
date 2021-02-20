using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.BL.Installers;
using ProgrammersNotepad.DAL.Installers;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.API.Configurators
{
    public class ProgrammersNotepadConfigurator:BaseConfigurator
    {
        public ProgrammersNotepadConfigurator(IServiceCollection service) : base(service)
        {
        }
    }
}