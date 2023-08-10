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

namespace Presentation.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly IServerAccess? _serverAccess;

        public RecipeListViewModel(IServerAccess? serverAccess, 
                                   NavigationStore navigation, 
                                   IEnumerable<BasicRecipeData> RecipesToList)
        {
            _navigationStore = navigation;
            _serverAccess = serverAccess;
            _Recipes = new ObservableCollection<RecipeForListViewModel>((from r in RecipesToList
                                                                         select new RecipeForListViewModel(r))
                                                                         .ToList());
        }

        private ObservableCollection<RecipeForListViewModel>? _Recipes;
        public IEnumerable<RecipeForListViewModel>? Recipes => _Recipes;

        private RecipeForListViewModel? _selectedItem;
        public RecipeForListViewModel? SelectedItem
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value; 
                OnPropertyChanged(nameof(SelectedItem)); 
            }
        }

        public ICommand? ReturnCommand => new ReturnViewCommand(_navigationStore);

        public ICommand? SelectRecipeCommand => new CommandBase(execute => OpenRecipe());

        private void OpenRecipe()
        {
            try
            {
                var selectedRecipe = _serverAccess!.GetRecipeById(SelectedItem!.ID);
                _navigationStore.CurrentViewModel = new FullRecipeViewModel(_serverAccess,
                                                                           _navigationStore,
                                                                            selectedRecipe);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        /*
         new FullRecipe()
                {
                    ID = 1,
                    Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                    Ingridients = new List<IngredientInRecipe>() { new IngredientInRecipe() { ID = 1, Amount = 3, Unit = "cups", Name = "3 cups flour" },
                        new IngredientInRecipe() { ID = 2, Amount = 1.5, Unit = "teaspon", Name = "1.5 teaspoons sugar" } },
                    ReadyInMinutes = 50,
                    Servings = 10,
                    Summary = "This banana bread recipe creates the most delicious, moist loaf with loads of banana flavor. " +
                        "Why compromise the banana flavor? Friends and family love my recipe and say it's by far the best! It tastes " +
                        "wonderful toasted. Enjoy!",
                    Title = "BANANA CHOCOLATE",
                    Steps = new List<RecipeStep> { new RecipeStep() { Number = 1, Step = "Preheat the oven to 350 degrees F (175 degrees C). Lightly grease a 9x5-inch loaf pan." },
                        new RecipeStep() { Number = 2, Step = "Combine flour, baking soda, and salt in a large bowl. Beat brown sugar and butter with an electric mixer in a separate large bowl until smooth. Stir in eggs and mashed bananas until well blended. Stir banana mixture into flour mixture until just combined. Pour batter into the prepared loaf pan." },
                        new RecipeStep() { Number = 3, Step = "Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 60 minutes. Let bread cool in pan for 10 minutes, then turn out onto a wire rack to cool completely." } },
                    SuccessData = new SuccessData()
                    {
                        Images = new List<string> { "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                                                    "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                                                    "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                                                    "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg",
                                                    "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg" },
                        Comment = "it is working reut",
                        Rating = 4,
                        usedDates = new List<UsedDate>() { new UsedDate() { Date = new DateTime(2023, 8, 7), Description = "hunnuka" },
                                                           new UsedDate() { Date = new DateTime(2023, 8, 5), Description = "passover" },
                                                           new UsedDate() { Date = new DateTime(2023, 8, 3), Description = "shabatt" },
                                                           new UsedDate() { Date = new DateTime(2023, 8, 1), Description = "purim" },
                        }
                    }
                }
         */

    }
}
