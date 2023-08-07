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

namespace Presentation.Views
{
    public class Recipe
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Image { get; set; }

        public Recipe(string name, double value, string image)
        {
            Name = name;
            Value = value;
            Image = image;
        }
    }

    /// <summary>
    /// Interaction logic for SearchRecipeResultsView.xaml
    /// </summary>
    public partial class RecipeResultsListView : UserControl
    {
       

        public RecipeResultsListView()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewRecipe.ItemsSource = products;
        }

        private List<Recipe> GetProducts()
        {
            return new List<Recipe>()
                {
                new Recipe("lettuce salad 1", 205.46, "/Assets/1.jpg"),
                new Recipe("lettuce salad 2", 102.50, "/Assets/2.jpg"),
                new Recipe("lettuce salad 3", 400.99, "/Assets/3.jpg"),
                new Recipe("lettuce salad 4", 350.26, "/Assets/4.jpg"),
                new Recipe("lettuce salad 5", 150.10, "/Assets/5.jpg"),
                new Recipe("lettuce salad 6", 100.02, "/Assets/6.jpg"),
                new Recipe("lettuce salad 7", 295.25, "/Assets/7.jpg"),
                new Recipe("lettuce salad 8", 295.25, "/Assets/7.jpg"),
                new Recipe("lettuce salad 9", 295.25, "/Assets/7.jpg"),
                new Recipe("lettuce salad 10", 295.25, "/Assets/7.jpg"),
                };
        }

        private void openRecipe(object sender, MouseButtonEventArgs e)
        {
            new SingleRecipeWindow();
        }
    }
}
