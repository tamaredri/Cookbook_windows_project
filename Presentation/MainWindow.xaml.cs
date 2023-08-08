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

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //double screenWidth = SystemParameters.PrimaryScreenWidth * 0.1;
            //double screenHeight = SystemParameters.PrimaryScreenHeight * 0.3;
        }

        private void SearchIngredient_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
