using Cybud_WPF_0._1.ViewModels;
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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private ChatAiServiceViewModel _viewmodel;
        public Chat()
        {
            InitializeComponent();
            _viewmodel = new ChatAiServiceViewModel();
            DataContext = _viewmodel;
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            await _viewmodel.SendMessageAsync();
        }

        private void Ai_Response(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.ScrollToEnd();
        }
    }
}
