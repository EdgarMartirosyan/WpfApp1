using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{

   /* public class Product
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public string Solar_noon { get; set; }
        public string Day_length { get; set; }
        public string Civil_twilight_begin { get; set; }
        public string Civil_twilight_end { get; set; }
        public string Nautical_twilight_begin { get; set; }
        public string Nautical_twilight_end { get; set; }
        public string Astronomical_twilight_begin { get; set; }
        public string Astronomical_twilight_end { get; set; }
    }

    public class RootObject
    {
        public Product Results { get; set; }
        public string Status { get; set; }
    }*/



     public class Product
     {
         public string Id { get; set; }
         public string Name { get; set; }
         public string Place { get; set; }
         public string Start { get; set; }
         public string Dur { get; set; }
         public string Link { get; set; }
     }

     public class RootObject
     {
         public bool Success { get; set; }
         public List<Product> Response { get; set; }
     }
}
