namespace ChallengeApp
{
    public class CoronavirusHistoryInFiles : VirusHistory, IVirusHistory
    {
        public event ALotOfCasesDelegate? ALotOfCases;
        private const string fileNameHistory = "CovidHistory";
        private const string fileNameAudit = "Audit";
        public CoronavirusHistoryInFiles(string country) : base(country)
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

            using (var file = File.AppendText(fileNameHistory + ".txt"))
            {
                file.WriteLine("Day {0} - Cases: {1} Deaths: {2}", dayNumber, newDay.cases, newDay.deaths);
            }

            using (var filAaudit = File.AppendText(fileNameAudit + ".txt"))
            {
                filAaudit.WriteLine("Day {0} - Cases: {1,6} Deaths: {2,4}  ||  Date of entry: {3,21}", dayNumber, newDay.cases, newDay.deaths, DateTime.UtcNow);
            }
        }

        public CovidStatistics GetStatistics()
        {
            using (var fileRead = File.OpenText(fileNameHistory + ".txt"))
            {
                int index = 1;
                var line = fileRead.ReadLine();
                while (line != null)
                {
                    var lineString = line.ToString();

                    var lineTabOfStrings = lineString.Split(' ');

                    var cases = int.Parse(lineTabOfStrings[4]);
                    var deaths = int.Parse(lineTabOfStrings[6]);

                    var day = new DayOfEpidemyc();
                    day.cases = cases;
                    day.deaths = deaths;
                    day.dayNumber = index++;

                    days.Add(day);
                    line = fileRead.ReadLine();
                }
            }
            var stats = new CovidStatistics(days);
            return stats;
        }

        public void PrintStatistics()
        {

            var stats = this.GetStatistics();

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