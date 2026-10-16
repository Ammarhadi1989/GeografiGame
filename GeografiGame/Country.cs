using System;
using System.Collections.Generic;
using System.Text;

namespace GeografiGame
{
    internal class Country
    {
        public string country { get; set; }

        public string capitalEn { get; set; }

        public string capitalSwe { get; set; }

        // constructor

        public Country(string country, string capitalEn, string capitalSwe)
        {
            this.country = country;
            this.capitalEn = capitalEn;
            this.capitalSwe = capitalSwe;

        }
    }
}
