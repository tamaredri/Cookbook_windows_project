using Presentation.Commands;
using Presentation.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class SelectIngredientViewModel : ViewModelBase
    {        
        
        private NavigationStore _navigationStore;

        private string? _searchQuery = "Banana";

        public string? SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value; OnPropertyChanged(nameof(SearchQuery));
            }
        }

        private string? removeIngredientName;

        public string? RemoveIngredientName
        {
            get { return removeIngredientName; }
            set 
            { 
                removeIngredientName = value;
                OnPropertyChanged(nameof(RemoveIngredientName));
            }
        }

        private ObservableCollection<string?>? _ingredientList;

        public IEnumerable<string?>? IngredientList => _ingredientList;


        public ICommand? AddIngredientCommad => new CommandBase(execute => { _ingredientList!.Add(SearchQuery); },
                                                                canExecute => CanAddIngredient());

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        private bool CanAddIngredient()
        {
            return !string.IsNullOrEmpty(SearchQuery);
        }

        public ICommand? RemoveIngredientCommand => new CommandBase(execute => { DeleteIngredientMathod(execute); });

        private void DeleteIngredientMathod(object execute)
        {
            _ingredientList?.Remove(execute as string);
        }

        public ICommand? SearchCommand => new CommandBase(execute => ApplySearch(), canExecute => CanApplySearch());

        private bool CanApplySearch()
        {
            return _ingredientList == null || _ingredientList.Count() != 0;
        }

        private void ApplySearch()
        {
            var a = new List<RecipeToList>(){
                 new RecipeToList(){ID = 1,
                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 1"},
                 new RecipeToList(){ID = 2,
                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 2"},
                 new RecipeToList(){ID = 3,

                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 3"},
                 new RecipeToList(){ID = 4,

                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 4"},
                 new RecipeToList(){ID = 5,

                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 5"},
                 new RecipeToList(){ID = 6,

                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 6"},
                 new RecipeToList(){ID = 7,

                     Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                     Title = "lettuce salad 7"} };
            _navigationStore.CurrentViewModel = new RecipeListViewModel(_navigationStore, a);
        }


        public SelectIngredientViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _ingredientList = new ObservableCollection<string?>() { "Banana"};

        }
    }
}
