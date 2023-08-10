using Presentation.Commands;
using Presentation.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class FullRecipeViewModel: ViewModelBase
    {
        private readonly FullRecipe _fullRecipe;
        private readonly NavigationStore _navigationStore;

        public int ID => _fullRecipe.ID;
        public string? Title => _fullRecipe.Title;
        public string? Image => _fullRecipe.Image;
        public int ReadyInMinutes => _fullRecipe.ReadyInMinutes;
        public int Servings => _fullRecipe.Servings;
        public string? Summary => _fullRecipe.Summary;


        private ObservableCollection<IngredientInRecipeViewModel>? _ingredients;
        public IEnumerable<IngredientInRecipeViewModel>? Ingridients => _ingredients;


        private ObservableCollection<RecipeStepViewModel>? _steps;
        public IEnumerable<RecipeStepViewModel>? Steps => _steps;


        private SuccessDataViewModel? _successData;
        public SuccessDataViewModel? SuccessData {
            get { return _successData; }
            set { _successData = value; OnPropertyChanged(nameof(SuccessData)); }
        }

        public ICommand? FindSimilarRecipesCommand => new CommandBase(execute => OpenSimilarRecipe());
        private void OpenSimilarRecipe()
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

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        public FullRecipeViewModel(NavigationStore navigationStore, FullRecipe fullRecipe)
        {
            _navigationStore = navigationStore;
            _fullRecipe = fullRecipe;

            _ingredients = new ObservableCollection<IngredientInRecipeViewModel>(
                (from i in fullRecipe.Ingridients
                 select new IngredientInRecipeViewModel(i)).ToList());

            _steps = new ObservableCollection<RecipeStepViewModel>(
                (from i in fullRecipe.Steps
                 select new RecipeStepViewModel(i)).ToList());

            _successData = new SuccessDataViewModel(_navigationStore, fullRecipe.SuccessData!);

        }


    }
}
