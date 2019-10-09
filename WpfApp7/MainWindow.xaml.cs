using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfApp7
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

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                txtFilePath.Text = openfile.FileName;

                Excel.Application excelApp = new Excel.Application();
                //Static File From Base Path...........
                //Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //Dynamic File Using Uploader...........
                Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath.Text.ToString(), 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet excelSheet = (Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                Excel.Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Excel.Range).Value2;
                    dt.Columns.Add(strColumn, typeof(string));
                }

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Excel.Range).Value2;
                            strData += strCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

                dtGrid.ItemsSource = dt.DefaultView;

                excelBook.Close(true, null, null);
                excelApp.Quit();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {

            /*  var xmlWriter = new XmlTextWriter(@"C:\Users\edgar.martirosyan\Desktop\testing\bookstwo.xml", null);

              xmlWriter.WriteStartDocument();                  // Заголовок XML - <?xml version="1.0"?>
              xmlWriter.WriteStartElement("ListOfBooks");      // Корневой элемент - <ListOfBooks>
              xmlWriter.WriteStartElement("Book");             // Книга 1 - <Book
              xmlWriter.WriteStartAttribute("FontSize");       // Атрибут - FontSize
              xmlWriter.WriteString("8");
              //  xmlWriter.WriteString("18");   // ="8"
              xmlWriter.WriteEndAttribute();                   // >
              xmlWriter.WriteString("Title-1");                // Title-1
              xmlWriter.WriteEndElement();                     // </Book>
              xmlWriter.WriteEndElement();                     // </ListOfBooks>

              xmlWriter.Close();*/
            XmlDocCreater();

           
        }

        public static void XmlDocCreater()
        {
            /* XDocument xmlDocument = new XDocument(
                 new XDeclaration("1.0", "utf-8", "yes"),
                 new XComment("Creating xml tree using linq to xml"),
                 new XElement("Students",
                 from invoce in Invoce.GetAllInvoces()
                 select new XElement("Student", new XAttribute("Id",invoce.Id),
                  new XElement("Name",invoce.Name),
                  new XElement("Gender",invoce.Gender),
                  new XElement("TotalMark",invoce.TotalMark)
                 )));*/
         XDocument xmlDocument = new XDocument(
         new XDeclaration("1.0", "utf-8", "yes"),

           //  new XElement("ExportedAccDocData", new XAttribute("xmlns","http://www.taxservice.am/tp3/invoice/definitions"),
           new XElement("AccountingDocument", new XAttribute("Version", "1.0"),
           new XElement("Type", 3),
           new XElement("GeneralInfo",
                new XElement("EcrReceipt"),
                from invoce in Invoce.GetAllInvoces()
                select new XElement("DeliveryDate", invoce.DeliveryDate),
                     new XElement("Procedure", 1),
                     new XElement("DealInfo",
                        from invoceo in Invoce.GetAllInvoces()
                        select new XElement("DealDate", invoceo.DealDate),
                        from invoceo in Invoce.GetAllInvoces()
                        select new XElement("DealNumber", invoceo.DealNumber)),
                        new XElement("AdditionalData")),
           new XElement("SupplierInfo",
               from invocet in Invoce.GetAllInvoces()
               select new XElement("VATNumber", invocet.VATNumber),
               new XElement("Taxpayer",
                   new XElement("TIN", "00031904"),
                   new XElement("Name", "ՆԱԻՐԻ ԻՆՇՈՒՐԱՆՍ ԱՊԱՀՈՎԱԳՐԱԿԱՆ Սահմանափակ պատասխանատվությամբ ընկերություն (ՍՊԸ)"),
                   new XElement("Address", "ԵՐԵՎԱՆ ԿԵՆՏՐՈՆ ԿԵՆՏՐՈՆ ԹԱՂԱՄԱՍ Վ.Սարգսյան 10 110տար"),
                   new XElement("BankAccount",
                       new XElement("BankName", "Ամերիաբանկ ՓԲԸ"), 
                       new XElement("BankAccountNumber", "1570001164650300"))))
            ));
            xmlDocument.Save(@"C:\Users\edgar.martirosyan\Desktop\testing\booksfree.xml");
        }


    }
}

