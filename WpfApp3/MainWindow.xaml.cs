using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

       private  void Loadinfo_Click(object sender, RoutedEventArgs e)
        {
            string URL = "https://www.contractor.de/api/?action=getJobsList&type=undefined&keyword";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            var answer = client.GetAsync(URL).Result;

            var JSON = answer.Content.ReadAsStringAsync().Result;

            var UVs = JsonConvert.DeserializeObject<RootObject>(JSON);

            this.datagrid1.ItemsSource = UVs.Response;

        }
    }
}
