using AppServer;
using Presentation.Commands;
using Presentation.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    internal class EntryViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public EntryViewModel(IServerAccess? serverAccess, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _serverAccess = serverAccess;
        }

        public ICommand? FreeSearchCommand => new CommandBase(execute =>
                                                                _navigationStore.CurrentViewModel = new FreeSearchViewModel(_serverAccess, _navigationStore));

        public ICommand? IngredientSearchCommand => new CommandBase(execute =>
                                                                _navigationStore.CurrentViewModel = new SelectIngredientViewModel(_serverAccess, _navigationStore));

        public ICommand? MyRecipesCommand => new CommandBase(execute => ApplySearch());

        private void ApplySearch()
        {
            //var a = new List<RecipeToList>(){
            //     new RecipeToList(){ID = 1,
            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 1"},
            //     new RecipeToList(){ID = 2,
            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 2"},
            //     new RecipeToList(){ID = 3,

            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 3"},
            //     new RecipeToList(){ID = 4,

            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 4"},
            //     new RecipeToList(){ID = 5,

            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 5"},
            //     new RecipeToList(){ID = 6,

            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 6"},
            //     new RecipeToList(){ID = 7,

            //         Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
            //         Title = "lettuce salad 7"} }; 
            //_navigationStore.CurrentViewModel = new RecipeListViewModel(_serverAccess, _navigationStore, a);
        }
    }
}
