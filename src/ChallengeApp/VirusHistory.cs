namespace ChallengeApp
{
    public abstract class VirusHistory : CountryObject
    {
        internal static int dayNumber = 0;
        internal List<DayOfEpidemyc> days = new List<DayOfEpidemyc> { };
        public VirusHistory(string country) : base(country)
        {
            this.Country = country;
        }

        public void ChangeCountry(string country)
        {
            bool validName = true;
            foreach (char c in country)
            {

                if (char.IsDigit(c))
                {
                    validName = false;
                    System.Console.WriteLine("Błąd. Podano niewłaściwą nazwę państwa");
                    break;
                }
            }
            if (validName == true)
            {
                this.Country = country;
            }
        }
        public string GetMessageAboutDeaths(int deathsInt)
        {
            string message;
            switch (deathsInt)
            {
                case var d when d >= 10000:
                    throw new ArgumentException("Podano za dużą ilośc zgonów");

                case var d when d >= 5000:
                    message = "Uwaga! Bardzo dużo zgonów";
                    break;

                case var d when d >= 10000:
                    message = "Dużo zgonów";
                    break;

                case var d when d >= 1000:
                    message = "Umiarkowana ilość zgonów";
                    break;

                case var d when d >= 100:
                    message = "Niewielka ilosć zgonów";
                    break;

                case var d when d > 0:
                    message = "Bardzo mało zgonów";
                    break;

                case var d when d == 0:
                    message = "Brak zgonów";
                    break;

                default:
                    throw new ArgumentException($"Podano ujemną ilość zgonów: {deathsInt}");

            }
            return message;
        }

        public string GetMessageAboutCases(int casesInt)
        {
            string message;
            switch (casesInt)
            {
                case var d when d >= 100000:
                    throw new ArgumentException("Podano za dużą ilośc zakażeń");

                case var d when d >= 50000:
                    message = "Uwaga! Bardzo dużo zakażeń";
                    break;

                case var d when d >= 10000:
                    message = "Dużo zakażeń";
                    break;

                case var d when d >= 1000:
                    message = "Umiarkowana ilość zakażeń";
                    break;

                case var d when d >= 100:
                    message = "Niewielka ilosć zakażeń";
                    break;

                case var d when d > 0:
                    message = "Bardzo mało zakażeń";
                    break;

                case var d when d == 0:
                    message = "Brak zakażeń";
                    break;

                default:
                    throw new ArgumentException($"Podano ujemną ilość zakażeń: {casesInt}");

            }
            return message;
        }
    }
}