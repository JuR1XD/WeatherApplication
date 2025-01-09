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
    public partial class Form3 : Form
    {
        private string urlGeoCode = string.Empty;

        private string urlWeatherAPI = string.Empty;

        private string lat = string.Empty;

        private string lon = string.Empty;
        private Cities selectedCity { get; set; }

        int month = 0;

        DateTime d;

        HttpClient clientGeo = null;

        HttpResponseMessage messageGeo;

        HttpClient clientWeather;

        HttpResponseMessage messageWeather;

        CountryCodeConverter countryCodeConverter = new CountryCodeConverter("C:\\Users\\jur1xd\\AlfaTrainingC#\\Projektarbeit\\WeatherApp\\WeatherApplication\\WeatherApplication\\country_codes.csv");


        private string[] months = { "Januar", "Februar", "März", "April", "Mai",
            "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };


        public Form3()
        {
            InitializeComponent();
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

                //Geocode API URI
                urlGeoCode = "http://api.openweathermap.org/geo/1.0/direct?q=" + searchText.Text + "&limit=5&appid=9df7a899f8af39899299a6f6ac9ce26b";

                //Starting of the Geolocation API
                clientGeo = new HttpClient();
                messageGeo = await clientGeo.GetAsync(urlGeoCode);
                messageGeo.EnsureSuccessStatusCode();
                string responseBodyGeo = await messageGeo.Content.ReadAsStringAsync();
                JArray jsonObjectGeo = JArray.Parse(responseBodyGeo);

                var cities = jsonObjectGeo.Select(city => new Cities
                {
                    name = city.Value<string>("name"),
                    country = countryCodeConverter.ConvertCountryCodeToName(city.Value<string>("country")),
                    lat = city.Value<string>("lat"),
                    lon = city.Value<string>("lon"),
                    state = city.Value<string>("state") == null || city.Value<string>("state").Equals(string.Empty) ? "" : city.Value<string>("state")
                }).ToList();

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

                lbCities.DataSource = cities;

                //lbCities.ValueMember = "name + country";

                if (lbCities.Items.Count <= 0) throw new NoItemsInListBoxException("Es wurden keine Orte basierend auf Ihren Daten gefunden");

                lbCities.SelectedIndex = 0;

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
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }

        private async void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                try
                {
                    try
                    {
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



                    //Geocode API URI
                    urlGeoCode = "http://api.openweathermap.org/geo/1.0/direct?q=" + searchText.Text + "&limit=5&appid=9df7a899f8af39899299a6f6ac9ce26b";

                    //Starting of the Geolocation API
                    clientGeo = new HttpClient();
                    messageGeo = await clientGeo.GetAsync(urlGeoCode);
                    messageGeo.EnsureSuccessStatusCode();
                    string responseBodyGeo = await messageGeo.Content.ReadAsStringAsync();
                    JArray jsonObjectGeo = JArray.Parse(responseBodyGeo);

                    var cities = jsonObjectGeo.Select(city => new Cities
                    {
                        name = city.Value<string>("name"),
                        country = countryCodeConverter.ConvertCountryCodeToName(city.Value<string>("country")),
                        lat = city.Value<string>("lat"),
                        lon = city.Value<string>("lon"),
                        state = city.Value<string>("state") == null || city.Value<string>("state").Equals(string.Empty) ? "" : city.Value<string>("state")
                    }).ToList();

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

                    lbCities.DataSource = cities;

                    //lbCities.ValueMember = "name + country";

                    if (lbCities.Items.Count <= 0) throw new NoItemsInListBoxException("Es wurden keine Orte basierend auf Ihren Daten gefunden");

                    lbCities.SelectedIndex = 0;

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

            //JObject weatherData = (lbCities.SelectedItem as JObject);

            //lat = weatherData.SelectToken("lat").ToString();
            //lon = weatherData.SelectToken("lon").ToString();

            Cities city = (Cities)lbCities.SelectedItem;

            selectedCity = city;

            lat = city.lat;
            lon = city.lon;



            //string minuteBoxFormat = minuteBox.Text == "0" ? "00" : minuteBox.Text.Length < 2 ? "0" + minuteBox.Text : minuteBox.Text;

            //string hourBoxFormat = minuteBox.Text == "0" ? "00" : minuteBox.Text.Length < 2 ? "0" + minuteBox.Text : minuteBox.Text;

            placeAndTimeLabel.Text = $"Das Wetter in {city.name} am {d.ToString("dd.MM.yyy")} um {d.ToString("hh:mm")}";


            //Weather API URI
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall/timemachine?lat=" + lat + "&lon=" + lon + "&dt=" + ConvertToUnixTimestamp(d).ToString() + "&appid=9df7a899f8af39899299a6f6ac9ce26b&lang=de&units=metric";

            //Starting of the Weather API
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();
            //The Responsebody is sorrounded by [] because of the JSON Body structure
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            JToken jWeather = jsonObjectWeather[0]["data"];

            JToken jWeatherText = jWeather[0]["temp"];

            double temp = Convert.ToDouble(jWeatherText.ToString());

            temp = Math.Round(temp, 0, MidpointRounding.AwayFromZero);

            JToken jWeatherDescription = jWeather[0]["weather"];

            string jWeatherDescriptionText = jWeatherDescription[0]["description"].Value<string>();

            descriptionLabel.Text = jWeatherDescriptionText;

            tempLabel.Text = temp + " °C";


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

        public static long ConvertToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = dateTime - unixEpoch;
            return (long)timeSpan.TotalSeconds;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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
