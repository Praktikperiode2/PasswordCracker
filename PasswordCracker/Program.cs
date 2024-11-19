using System;
using System.Threading.Tasks;

namespace PasswordCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a password: ");
            string userPassword = Console.ReadLine();

            char[] possibleChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '1', '2', '3', '4', '5', '6' };

            bool foundPassword = false;
            int totalCount = 0;
            Counter TotalCounter = new();

            Parallel.ForEach(Enumerable.Range(0, userPassword.Length), (i) =>
            {
                string guessedPassword = "";
                Random random = new Random();

                while (!foundPassword && guessedPassword != userPassword)
                {
                    guessedPassword = "";
                    for (int j = 0; j < userPassword.Length; j++)
                    {
                        int randomIndex = random.Next(possibleChars.Length);
                        guessedPassword += possibleChars[randomIndex];
                    }

                    if (guessedPassword == userPassword)
                    {
                        foundPassword = true;
                        Console.WriteLine("Your password is: " + guessedPassword);
                        Console.WriteLine(TotalCounter.GetTotal());
                    }
                    TotalCounter.Increment();
                }

            });

            if (!foundPassword)
            {
                Console.WriteLine("Password not found.");
                Console.WriteLine(TotalCounter.GetTotal());
            }
        }
    }
}

//using System;
//using System.Threading.Tasks;

//namespace PasswordCracker
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string userPassword = GetPasswordFromUser();
//            string guessedPassword = "";
//            var positions = Console.GetCursorPosition();
//            int j = 0;

//            Parallel.ForEach(Enumerable.Range(0, userPassword.Length), (i) =>
//            {
//                while (!IsPasswordFound(userPassword, guessedPassword))
//                {
//                    guessedPassword = GenerateRandomPassword(userPassword);
//                    Console.SetCursorPosition(positions.Left, positions.Top);
//                    Console.WriteLine(j++); ;
//                }
//                Console.WriteLine("Your password is: " + guessedPassword);
//            });
//        }

//        //Denne funktion håndterer indlæsningen af password fra brugeren.
//        static string GetPasswordFromUser()
//        {
//            Console.Write("Enter a password: ");
//            return Console.ReadLine() ?? String.Empty;
//        }

//        //Denne funktion genererer et tilfældigt password med en given længde.
//        static string GenerateRandomPassword(string userPassword)
//        {
//            // Definer de mulige tegn, som kan indgå i password'et
//            char[] possibleChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

//            // Opret en tilfældig talgenerator
//            Random random = new Random();
//            string guessedPassword = "";
//            for (int j = 0; j < userPassword.Length; j++)
//            {
//                int randomIndex = random.Next(possibleChars.Length);
//                guessedPassword += possibleChars[randomIndex];

//                if (guessedPassword == userPassword)
//                {
//                    return guessedPassword;
//                }
//            }
//                return String.Empty;
//        }
//        //enne funktion sammenligner det gættede password med det korrekte password og returnerer true eller false.
//        static bool IsPasswordFound(string password, string guessedPassword)
//        {
//            return guessedPassword == password;
//        }
//    }
//}
