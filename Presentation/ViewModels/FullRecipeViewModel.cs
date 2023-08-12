using AppServer;
using Presentation.Commands;
using AppServer.Models;
using Presentation.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace Presentation.ViewModels
{
    public class FullRecipeViewModel: ViewModelBase
    {
        private readonly IServerAccess? _serverAccess;
        private readonly NavigationStore _navigationStore;
       
        public int ID { get; }
        public string? Title { get; }
        public string? Image { get; }
        public int ReadyInMinutes { get; }
        public int Servings { get; }
        public string? Summary { get; }


        private ObservableCollection<IngredientInRecipeViewModel>? _ingredients;
        public IEnumerable<IngredientInRecipeViewModel>? Ingridients => _ingredients;


        private ObservableCollection<RecipeStepViewModel>? _steps;
        public IEnumerable<RecipeStepViewModel>? Steps => _steps;


        private SuccessDataViewModel? _successData;
        public SuccessDataViewModel? SuccessData {
            get { return _successData; }
            set { 
                _successData = value; 
                OnPropertyChanged(nameof(SuccessData)); 
            }
        }

        public ICommand? FindSimilarRecipesCommand => new CommandBase(execute => OpenSimilarRecipe());

        private void OpenSimilarRecipe()
        {
            try
            {
                var similarRecipes = _serverAccess!.GetSimilarRecipes(ID);
                _navigationStore.CurrentViewModel = new RecipeListViewModel(_serverAccess, 
                                                                            _navigationStore, 
                                                                            similarRecipes);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        public FullRecipeViewModel(IServerAccess? serverAccess, NavigationStore navigationStore, FullRecipeData fullRecipe)
        {
            _navigationStore = navigationStore;
            _serverAccess = serverAccess;


            ID = fullRecipe.ID;
            Title = fullRecipe.Title;
            Image = fullRecipe.Image;
            ReadyInMinutes = fullRecipe.ReadyInMinutes;
            Servings = fullRecipe.Servings;
            Summary = Regex.Replace(fullRecipe.Summary!, "<.*?>", ""); 

            _ingredients = new ObservableCollection<IngredientInRecipeViewModel>(
                (from i in fullRecipe.Ingridients
                 select new IngredientInRecipeViewModel(i)).ToList());

            _steps = new ObservableCollection<RecipeStepViewModel>(
                (from i in fullRecipe.Steps
                 select new RecipeStepViewModel(i)).ToList());

            _successData = new SuccessDataViewModel(_serverAccess, /*fullRecipe.SuccessData!*/
                new DBRecipeSuccessData(), fullRecipe.Image);
        }
    }
}
