using System;
using Xunit;

namespace WeatherBotTestProject
{
    public class UnitTestGetMessage
    {
        [Fact]
        public void Test0()
        {
            string expected = "������� ������� �������� ������!";
            string actual = WeatherBot.WeatherBot.GetMessage(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test10()
        {
            string expected = "������� ������� �������� ������!";
            string actual = WeatherBot.WeatherBot.GetMessage(10);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test15()
        {
            string expected = "������� ���� �����, ��� �� ����� �������� ����� �� ������� =)";
            string actual = WeatherBot.WeatherBot.GetMessage(15);
            Assert.Equal(expected, actual);
        }
    }
}
