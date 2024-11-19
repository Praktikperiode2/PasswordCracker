using System;

namespace PasswordCracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get user input for the password
            Console.Write("Enter a password: ");
            string userPassword = Console.ReadLine() ?? String.Empty;

            // Store the current cursor position (useful for overwriting later)
            var position = Console.GetCursorPosition();

            // Define the set of possible characters for password generation
            char[] possibleChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', '1', '2', '3', '4', '5', '6' };
            Random random = new Random();

            // Initialize an empty string to store the guessed password
            string guessedPassword = "";

            // Loop until the guessed password matches the user password
            while (guessedPassword != userPassword)
            {
                guessedPassword = "";
                // Generate a random password with the same length as the user password
                for (int i = 0; i < userPassword.Length; i++)
                {
                    int randomIndex = random.Next(possibleChars.Length);
                    guessedPassword += possibleChars[randomIndex];
                }
                // Move the cursor back to the beginning of the previous line
                Console.SetCursorPosition(position.Left, position.Top);
                Console.WriteLine("Cracking password... Please be patient...");
                // Display the newly generated guessed password
                Console.WriteLine("Your password is: " + guessedPassword);
            }
        }
    }
}