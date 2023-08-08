using MaterialDesignColors;
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
        public selectedIngredientsList()
        {
            InitializeComponent();
            DataContext = new SelectIngredientViewModel();
        }

        private void AddIngredientClick(object sender, RoutedEventArgs e)
        {
            var a = DataContext as SelectIngredientViewModel;
            if (a != null)
            {
                ((ObservableCollection<string>?)a.IngredientList!).Add(a.SearchIngredient!);
            }
        }

        private void RemoveIngredientClick(object sender, RoutedEventArgs e)
        {
            var a = DataContext as SelectIngredientViewModel;

            var chip = sender as FrameworkElement;
            if (chip != null)
            {
                string? clickedItem = chip.DataContext as string;
                if (!string.IsNullOrEmpty(clickedItem))
                {
                    ((ObservableCollection<string>?)a!.IngredientList!).Remove(clickedItem);
                }
            }

        }
    }
}
