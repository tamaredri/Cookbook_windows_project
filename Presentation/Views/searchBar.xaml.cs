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
    /// <summary>
    /// Interaction logic for searchBar.xaml
    /// </summary>
    public partial class searchBar : UserControl
    {
        public searchBar()
        {
            InitializeComponent();
            tb.FilterMode = AutoCompleteFilterMode.Contains;
            tb.ItemsSource = new string[] { "Ali Raza", "Farhan Rasheed", "Rizwan Rasheed" };
        }
    }
}
