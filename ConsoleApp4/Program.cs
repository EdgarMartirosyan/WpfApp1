using System;

namespace ConsoleApp4
{
    public class Invoce
    {
        public DateTime DV { get; set; }
        public static Invoce[] GetAllInvoces()
        {
            Invoce[] invoces = new Invoce[1];
            invoces[0] = new Invoce
            {
                DV = new DateTime(2019, 10, 08, 00, 00, 00, DateTimeKind.Local),
               
            };

            return invoces;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Invoce invoce = new Invoce();
           
            Console.WriteLine(invoce.DV);
            Console.WriteLine("Hello World!");
        }
    }
}
