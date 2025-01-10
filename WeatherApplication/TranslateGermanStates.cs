using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class TranslateGermanStates
    {

        public TranslateGermanStates() { }

        public void translate(List<Cities> cities)
        {
            foreach (Cities c in cities)
            {
                switch (c.state)
                {
                    case "Hesse":
                        c.state = "Hessen";
                        break;

                    case "Thuringia":
                        c.state = "Thüringen";
                        break;

                    case "Saxony":
                        c.state = "Sachsen";
                        break;

                    case "Rhineland-Palatinate":
                        c.state = "Rheinland Pfalz";
                        break;

                    case "Saxony-Anhalt":
                        c.state = "Sachsen Anhalt";
                        break;

                    case "Mecklenburg Western Pomerania":
                        c.state = "Mecklenburg Vorpommern";
                        break;

                    case "North Rhine-Westphalia":
                        c.state = "Nordrhein-Westfalen";
                        break;

                    case "Lower Saxony":
                        c.state = "Niedersachsen";
                        break;

                    case "Bavaria":
                        c.state = "Bayern";
                        break;
                }
            }
        }

    }
}
