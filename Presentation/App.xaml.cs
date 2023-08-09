using Presentation.Models;
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

        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore!.CurrentViewModel = new FreeSearchViewModel(_navigationStore);
           // _navigationStore!.CurrentViewModel = new RecipeListViewModel(_navigationStore, new List<RecipeToList>() {
           //                                           new RecipeToList(){ID = 1, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 1"},
           //                                           new RecipeToList(){ID = 2, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 2"},
           //                                           new RecipeToList(){ID = 3, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 3"},
           //                                           new RecipeToList(){ID = 4, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 4"},
           //                                           new RecipeToList(){ID = 5, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 5"},
           //                                           new RecipeToList(){ID = 6, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 6"},
           //                                           new RecipeToList(){ID = 7, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 7"} }
           //);
            MainWindow = new MainWindow() { DataContext = new MainViewModel(_navigationStore!) };
            MainWindow.Show();
            base.OnStartup(e);

        }

    }
}
