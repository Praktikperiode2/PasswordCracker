using System;

namespace PasswordCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a password: ");
            string userPassword = Console.ReadLine();
            var position = Console.GetCursorPosition();

            char[] possibleChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '1', '2', '3', '4', '5', '6' };
            Random random = new Random();

            string guessedPassword = "";
            while (guessedPassword != userPassword)
            {
                guessedPassword = "";
                for (int i = 0; i < userPassword.Length; i++)
                {
                    int randomIndex = random.Next(possibleChars.Length);
                    guessedPassword += possibleChars[randomIndex];
                }
                Console.SetCursorPosition(position.Left, position.Top);
                Console.WriteLine("Cracking password... Please be patient...");
                Console.WriteLine("Your password is: " + guessedPassword);
            }
        }
    }
}