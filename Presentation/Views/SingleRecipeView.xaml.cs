using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Presentation.Models;
using static System.Net.WebRequestMethods;

namespace Presentation.Views
{
    /// <summary>
    /// Interaction logic for SingleRecipeView.xaml
    /// </summary>
    public partial class SingleRecipeView : UserControl
    {
        public SingleRecipeView()
        {
            InitializeComponent();
            IngridientsItems.ItemsSource = new List<IngridientInRecipe> () { 
                                                new IngridientInRecipe() { ID = 1, Amount = 3, Unit = "cups", Name = "3 cups flour" }, 
                                                new IngridientInRecipe() { ID = 2, Amount = 1.5, Unit = "teaspon", Name = "1.5 teaspoons sugar" } };

            StepsItems.ItemsSource = new List<RecipeStep> {
                new RecipeStep (){ Number = 1, Step = "Preheat the oven to 350 degrees F (175 degrees C). Lightly grease a 9x5-inch loaf pan." },
                new RecipeStep (){ Number = 2, Step = "Combine flour, baking soda, and salt in a large bowl. Beat brown sugar and butter with an electric mixer in a separate large bowl until smooth. Stir in eggs and mashed bananas until well blended. Stir banana mixture into flour mixture until just combined. Pour batter into the prepared loaf pan." },
                new RecipeStep (){ Number = 3, Step = "Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 60 minutes. Let bread cool in pan for 10 minutes, then turn out onto a wire rack to cool completely." },
            };

        }
    }
}
