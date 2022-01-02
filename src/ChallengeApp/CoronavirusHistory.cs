namespace ChallengeApp
{
    public delegate void ALotOfCasesDelegate(object sender, EventArgs args);
    public class CoronavirusHistory : VirusHistory, IVirusHistory
    {
        public event ALotOfCasesDelegate? ALotOfCases;

        public CoronavirusHistory(string country) : base(country)
        {
        }
        public void AddDayOfEpidemyc(string cases, string deaths)
        {
            var newDay = new DayOfEpidemyc();
            int casesInt;
            int deathsInt;

            if (!int.TryParse(cases, out casesInt))
            {
                throw new ArgumentException($"Podano niewłaściwą wartość(Ilośc zakażeń): {cases}");
            }
            if (!int.TryParse(deaths, out deathsInt))
            {
                throw new ArgumentException($"Podano niewłaściwą wartość(Ilośc zgonów): {deaths}");
            }

            if (ALotOfCases != null && casesInt >= 15000)
            {
                ALotOfCases(this, new EventArgs());
            }

            newDay.messageAboutCases = GetMessageAboutCases(casesInt);
            newDay.messageAboutDeaths = GetMessageAboutDeaths(deathsInt);


            newDay.cases = casesInt;
            newDay.deaths = deathsInt;
            newDay.dayNumber = ++dayNumber;

            days.Add(newDay);
        }



        public CovidStatistics GetStatistics()
        {
            var stats = new CovidStatistics(days);
            return stats;
        }
        public void PrintStatistics()
        {
            var stats = new CovidStatistics(days);

            Console.WriteLine($"Państwo: {this.Country}");
            Console.WriteLine();
            Console.WriteLine($"Największa ilosć zakażeń: {stats.highestNumberOfInfections}, Dzień: {stats.dayNumberWithHighestInfection}");
            Console.WriteLine($"Średnia ilość zakażeń każdego dnia: {stats.averageInfections:N0}");
            Console.WriteLine();
            Console.WriteLine($"Największa ilosć przypadków śmiertelnych: {stats.highestNumberOfDeaths}, Dzień: {stats.dayNumberWithHighestDeaths}");
            Console.WriteLine($"Średnia ilość przypadków śmiertelnych każdego dnia: {stats.averageDeaths:N0}");
        }

    }
}