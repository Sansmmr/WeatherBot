using System;
using Newtonsoft.Json;
using Xunit;
using System.IO;
using System.Net;

namespace WeatherBotTestProject
{
    public class UnitTestGetWeather
    {
        [Fact]
        public void TestGetWeatherKyiv()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=Kyiv&unit=metric&appid=" + WeatherBot.WeatherBotConfig.ApiId;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherBot.WeatherResponse expected = JsonConvert.DeserializeObject<WeatherBot.WeatherResponse>(response);
            (string actualCity, int actualTemp) = WeatherBot.WeatherBot.GetWeather("Kyiv");
            Assert.Equal(expected.Name, actualCity);
            Assert.Equal((int)Math.Round(expected.Main.Temp - 273, 0), actualTemp);
        }
    }
}
