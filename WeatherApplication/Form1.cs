using Newtonsoft.Json.Linq;

namespace WeatherApplication
{
    /**
    Form1: Derzeitiges Wetter anzeigen
    */
    public partial class Form1 : Form
    {
        /*
        Farbcodes:
        Schrift: #D2DBE5
        Hintergrund: 30; 71; 124
         */
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

        //Deklarierung und Initialisierung der Klasse für die Konvertierung der Länder Codes und der Übersetzung der Bundesländer
        CountryCodeConverter countryCodeConverter = new CountryCodeConverter("https://raw.githubusercontent.com/JuR1XD/countryCodes/refs/heads/main/country_codes.csv");

        TranslateGermanStates ts = new TranslateGermanStates();


        public Form1()
        {
            //Einstellungen für die Objekte in der Form
            InitializeComponent();
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            lbCities.MultiColumn = false;
            placeLabel.Visible = false;
            tempCurrentLabel.Visible = false;
            descriptionLabel.Visible = false;
            weekViewBtn.Visible = false;
            newSearchBtn.Visible = false;
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
            timeTimer.Enabled = true;
            timeTimer.Interval = 1000;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
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

                ts.translate(cities);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der gesuchte Ort konnte nicht gefunden werden", "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                try
                {
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

                    ts.translate(cities);

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
                    pastWeatherBtn.Visible = false;
                    lbCities.Visible = true;
                    confirmBtn.Visible = true;
                    denyBtn.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Der gesuchte Ort konnte nicht gefunden werden", "FEHLER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void denyBtn_Click(object sender, EventArgs e)
        {
            searchText.Text = string.Empty;
            searchText.Visible = true;
            searchBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
        }

        private async void confirmBtn_Click(object sender, EventArgs e)
        {
            //Setzen der benötigten Variablen
            Cities city = (Cities)lbCities.SelectedItem;
            selectedCity = city;
            lat = city.lat;
            lon = city.lon;

            placeLabel.Text = city.name + ":";

            //Weather API URL, welche die Werte lat, lon für die Korrekte erfassung  des Ortes enthält
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall?lat=" + lat + "&lon=" + lon + "&appid=9df7a899f8af39899299a6f6ac9ce26b&units=metric&lang=de&exclude=minutely";

            //Die Weather API wird gestartet
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();

            //Der Responsebody ist mit eckigen Klammern umhüllt wegen der Struktur
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            //Die werte werden aus der JSON Datei gelesen und angewendet
            JToken jWeather = jsonObjectWeather[0]["current"];
            JToken jWeatherText = jWeather.SelectToken("weather");

            double temp = Convert.ToDouble(jWeather.SelectToken("temp").ToString());
            temp = Math.Round(temp, 0, MidpointRounding.AwayFromZero);

            //Die Label bekommen den entsprechenden Text
            tempCurrentLabel.Text = temp + " °C";
            descriptionLabel.Text = jWeatherText[0]["description"].ToString();

            //Die Forms Objekte werden entsprechen verändert
            weekViewBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            placeLabel.Visible = true;
            tempCurrentLabel.Visible = true;
            descriptionLabel.Visible = true;
            newSearchBtn.Visible = true;

        }

        //Die Werte werden zurückgesetzt und eine neue SUche kann begonnen werden
        private void newSearchBtn_Click(object sender, EventArgs e)
        {
            searchText.Text = string.Empty;
            searchText.Visible = true;
            searchBtn.Visible = true;
            pastWeatherBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            placeLabel.Visible = false;
            tempCurrentLabel.Visible = false;
            descriptionLabel.Visible = false;
            newSearchBtn.Visible = false;
            weekViewBtn.Visible = false;
        }

        //Wechsel zur Wochenansicht
        private void weekViewBtn_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(selectedCity);
            f.Visible = true;
        }

        //Methode für Timer verarbeitung
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }

        //Wechsel zur Vergangenen Wetteransicht
        private void pastWeatherBtn_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Visible = true;
        }
    }
}
