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
using System.Windows.Shapes;
using Cybud_WPF_0._1.ViewModels;

namespace Cybud_WPF_0._1.Views
{
    /// <summary>
    /// Interaction logic for JournalView.xaml
    /// </summary>
    public partial class JournalView : Window
    {
        public JournalView()
        {
            InitializeComponent();
            DataContext = new JournalViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
