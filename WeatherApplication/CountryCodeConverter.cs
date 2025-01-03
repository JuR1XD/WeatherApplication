using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public class CountryCodeConverter
    {

        private Dictionary<string, string> countryNames;

        public CountryCodeConverter(string csvFilePath)
        {
            countryNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            LoadCountryDataFromCsv(csvFilePath);
        }

        private void LoadCountryDataFromCsv(string csvFilePath)
        {
            try
            {
                foreach (var line in File.ReadAllLines(csvFilePath))
                {
                    var values = line.Split(',');

                    if (values.Length == 2 && !string.Equals(values[0], "Country Code", StringComparison.OrdinalIgnoreCase))
                    {
                        string code = values[0].Trim();
                        string name = values[1].Trim();

                        if (!countryNames.ContainsKey(code))
                        {
                            countryNames[code] = name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Lesen der CSV-Datei: {ex.Message}");
            }
        }

        public string ConvertCountryCodeToName(string countryCode)
        {
            if (countryNames.TryGetValue(countryCode, out string countryName))
            {
                return countryName;
            }
            return $"Unbekannter Ländercode: {countryCode}";
        }
    }
}
