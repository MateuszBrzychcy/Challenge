namespace ChallengeApp
{
    public class CovidStatistics
    {

        public readonly int highestNumberOfInfections;
        public readonly int dayNumberWithHighestInfection;
        public readonly int highestNumberOfDeaths;
        public readonly int dayNumberWithHighestDeaths;
        public readonly double averageInfections;
        public readonly double averageDeaths;
        public CovidStatistics(List<DayOfEpidemyc> days)
        {
            highestNumberOfInfections = int.MinValue;
            highestNumberOfDeaths = int.MinValue;
            averageInfections = 0.0;
            averageDeaths = 0.0;
            foreach (var n in days)
            {
                averageInfections += n.cases;
                averageDeaths += n.deaths;
                if (n.cases > highestNumberOfInfections)
                {
                    highestNumberOfInfections = n.cases;
                    dayNumberWithHighestInfection = n.dayNumber;
                }
                if (n.deaths > highestNumberOfDeaths)
                {
                    highestNumberOfDeaths = n.deaths;
                    dayNumberWithHighestDeaths = n.dayNumber;
                }
            }
            averageInfections /= days.Count();
            averageDeaths /= days.Count();
        }
    }
}