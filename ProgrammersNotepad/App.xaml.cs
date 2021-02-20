using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.API;
using ProgrammersNotepad.BL.Installers;
using ProgrammersNotepad.DAL.Installers;
using ProgrammersNotepad.ViewModels.Installer;

namespace ProgrammersNotepad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitializerOfObjects.Initialize(new ServiceCollection(), new DalInstaller(), new ViewModelsInstaller(), new BlInstaller());
            base.OnStartup(e);
        }
    }
}
