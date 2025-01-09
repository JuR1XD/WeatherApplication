using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApplication
{
    /**
     Klasse für die Konvertierung der sog. Country Codes in die Deutschen Ländernamen
     */
    public class CountryCodeConverter
    {
        private Dictionary<string, string> countryNames;

        public CountryCodeConverter(string csvUrl)
        {
            countryNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            LoadCountryDataFromUrlAsync(csvUrl);
        }

        public async Task LoadCountryDataFromUrlAsync(string csvUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string csvData = await client.GetStringAsync(csvUrl);
                    ProcessCsvData(csvData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Herunterladen der CSV-Datei: {ex.Message}");
            }
        }

        private void ProcessCsvData(string csvData)
        {
            using (StringReader reader = new StringReader(csvData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
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