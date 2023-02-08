using System;
using Xunit;

namespace WeatherBotTestProject
{
    public class UnitTestBotConfig
    {
        [Fact]
        public void TestGetToken()
        {
            string expected = "5205492067:AAE9Wi3gZDzBAXPzQ9ADr29FHqUikO4nVE8";
            string actual = WeatherBot.WeatherBotConfig.Token;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestGetApiId()
        {
            string expected = "74eca899020c43257bc30a03235bde8b";
            string actual = WeatherBot.WeatherBotConfig.ApiId;
            Assert.Equal(expected, actual);
        }
    }
}
