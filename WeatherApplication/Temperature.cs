using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    /**
        Diese Klasse wurde erstellt, damit die Temperatur inklusive der weiteren 
        benötigten Daten in der Applikation gezeilt angezeigt werden kann.
     */
    public class Temperature
    {

        public string day { get; set; }

        public string temp { get; set; }

        public string description { get; set; }

        public Temperature() { }

        public Temperature(string day, string temp, string description)
        {
            this.day = day;
            this.temp = temp;
            this.description = description;
        }

    }
}
