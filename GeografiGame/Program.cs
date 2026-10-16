namespace GeografiGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Capitals Game!");

            Console.WriteLine("Type in your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Choose a continent");
            Console.WriteLine("1. Europe");
            Console.WriteLine("2. Asia");
            Console.WriteLine("3. Africa");
            Console.Write("Your choice (1-3)");
            string choice = Console.ReadLine();

            Console.WriteLine($"Welcome {name} and good luck! ");

            Console.WriteLine();
            List<Country> listCountries;
            switch (choice)
            {
                case "1":
                    listCountries = Countryrepository.GetEurope();
                    break;
                case "2":
                    listCountries = Countryrepository.GetAsia();
                    break;
                case "3":
                    listCountries = Countryrepository.GetAfrica();
                    break;
                default:
                    Console.WriteLine("Invalid choice, Europe will start now");
                    listCountries = Countryrepository.GetEurope();
                    break;


            }

            int totalQuestions = listCountries.Count;
            int score = 0;
            for (int i = 0; i < totalQuestions; i++)
            {
                Random randomCountry = new Random();

                int randomIndex = randomCountry.Next(listCountries.Count);

                Country selectedCountry = listCountries[randomIndex];
                listCountries.RemoveAt(randomIndex);

                Console.WriteLine($"Wich city is the capital in {selectedCountry.country}");

                string answer = Console.ReadLine();

                if (answer.ToUpper() == selectedCountry.capitalEn.ToUpper() || answer.ToUpper() == selectedCountry.capitalSwe.ToUpper())
                {

                    Console.WriteLine("Right answer!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong answer!");
                }


            }
            Console.WriteLine($"Good job {name} you got {score} points out of {totalQuestions}!");
            Console.ReadLine();

        }
    }
}
