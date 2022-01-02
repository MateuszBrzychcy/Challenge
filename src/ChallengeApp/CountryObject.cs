namespace ChallengeApp
{
    public class CountryObject
    {
        private string country;
        public CountryObject(string country)
        {
            this.country = country;
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.country = value;
                }
            }

        }

    }
}