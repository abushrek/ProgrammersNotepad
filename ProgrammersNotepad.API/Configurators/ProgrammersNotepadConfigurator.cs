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

        public override void Configure(params IInstaller[] installers)
        {
            foreach (IInstaller installer in installers)
            {
                installer.Install(Service);
            }
            base.Configure();
        }
    }
}