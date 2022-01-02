using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class CoronavirusHistoryTests
    {
        [Fact]
        public void test1()
        {
            // arrange
            var covTest = new CoronavirusHistory("Poland");
            covTest.AddDayOfEpidemyc("2000", "20");
            covTest.AddDayOfEpidemyc("4000", "150");
            covTest.AddDayOfEpidemyc("12000", "100");

            // act
            var stats = covTest.GetStatistics();
        
            // assert
            Assert.Equal(12000, stats.highestNumberOfInfections);
            Assert.Equal(3, stats.dayNumberWithHighestInfection);
            Assert.Equal(150, stats.highestNumberOfDeaths);
            Assert.Equal(2, stats.dayNumberWithHighestDeaths);
            Assert.Equal(6000, stats.averageInfections);
            Assert.Equal(90, stats.averageDeaths);
        }
    }
}