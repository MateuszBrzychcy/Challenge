using System;

namespace ChallengeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Witaj w programie prowadzącym statystki dotyczące epidemii Covid-19");
            System.Console.WriteLine("Podaj kraj dla którego chcesz wprowadzić dane:");
            var setCounry = Console.ReadLine();
            while (setCounry == null)
            {
                System.Console.WriteLine("Nie podano kraju. Spróbuj jeszcze raz.");
                setCounry = Console.ReadLine();
            }

            var cov = new CoronavirusHistoryInFiles(setCounry);
            cov.ALotOfCases += AttentionMessage;

            while(true)
            {
                System.Console.WriteLine("Podaj ilość zakażeń:");
                var cases = Console.ReadLine();
                if(cases == "q")
                {
                    break;
                }
                System.Console.WriteLine("Podaj ilość zgonów");
                var deaths = Console.ReadLine();
                if(deaths==null || cases==null)
                {
                    throw new ArgumentException("Nie podano wysztkich danych!");
                }
                
                cov.AddDayOfEpidemyc(cases, deaths);

                System.Console.WriteLine("Aby zakończyć wprowadzanie danych i wyświetlić statystki wciśnij q");
            }
            cov.PrintStatistics();

        }
        public static void AttentionMessage(object sender, EventArgs args)
        {
            System.Console.WriteLine("Uwaga! W ostatnim dniu było bardzo dużo zakażeń!");
        }
    }
}

