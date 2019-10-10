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
        public string TIN { get; set; }
        public string BuyerBankName { get; set; }
        public string BuyerBankAccountNumber { get; set; }
        public string GoodDescription { get; set; }
        public double GoodAmount { get; set; }
        public double PricePerUnit { get; set; }        
        public double Price { get; set; }
       




        public static Invoce[] GetAllInvoces()
        {
            Invoce[] invoces = new Invoce[1];
            invoces[0] = new Invoce
            {
                DeliveryDate = new DateTime(2019, 10, 08,04,00,00),
                DealDate = new DateTime(2019, 01, 01,04,00,00),
                DealNumber = "00031904-ԱՊ",
                VATNumber = "00031904/1",
                TIN = "02507171",
                BuyerBankName = "ՀՀ ՖՆ Աշխատակազմի գործառնական վարչություն",
                BuyerBankAccountNumber = "900011001931",
                GoodDescription = "Ապահովագրավճար համաձայն արձանագրություն 8, առ 30.09.2019թ.",
                GoodAmount = 1,
                PricePerUnit = 46558888,
                Price= 46558888
            };

            return invoces;
        }
    }
}
