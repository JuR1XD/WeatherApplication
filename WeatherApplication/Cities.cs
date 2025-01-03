﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class Cities
    {

        public string name { get; set; }
        public string country { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }


        public override string ToString()
        {
            return $"{name}, Land: {country}";
        }

    }
}
