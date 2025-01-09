using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApplication
{
    /**
     Form3: Wetter in der Vergangenheit anzeigen
     */
    public partial class Form3 : Form
    {

        //Deklarierung der benötigten Variablen für die API Calls
        private string urlGeoCode = string.Empty;
        private string urlWeatherAPI = string.Empty;
        private string lat = string.Empty;
        private string lon = string.Empty;
        private Cities selectedCity { get; set; }
        HttpClient clientGeo = null;
        HttpResponseMessage messageGeo;
        HttpClient clientWeather;
        HttpResponseMessage messageWeather;

        //Deklarierung der Variablen für die Abfrage des Datums
        int month = 0;
        DateTime d;
        private string[] months = { "Januar", "Februar", "März", "April", "Mai",
            "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };

        //Deklarierung der Klasse für die Konvertierung der Länder Codes        
        CountryCodeConverter countryCodeConverter = new CountryCodeConverter("https://raw.githubusercontent.com/JuR1XD/countryCodes/refs/heads/main/country_codes.csv");


        public Form3()
        {
            InitializeComponent();

            //Setzen der Daten für die ComboBoxen
            for (int i = 0; i < 31; i++)
            {
                dayBox.Items.Add(i + 1);
            }
            for (int i = 0; i < 12; i++)
            {
                monthBox.Items.Add(months[i]);
            }
            for (int i = 1979; i <= DateTime.Now.Year; i++)
            {
                yearBox.Items.Add(i);
            }
            for (int i = 0; i < 24; i++)
            {
                hourBox.Items.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                minuteBox.Items.Add(i);
            }
            dayBox.SelectedIndex = 0;
            monthBox.SelectedIndex = 0;
            yearBox.SelectedIndex = yearBox.Items.Count - 1;
            hourBox.SelectedIndex = hourBox.Items.Count - 12;
            minuteBox.SelectedIndex = 0;

            //Einstellungen für die Objekte in der Form
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            lbCities.MultiColumn = false;
            weatherLabel.Visible = false;
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
            timeTimer.Enabled = true;
            timeTimer.Interval = 1000;
            newSearchBtn.Visible = false;
            descriptionLabel.Visible = false;
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    //Korrekte Übergabe des Datums
                    switch (monthBox.Text)
                    {
                        case "Januar": month = 1; break;
                        case "Februar": month = 2; break;
                        case "März": month = 3; break;
                        case "April": month = 4; break;
                        case "Mai": month = 5; break;
                        case "Juni": month = 6; break;
                        case "Juli": month = 7; break;
                        case "August": month = 8; break;
                        case "September": month = 9; break;
                        case "Oktober": month = 10; break;
                        case "November": month = 11; break;
                        case "Dezember": month = 12; break;
                    }

                    d = new DateTime(Convert.ToInt32(yearBox.SelectedItem.ToString()), month, Convert.ToInt32(dayBox.SelectedItem.ToString()), Convert.ToInt32(hourBox.SelectedItem.ToString()), Convert.ToInt32(minuteBox.SelectedItem.ToString()), 0);

                }
                catch (IncorrectDateFormatException ex)
                {
                    MessageBox.Show(ex.Message, "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (DateTime.Now < d)
                {
                    throw new Exception("Das eingegebene Datum ist in der Zukunft");
                }

                //Geocode API URL, welche den Text aus dem suchfeld enthält
                urlGeoCode = "http://api.openweathermap.org/geo/1.0/direct?q=" + searchText.Text + "&limit=5&appid=9df7a899f8af39899299a6f6ac9ce26b";

                //Geolocation API wird gestartet
                clientGeo = new HttpClient();
                messageGeo = await clientGeo.GetAsync(urlGeoCode);
                messageGeo.EnsureSuccessStatusCode();
                string responseBodyGeo = await messageGeo.Content.ReadAsStringAsync();
                JArray jsonObjectGeo = JArray.Parse(responseBodyGeo);

                //Sammeln einiger Ausgaben aus dem API Call in eine Liste 
                var cities = jsonObjectGeo.Select(city => new Cities
                {
                    name = city.Value<string>("name"),
                    country = countryCodeConverter.ConvertCountryCodeToName(city.Value<string>("country")),
                    lat = city.Value<string>("lat"),
                    lon = city.Value<string>("lon"),
                    state = city.Value<string>("state") == null || city.Value<string>("state").Equals(string.Empty) ? "" : city.Value<string>("state")
                }).ToList();

                //Suche nach doppelten Städten mit den gleichen Daten
                string nameCompare = string.Empty;
                string stateCompare = string.Empty;
                string countryCompare = string.Empty;

                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities.Count > 1 && i > 0)
                    {
                        if (cities[i].name.Equals(cities[i - 1].name) && cities[i].state.Equals(cities[i - 1].state) && cities[i].country.Equals(cities[i - 1].country))
                        {
                            cities.Remove(cities[i]);
                        }
                    }
                }

                //Zuweisen der restlichen Städte auf die ListBox
                lbCities.DataSource = cities;

                if (lbCities.Items.Count <= 0) throw new NoItemsInListBoxException("Es wurden keine Orte basierend auf Ihren Daten gefunden");

                lbCities.SelectedIndex = 0;

                //Nach erfolgreicher Verarbeitung werden die Forms Felder entsprechend verändert
                searchBtn.Visible = false;
                searchText.Visible = false;
                lbCities.Visible = true;
                confirmBtn.Visible = true;
                denyBtn.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                dayBox.Visible = false;
                monthBox.Visible = false;
                yearBox.Visible = false;
                hourBox.Visible = false;
                minuteBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der gesuchte Ort konnte nicht gefunden werden", "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Methode für Timer verarbeitung
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }


        private async void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            //Abfrage auf ENTER Key
            if (e.KeyCode == Keys.Enter)
            {
                //Verhindern eines Windows Aktion Sounds nach dem Betätigen der Taste
                e.Handled = true;
                e.SuppressKeyPress = true;

                try
                {
                    try
                    {
                        //Korrekte Übergabe des Datums
                        switch (monthBox.Text)
                        {
                            case "Januar": month = 1; break;
                            case "Februar": month = 2; break;
                            case "März": month = 3; break;
                            case "April": month = 4; break;
                            case "Mai": month = 5; break;
                            case "Juni": month = 6; break;
                            case "Juli": month = 7; break;
                            case "August": month = 8; break;
                            case "September": month = 9; break;
                            case "Oktober": month = 10; break;
                            case "November": month = 11; break;
                            case "Dezember": month = 12; break;
                        }

                        d = new DateTime(Convert.ToInt32(yearBox.SelectedItem.ToString()), month, Convert.ToInt32(dayBox.SelectedItem.ToString()), Convert.ToInt32(hourBox.SelectedItem.ToString()), Convert.ToInt32(minuteBox.SelectedItem.ToString()), 0);

                        if(d >  DateTime.Now)
                        {
                            throw new IncorrectDateFormatException();
                        }
                    }
                    catch (IncorrectDateFormatException ex)
                    {
                        MessageBox.Show(ex.Message, "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                    //Geocode API URL, welche den Text aus dem suchfeld enthält
                    urlGeoCode = "http://api.openweathermap.org/geo/1.0/direct?q=" + searchText.Text + "&limit=5&appid=9df7a899f8af39899299a6f6ac9ce26b";

                    //Geolocation API wird gestartet
                    clientGeo = new HttpClient();
                    messageGeo = await clientGeo.GetAsync(urlGeoCode);
                    messageGeo.EnsureSuccessStatusCode();
                    string responseBodyGeo = await messageGeo.Content.ReadAsStringAsync();
                    JArray jsonObjectGeo = JArray.Parse(responseBodyGeo);

                    //Sammeln einiger Ausgaben aus dem API Call in eine Liste 
                    var cities = jsonObjectGeo.Select(city => new Cities
                    {
                        name = city.Value<string>("name"),
                        country = countryCodeConverter.ConvertCountryCodeToName(city.Value<string>("country")),
                        lat = city.Value<string>("lat"),
                        lon = city.Value<string>("lon"),
                        state = city.Value<string>("state") == null || city.Value<string>("state").Equals(string.Empty) ? "" : city.Value<string>("state")
                    }).ToList();

                    //Suche nach doppelten Städten mit den gleichen Daten
                    string nameCompare = string.Empty;
                    string stateCompare = string.Empty;
                    string countryCompare = string.Empty;

                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (cities.Count > 1 && i > 0)
                        {
                            if (cities[i].name.Equals(cities[i - 1].name) && cities[i].state.Equals(cities[i - 1].state) && cities[i].country.Equals(cities[i - 1].country))
                            {
                                cities.Remove(cities[i]);
                            }
                        }
                    }
                    //Zuweisen der restlichen Städte auf die ListBox
                    lbCities.DataSource = cities;

                    if (lbCities.Items.Count <= 0) throw new NoItemsInListBoxException("Es wurden keine Orte basierend auf Ihren Daten gefunden");
                    lbCities.SelectedIndex = 0;

                    //Nach erfolgreicher Verarbeitung werden die Forms Felder entsprechend verändert
                    searchBtn.Visible = false;
                    searchText.Visible = false;
                    lbCities.Visible = true;
                    confirmBtn.Visible = true;
                    denyBtn.Visible = true;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    dayBox.Visible = false;
                    monthBox.Visible = false;
                    yearBox.Visible = false;
                    hourBox.Visible = false;
                    minuteBox.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Der gesuchte Ort konnte nicht gefunden werden", "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void confirmBtn_Click(object sender, EventArgs e)
        {
            //Setzen der benötigten Variablen
            Cities city = (Cities)lbCities.SelectedItem;
            selectedCity = city;
            lat = city.lat;
            lon = city.lon;

            //Setzen der Zeitwerte in das Label
            placeAndTimeLabel.Text = $"Das Wetter in {city.name} am {d.ToString("dd.MM.yyy")} um {d.ToString("HH:mm")}";


            //Weather API URL, welche die Werte lat, lon und die Methode ConvertToUnixTimeStamp für die Korrekte erfassung der Zeit und des Ortes enthält
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall/timemachine?lat=" + lat + "&lon=" + lon + "&dt=" + ConvertToUnixTimestamp(d).ToString() + "&appid=9df7a899f8af39899299a6f6ac9ce26b&lang=de&units=metric";

            //Die Weather API wird gestartet
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();

            //Der Responsebody ist mit eckigen Klammern umhüllt wegen der Struktur
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            //Die werte werden aus der JSON Datei gelesen und angewendet
            JToken jWeather = jsonObjectWeather[0]["data"];
            JToken jWeatherText = jWeather[0]["temp"];

            double temp = Convert.ToDouble(jWeatherText.ToString());
            temp = Math.Round(temp, 0, MidpointRounding.AwayFromZero);

            JToken jWeatherDescription = jWeather[0]["weather"];
            string jWeatherDescriptionText = jWeatherDescription[0]["description"].Value<string>();

            //Die Label bekommen den entsprechenden Text
            descriptionLabel.Text = jWeatherDescriptionText;
            tempLabel.Text = temp + " °C";

            //Die Forms Objekte werden entsprechen verändert
            descriptionLabel.Visible = true;
            tempLabel.Visible = true;
            placeAndTimeLabel.Visible = true;
            newSearchBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            weatherLabel.Visible = true;
            searchText.Text = string.Empty;
            searchText.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            dayBox.Visible = true;
            monthBox.Visible = true;
            yearBox.Visible = true;
            hourBox.Visible = true;
            minuteBox.Visible = true;
        }

        private void denyBtn_Click(object sender, EventArgs e)
        {
            //Die Forms Objekte werden entsprechen verändert
            searchText.Text = string.Empty;
            searchText.Visible = true;
            searchBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            dayBox.Visible = false;
            monthBox.Visible = false;
            yearBox.Visible = false;
            hourBox.Visible = false;
            minuteBox.Visible = false;
        }

        //Methode zum Umwandeln des Objekts DateTime in einen Unix Timestamp
        public static long ConvertToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = dateTime - unixEpoch;
            return (long)timeSpan.TotalSeconds;
        }

        //Beenden des Fensters
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //Die Werte werden zurückgesetzt und eine neue SUche kann begonnen werden
        private void newSearchBtn_Click(object sender, EventArgs e)
        {
            dayBox.SelectedIndex = 0;
            monthBox.SelectedIndex = 0;
            yearBox.SelectedIndex = yearBox.Items.Count - 1;
            hourBox.SelectedIndex = hourBox.Items.Count - 12;
            minuteBox.SelectedIndex = 0;
            searchText.Text = string.Empty;
            searchText.Visible = true;
            searchBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            newSearchBtn.Visible = false;
            weatherLabel.Visible = false;
            tempLabel.Visible = false;
            placeAndTimeLabel.Visible = false;
            descriptionLabel.Visible = false;
        }
    }
}
