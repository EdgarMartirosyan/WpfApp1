using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /*public class SunResultsModel
    {
        public SunModel Results { get; set; }
    }*/
    public class SunModel
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
        public SunModel Results { get; set; }
        public string Status { get; set; }
    }
}
