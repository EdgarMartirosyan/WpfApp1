using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    class Invoce
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int TotalMark { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime DealDate { get; set; }
        public string DealNumber { get; set; }
        public string VATNumber { get; set; }



        public static Invoce[] GetAllInvoces()
        {
            Invoce[] invoces = new Invoce[1];
            invoces[0] = new Invoce {  DeliveryDate = new DateTime(2019, 10, 08), DealDate = new DateTime(2019, 01, 01), DealNumber = "00031904-ԱՊ", VATNumber= "00031904/1" };
            
            return invoces;
        }
    }
}
