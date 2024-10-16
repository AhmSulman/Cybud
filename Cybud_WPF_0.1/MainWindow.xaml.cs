using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using Cybud_WPF_0._1.Views;

namespace Cybud_WPF_0._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string json_dat = "json_dat.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIN_Click(object sender, RoutedEventArgs e)
        {
            string email = Email_SignIn.Text.ToString();
            string password = Password_SignIn.Password.ToString();

            if (File.Exists(json_dat))
            {
                var file_data = File.ReadAllText(json_dat);
                Dictionary<string, string> em_pas = JsonConvert.DeserializeObject<Dictionary<string, string>>(file_data);
                try
                {
                    
                    if (em_pas.TryGetValue(email, out password) == true)
                    {
                        this.Hide();
                        MessageBox.Show("Greetings Sire!");
                        LandingPage landingPage = new LandingPage();
                        landingPage.Show();
                        

                    }
                    else
                    {
                        MessageBox.Show("Invalid user or Password,Register");

                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
            }
            else
            {
                MessageBox.Show("Invalid User or Password");
                JournalView journalView = new JournalView();
                journalView.Show();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
    }
}
