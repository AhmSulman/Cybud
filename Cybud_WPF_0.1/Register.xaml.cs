using DocumentFormat.OpenXml.Bibliography;
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
using System.Windows.Shapes;

namespace Cybud_WPF_0._1
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public string json_dat = "json_dat.json";
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = Email_Register.Text.ToString();
                string password = Password_Register.Password.ToString();

                Dictionary<string,string> e_p = new Dictionary<string,string>();
                e_p.Add(email, password);
                

                var json_serialization = JsonConvert.SerializeObject(e_p);
                
                if (File.Exists(json_dat))
                {
                    File.AppendAllText(json_dat, json_serialization);
                    MessageBox.Show("Registered!");
                }
                else
                {
                    File.WriteAllText(json_dat,json_serialization);
                    MessageBox.Show("Registered!");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void SignIn_Register_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
