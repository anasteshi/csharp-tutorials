namespace Tutorials;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for a number between 0 and 100
        Console.WriteLine("Think of a number between 0 and 100!");
        Console.ReadLine();

        // Define the max value
        int max = 100;
        
        // Keep track of the number of guesses
        int guesses = 0;
        
        // The start guess from
        int guessMin = 0;
        
        // The start guess to
        int guessMax = max / 2;
        
        // While the guess isn't the max value
        while (guessMin != max)
        {
            // Increment guesses
            guesses++;
            
            // Ask the user if their number is between the range
            Console.WriteLine($"Is your number between {guessMin} and {guessMax}?");
            string response = Console.ReadLine();

            // If the user confirmed that their number is within the current range...
            if (response?.ToLower().FirstOrDefault() == 'y')
            {
                // We know the number is between the guessMax and guessMin
                max = guessMax;
                
                // Change the next guess range to be half of the max range
                guessMax -= (guessMax - guessMin) / 2;
            }
            // The number is greater than guessMax and less than or equal to max
            else
            {
                // The new minimum is one above the old maximum 
                guessMin = guessMax + 1;
                
                // Guess the bottom half of the new range
                int remaining = max - guessMax;
                
                // The new maximum is half of the remaining numbers
                // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3
                guessMax += (int)Math.Ceiling(remaining / 2f);
                
            }
            // If we only have 2 numbers left, guess one of them
            if (guessMin + 1 == max)
            {
                // Increment guesses
                guesses++;
                
                // Assume that the answer is the lowest number
                Console.WriteLine($"Is your number {guessMin}?");
                response = Console.ReadLine();
                
                // If the user confirmed that their number is the lower number...
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    break;
                }
                else
                {
                    guessMin = max;
                    break;
                }

            }
        }
        Console.WriteLine($"Ah! So it's {guessMin}!");
        
        // Tell the user how many guesses it took
        Console.WriteLine($"Guessed in {guesses} guesses!");

    }
}