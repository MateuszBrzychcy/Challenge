namespace ChallengeApp
{
    public interface IVirusHistory
    {
        event ALotOfCasesDelegate? ALotOfCases;
        void AddDayOfEpidemyc(string cases, string deaths);
        void ChangeCountry(string country);
        CovidStatistics GetStatistics();
        void PrintStatistics();

    }
}