using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class FullRecipeViewModel: ViewModelBase
    {
        private readonly FullRecipe _fullRecipe;
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

        public FullRecipeViewModel(FullRecipe fullRecipe)
        {
            _fullRecipe = fullRecipe;

            _ingredients = new ObservableCollection<IngredientInRecipeViewModel>(
                (from i in fullRecipe.Ingridients
                 select new IngredientInRecipeViewModel(i)).ToList());

            _steps = new ObservableCollection<RecipeStepViewModel>(
                (from i in fullRecipe.Steps
                 select new RecipeStepViewModel(i)).ToList());

            _successData = new SuccessDataViewModel(fullRecipe.SuccessData!);

        }


    }
}
