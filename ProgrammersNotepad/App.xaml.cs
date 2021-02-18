using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.ViewModels;

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
            InitializerOfObjects.Initialize(new ServiceCollection());
            base.OnStartup(e);
        }
    }
}
