using Presentation.Models;
using Presentation.ViewModels;
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
            DataContext = new RecipeListViewModel(new ObservableCollection<RecipeForListViewModel>() {
                        new RecipeForListViewModel(new RecipeToList(){ID = 1, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 1"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 2, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 2"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 3, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 3"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 4, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 4"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 5, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 5"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 6, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 6"}),
                        new RecipeForListViewModel(new RecipeToList(){ID = 7, Image = "https://chef-lavan.co.il/wp-content/uploads/old-storage/uploads/images/cf2a5b4afd4c80bc67b190f87a5752f1.jpg", Title = "lettuce salad 7"})
            });
        }
    }
}
