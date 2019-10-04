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
using Excel=Microsoft.Office.Interop.Excel;

namespace WpfApp6
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

        public void OpenFile()
        {
            var ExcelApp = new Excel.Application();
            ExcelApp.Visible = true;

            Excel.Workbooks books = ExcelApp.Workbooks;
            Excel.Workbook sheets = books.Open(@"C:\Users\edgar.martirosyan\Desktop\csharptest\Example.xls");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
    }
}
