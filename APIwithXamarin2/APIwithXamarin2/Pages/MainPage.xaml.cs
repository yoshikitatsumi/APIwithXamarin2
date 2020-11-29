using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APIwithXamarin2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        CovidAPI CAPI;
        Label data = new Label();
        Label message = new Label();
        Entry country = new Entry();
        Label deaths = new Label();
        Label recovered = new Label();
        Label confirmed = new Label();

        public MainPage()
        {
            InitializeComponent();

            CAPI = new CovidAPI();

            //Message and button as btnData.

            // Color line.
            BoxView BoxLine = new BoxView
            {

                Color = Color.DarkGreen

            };

            // Welcome message
            Label message = new Label
            {
                Text = "Welcome to Covid-19 Data!",
                TextColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 25
            };

            // Color line.
            BoxView BoxLine2 = new BoxView
            {

                Color = Color.DarkGreen

            };

            //  Data button as btnData
            Button btnData = new Button
            {
                Text = "Show original data!",
                FontSize = 25,
                TextColor = Color.Cyan
            };
            btnData.Clicked += BtnData_Clicked;

            //  Data button as btnData
            Button btnDeaths = new Button
            {
                Text = "Deaths",
                FontSize = 25,
                TextColor = Color.Red
            };
            btnDeaths.Clicked += BtnDeaths_Clicked;

            //  Data button as btnData
            Button btnRecovered = new Button
            {
                Text = "Recovered",
                FontSize = 25,
                TextColor = Color.Blue
            };
            btnRecovered.Clicked += BtnRecovered_Clicked;

            //  Data button as btnData
            Button btnConfirmed = new Button
            {
                Text = "Confirmed",
                FontSize = 25,
                TextColor = Color.Green
            };
            btnConfirmed.Clicked += BtnConfirmed_Clicked;


            Content = new StackLayout
            {
                Children =
                {
                    BoxLine,
                    message,
                    BoxLine2,
                    country,
                    btnData,
                    data,
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                        {
                            btnDeaths,
                            deaths,
                            btnRecovered,
                            recovered,
                            btnConfirmed,
                            confirmed
                        }
                    }
                }
            };
        }

        private async void BtnData_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://covid-19-coronavirus-statistics.p.rapidapi.com/v1/total?country=" + country.Text),
                Headers =
            {
                { "x-rapidapi-key", "7ab2f6eae9msh7c5a0dc76fd6e4dp120a5fjsn68768a5398bd" },
                { "x-rapidapi-host", "covid-19-coronavirus-statistics.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                data.Text = body;
            }
        }

        private async void BtnDeaths_Clicked(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnDeaths(country.Text);

            deaths.Text = output.ToString();
        }

        private async void BtnRecovered_Clicked(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnRecovered(country.Text);

            recovered.Text = output.ToString();
        }

        private async void BtnConfirmed_Clicked(object sender, EventArgs e)
        {
            int output = await CAPI.ReturnConfirmed(country.Text);

            confirmed.Text = output.ToString();
        }
    }
}