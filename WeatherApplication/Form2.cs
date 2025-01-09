using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApplication
{
    /**
    Form2: Wetter der nächsten 5 Tage anzeigen
    */
    public partial class Form2 : Form
    {

        //Deklarierung der benötigten Variablen für die API Calls
        string lat = string.Empty;
        string lon = string.Empty;
        string urlWeatherAPI = string.Empty;
        HttpClient clientWeather;
        HttpResponseMessage messageWeather;

        public Form2(Cities city)
        {
            InitializeComponent();

            //Einstellungen für die Objekte in der Form
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
            timeTimer.Enabled = true;
            timeTimer.Interval = 1000;
            lat = city.lat;
            lon = city.lon;
            placeLabel.Text = city.name;
        }

        //Methode für Timer verarbeitung
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            //Setzen der CultureInfo
            var culture = new CultureInfo("de-DE");

            //Weather API URL, welche die Werte lat, lon für die Korrekte erfassung des Ortes enthält
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall?lat=" + lat + "&lon=" + lon + "&appid=9df7a899f8af39899299a6f6ac9ce26b&units=metric&lang=de&exclude=minutely";

            //Die Weather API wird gestartet
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();

            //Der Responsebody ist mit eckigen Klammern umhüllt wegen der Struktur
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            //Die werte werden aus der JSON Datei gelesen und angewendet
            JToken jWeather = jsonObjectWeather[0]["daily"];
            List<Temperature> weatherList = new List<Temperature>();

            //Es werden die Werte für die nächsten 5 Tage gelooped und ausgegeben
            for (int i = 0; i < 5; i++)
            {
                JToken jWeatherText = jWeather[i];

                string dateText = jWeatherText.SelectToken("dt").Value<string>();

                string date = culture.DateTimeFormat.GetDayName(DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(dateText)).DayOfWeek);

                JToken temp = jWeather[i]["temp"];

                double tempForDay = temp.SelectToken("day").Value<double>();

                double tempForNight = temp.SelectToken("night").Value<double>();

                tempForDay = Math.Round(tempForDay, 0, MidpointRounding.AwayFromZero);

                tempForNight = Math.Round(tempForNight, 0, MidpointRounding.AwayFromZero);

                string allTemp = $"{tempForDay} °C\n{tempForNight} °C";

                JArray weatherDescription = JArray.Parse(jWeatherText.SelectToken("weather").ToString());

                JToken descriptionToken = weatherDescription[0]["description"];

                string description = descriptionToken.ToString();

                Temperature temperature = new Temperature(date, allTemp, description);

                weatherList.Add(temperature);
            }

            //Setzt die Tage in den Labels
            day1Label.Text = weatherList[0].day;
            day2Label.Text = weatherList[1].day;
            day3Label.Text = weatherList[2].day;
            day4Label.Text = weatherList[3].day;
            day5Label.Text = weatherList[4].day;

            //Setzt die Temperatur
            tempDay1Label.Text = weatherList[0].temp;
            tempDay2Label.Text = weatherList[1].temp;
            tempDay3Label.Text = weatherList[2].temp;
            tempDay4Label.Text = weatherList[3].temp;
            tempDay5Label.Text = weatherList[4].temp;

            //Setzt die Wetterbeschreibung
            descriptionDay1Label.Text = weatherList[0].description;
            descriptionDay2Label.Text = weatherList[1].description;
            descriptionDay3Label.Text = weatherList[2].description;
            descriptionDay4Label.Text = weatherList[3].description;
            descriptionDay5Label.Text = weatherList[4].description;

        }

        //Beenden des Fensters
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
