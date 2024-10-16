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

namespace Cybud_WPF_0._1.Views
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            JournalView journalView = new JournalView();
            journalView.Show();
        }

        private void Finance_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FinanceManager financeManager = new FinanceManager();
            financeManager.Show();
        }

        private void Schedule_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Schedule schedule = new Schedule();
            schedule.Show();
        }

        private void Chat_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Chat chat = new Chat();
            chat.Show();
        }

        private void Therapy_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
