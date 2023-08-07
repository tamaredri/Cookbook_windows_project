using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Presentation.Views
{

    public class Ingredient
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public Ingredient(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }

    /// <summary>
    /// Interaction logic for selectedIngredientsList.xaml
    /// </summary>
    public partial class selectedIngredientsList : UserControl
    {

        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient> { new Ingredient("banana", "https://spoonacular.com/recipeImages/655055-556x370.jpg"),
                                                                                              new Ingredient("apple","https://spoonacular.com/recipeImages/655055-312x231.jpg"),
                                                                                              new Ingredient("flour", "https://spoonacular.com/recipeImages/652078-312x231.jpg"),
                                                                                              new Ingredient("sugar", "https://spoonacular.com/recipeImages/647631-312x231.jpg"),
                                                                                              new Ingredient("salt", "https://spoonacular.com/recipeImages/663637-312x231.jpg"),
                                                                                              new Ingredient("carrot leaves", "https://spoonacular.com/recipeImages/657003-312x231.jpg")};


        public selectedIngredientsList()
        {
            InitializeComponent();
            InitializeComponent();
            if (ingredients.Count > 0)
                ListViewIngredients.ItemsSource = ingredients;
        }

        private IEnumerable<Ingredient> GetIngredients()
        {
            return new List<Ingredient>()
                {
                new Ingredient("banana", "banana-chips.jpg"),
                new Ingredient("apple","hazelnut-flour.png"),
                new Ingredient("flour", "dry-mustard.jpg"),
                new Ingredient("sugar", "/Assets/4.jpg"),
                new Ingredient("salt", "pork-belly.jpg"),
                new Ingredient("carrot leaves", "carrot-leaves.jpg"),
                };
        }

        private void ButtonsDemoChip_OnDeleteClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
