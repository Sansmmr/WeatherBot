using System;
using Xunit;

namespace WeatherBotTestProject
{
    public class UnitTestGetMessage
    {
        [Fact]
        public void Test0()
        {
            string expected = "Сьогодні холодно одягайся тепліше!";
            string actual = WeatherBot.WeatherBot.GetMessage(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test10()
        {
            string expected = "Сьогодні холодно одягайся тепліше!";
            string actual = WeatherBot.WeatherBot.GetMessage(10);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test15()
        {
            string expected = "Сьогодні дуже жарко, так що можеш одягнути майку та шортики =)";
            string actual = WeatherBot.WeatherBot.GetMessage(15);
            Assert.Equal(expected, actual);
        }
    }
}
