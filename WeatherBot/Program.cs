using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace WeatherBot
{
    public static class WeatherBotConfig
    {
        public static string Token { get => "5205492067:AAE9Wi3gZDzBAXPzQ9ADr29FHqUikO4nVE8"; }
        public static string ApiId { get => "74eca899020c43257bc30a03235bde8b"; }
    }
    public static class WeatherBot
    {
        public static (string, int) Prev { get; set; } = ("", 0);
        public static (string, int) GetWeather(string cityName)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&unit=metric&appid=" + WeatherBotConfig.ApiId;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            return (weatherResponse.Name, (int)Math.Round(weatherResponse.Main.Temp - 273, 0));
        }

        public static string GetMessage(int celsius)
        {
            if (celsius <= 10)
                return "Сегодня холодно одевайся теплее!";
            else
                return "Сегодня очень жарко, так что можешь одеть маечку и шортики =)";
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TelegramBotClient client = new TelegramBotClient(WeatherBotConfig.Token) { Timeout = TimeSpan.FromSeconds(10)};

            var me = client.GetMeAsync().Result;
            Console.WriteLine($"Bot_Id: {me.Id} \nBot_Name: {me.FirstName} ");
            
            client.OnMessage += Bot_OnMessage;
            client.StartReceiving();
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Type == MessageType.Text)
            {
                string city; int temp;
                TelegramBotClient telegramBotClient = sender as TelegramBotClient;
                try
                {
                    (city, temp) = WeatherBot.GetWeather(message.Text);
                    WeatherBot.Prev = (city, temp);
                }
                catch (Exception)
                {
                    (city, temp) = WeatherBot.Prev;
                }
                
                await telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"{WeatherBot.GetMessage(temp)} \n\nТемпература в {city}: {temp} °C");
                Console.WriteLine(message.Text);
            }
        }
    }
}
