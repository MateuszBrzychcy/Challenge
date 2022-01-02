using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class TypeTest
    {
        [Fact]
        public void GetCovidHistoryReturnsDifferentsObjects()
        {
            var covHistory1 = GetCovidHistory("Germany");
            var covHistory2 = GetCovidHistory("Russia");

            Assert.NotSame(covHistory1, covHistory2);
            Assert.False(Object.ReferenceEquals(covHistory1, covHistory2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var covHistory1 = GetCovidHistory("Germany");
            var covHistory2 = covHistory1;

            Assert.Same(covHistory1, covHistory2);
            Assert.True(Object.ReferenceEquals(covHistory1, covHistory2));
        }

        [Fact]
        public void CanSetCounrtyFromReference()
        {
            var covHistory1 = GetCovidHistory("Germany");
            this.SetCountry(ref covHistory1, "NewCountry");
            Assert.Equal("NewCountry", covHistory1.Country);
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            //Given
            var covHistory1 = GetCovidHistory("China");
            //When
            GetCovidHistorySetCountry(out covHistory1, "NewCountry");
            Assert.Equal("NewCountry", covHistory1.Country);
            //Then
        }


        [Fact]
        public void test1()
        {
            //Given
            var x = GetInt();
            //When
            SetInt(ref x);
            //Then
            Assert.Equal(42, x);
        }

        private void GetCovidHistorySetCountry(out CoronavirusHistory covHistory1, string country)
        {
            covHistory1 = new CoronavirusHistory(country);
        }

        private CoronavirusHistory GetCovidHistory(string country)
        {
            return new CoronavirusHistory(country);
        }

        private void SetCountry(ref CoronavirusHistory covHistory, string country)
        {
            covHistory.ChangeCountry(country);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(ref int x)
        {
            x = 42;
        }

    }
}