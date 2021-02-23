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
using ViaDeliveryLib;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client _client;
        private string _settingsFolder = @"C:\CS\viadelivery_settings\";
        public MainWindow()
        {
            InitializeComponent();
            progress1.Visibility = Visibility.Hidden;
            try
            {
                CreateClient();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async Task Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            var countries = await _client.GetCountriesAsync();
        }

        void CreateClient()
        {
            var shopId = App("ShopId");
            if (string.IsNullOrWhiteSpace(shopId))
            {
                throw new Exception("ctor MainWindow error: shopId is empty");
            }
            var securityToken = App("SecurityToken");
            if (string.IsNullOrWhiteSpace(securityToken))
            {
                throw new Exception("ctor MainWindow error: securityToken is empty");
            }
            var apiUrl = App("ApiUrl");
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                throw new Exception("ctor MainWindow error: apiUrl is empty");
            }
            _client = new Client(shopId, securityToken, apiUrl);
        }

        string App(string key)
        {
            return ReadFile(System.IO.Path.Combine(_settingsFolder, key + ".txt"));
        }

        string ReadFile(string file)
        {
            try
            {
                return System.IO.File.ReadAllText(file);
            }
            catch
            {
                return string.Empty;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            progress1.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            var response = await _client.GetCountriesAsync();
            if(response != null && string.Equals(response.Status,"OK", StringComparison.OrdinalIgnoreCase))
            {
                richText1.AppendText("service return " + response.Data.Count() + " countries");
            }
            else
            {
                richText1.AppendText("error get data from web-service");
            }
            
            progress1.Visibility = Visibility.Hidden;
        }

         
    }
}
