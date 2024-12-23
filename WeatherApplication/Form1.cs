using Newtonsoft.Json.Linq;

namespace WeatherApplication
{
    public partial class Form1 : Form
    {
        /*
        Farbcodes:
        Schrift: #D2DBE5
        Hintergrund: 30; 71; 124
         */
        //Declaring and Initializing Variables
        private string urlGeoCode = string.Empty;

        private string urlWeatherAPI = string.Empty;

        HttpClient clientGeo = null;

        HttpResponseMessage messageGeo;

        HttpClient clientWeather;

        HttpResponseMessage messageWeather;

        string lat = string.Empty;

        string lon = string.Empty;

        private List<String> cities { get; set; } = new();

        public Form1()
        {
            InitializeComponent();
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            lbCities.MultiColumn = false;
            placeLabel.Visible = false;
            tempCurrentLabel.Visible = false;
            descriptionLabel.Visible = false;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //Geocode API URI
                urlGeoCode = "http://api.openweathermap.org/geo/1.0/direct?q=" + searchText.Text + "&limit=5&appid=9df7a899f8af39899299a6f6ac9ce26b";

                //Starting of the Geolocation API
                clientGeo = new HttpClient();
                messageGeo = await clientGeo.GetAsync(urlGeoCode);
                messageGeo.EnsureSuccessStatusCode();
                string responseBodyGeo = await messageGeo.Content.ReadAsStringAsync();
                JArray jsonObjectGeo = JArray.Parse(responseBodyGeo);



                for (int i = 0; i < jsonObjectGeo.Count; i++)
                {
                    lbCities.Items.Add(jsonObjectGeo[i]);
                }

                lbCities.ValueMember = "name";

                if (lbCities.Items.Count <= 0) throw new NoItemsInListBoxException("Es wurden keine Länder basierend auf Ihren Daten");

                searchBtn.Visible = false;
                searchText.Visible = false;
                lbCities.Visible = true;
                confirmBtn.Visible = true;
                denyBtn.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Das gesuchte Land konnte nicht gefunden werden\n\n{ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<String> getCities()
        {
            return this.cities;
        }

        private void denyBtn_Click(object sender, EventArgs e)
        {
            lbCities.Items.Clear();
            searchText.Text = string.Empty;
            searchText.Visible = true;
            searchBtn.Visible = true;
            lbCities.Visible = false;
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
        }

        private async void confirmBtn_Click(object sender, EventArgs e)
        {

            JObject weatherData = (lbCities.SelectedItem as JObject);

            lat = weatherData.SelectToken("lat").ToString();
            lon = weatherData.SelectToken("lon").ToString();

            placeLabel.Text = weatherData.SelectToken("name").ToString() + ":";

            //Weather API URI
            urlWeatherAPI = "https://api.openweathermap.org/data/3.0/onecall?lat=" + lat + "&lon=" + lon + "&appid=9df7a899f8af39899299a6f6ac9ce26b&units=metric&lang=de&exclude=minutely";

            //Starting of the Weather API
            clientWeather = new HttpClient();
            messageWeather = await clientWeather.GetAsync(urlWeatherAPI);
            messageWeather.EnsureSuccessStatusCode();
            //The Responsebody is sorrounded by [] because of the JSON Body structure
            string responseBodyWeather = "[" + await messageWeather.Content.ReadAsStringAsync() + "]";
            JArray jsonObjectWeather = JArray.Parse(responseBodyWeather);

            JToken jWeather = jsonObjectWeather[0]["current"];

            JToken jWeatherText = jWeather.SelectToken("weather");

            double temp = Convert.ToDouble(jWeather.SelectToken("temp").ToString());

            temp = Math.Round(temp, 0, MidpointRounding.AwayFromZero);

            tempCurrentLabel.Text = temp + " °C";

            descriptionLabel.Text = jWeatherText[0]["description"].ToString();

            lbCities.Visible = false;
            lbCities.Items.Clear();
            confirmBtn.Visible = false;
            denyBtn.Visible = false;
            placeLabel.Visible = true;
            tempCurrentLabel.Visible = true;
            descriptionLabel.Visible = true;

        }
    }
}
