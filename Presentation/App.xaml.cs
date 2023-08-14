using AppServer;
using Presentation.Stores;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore? _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public App()
        {
            _navigationStore = new NavigationStore();
            _serverAccess = new ServerAccess();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore!.CurrentViewModel = new EntryViewModel(_serverAccess, _navigationStore);
            MainWindow = new MainWindow() { DataContext = new MainViewModel(_navigationStore!) };
            MainWindow.Show();
            base.OnStartup(e);
        }

    }
}
