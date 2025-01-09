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
    public partial class Form2 : Form
    {
        string lat = string.Empty;

        string lon = string.Empty;

        string urlWeatherAPI = string.Empty;

        HttpClient clientWeather;

        HttpResponseMessage messageWeather;

        public Form2(Cities city)
        {
            InitializeComponent();
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
            timeTimer.Enabled = true;
            timeTimer.Interval = 1000;
            DateTime today = DateTime.Now;
            lat = city.lat;
            lon = city.lon;
            placeLabel.Text = city.name;
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentDateLbl.Text = System.DateTime.Now.ToString("dddd") + "\n" + DateTime.Now.ToString();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            var culture = new CultureInfo("de-DE");

            //Weather API URI
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall?lat=" + lat + "&lon=" + lon + "&appid=9df7a899f8af39899299a6f6ac9ce26b&units=metric&lang=de&exclude=minutely";

            //Starting of the Weather API
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();
            //The Responsebody is sorrounded by [] because of the JSON Body structure
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            JToken jWeather = jsonObjectWeather[0]["daily"];

            List<Temperature> weatherList = new List<Temperature>();

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

            //Set days in the labels
            day1Label.Text = weatherList[0].day;
            day2Label.Text = weatherList[1].day;
            day3Label.Text = weatherList[2].day;
            day4Label.Text = weatherList[3].day;
            day5Label.Text = weatherList[4].day;

            //Set temperatures
            tempDay1Label.Text = weatherList[0].temp;
            tempDay2Label.Text = weatherList[1].temp;
            tempDay3Label.Text = weatherList[2].temp;
            tempDay4Label.Text = weatherList[3].temp;
            tempDay5Label.Text = weatherList[4].temp;

            //Set descriptions
            descriptionDay1Label.Text = weatherList[0].description;
            descriptionDay2Label.Text = weatherList[1].description;
            descriptionDay3Label.Text = weatherList[2].description;
            descriptionDay4Label.Text = weatherList[3].description;
            descriptionDay5Label.Text = weatherList[4].description;

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
