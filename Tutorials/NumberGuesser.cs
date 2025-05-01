namespace Tutorials;

/// <summary>
/// Asks the user for a number between 0 and 100, and then CurrentNumberOfGuesses it
/// </summary>
public class NumberGuesser
{
    #region Public Properties
    
    /// <summary>
    /// The largest number that can be guessed
    /// </summary>
    public int MaximumNumber { get; set; }
        
    /// <summary>
    /// The current number of guesses the computer has made
    /// </summary>
    public int CurrentNumberOfGuesses { get; private set; }
        
    /// <summary>
    /// The current minimum number the user is thinking of
    /// </summary>
    public int CurrentGuessMinimum { get; private set; }
    
    /// <summary>
    /// The current maximum number the user is thinking of
    /// </summary>
    public int CurrentGuessMaximum { get; private set; }
    
    #endregion

    #region Constructor
    
    /// <summary>
    /// Default constructor
    /// </summary>
    public NumberGuesser()
    {
        // Set the default maximum number
        MaximumNumber = 100;
    }
    
    #endregion

    #region Public Methods

    /// <summary>
    /// Asks the user to think of a number between 0 and the maximum number
    /// </summary>
    public void InformUser()
    {
        // Ask the user for a number between 0 and MaximumNumber 
        Console.WriteLine($"Think of a number between 0 and {MaximumNumber}!");
        Console.ReadLine();
    }

    /// <summary>
    /// Asks the user a series of questions to guess the number
    /// </summary>
    public void DiscoverNumber()
    {
        // Clear variables to their initial values before a discovery
        CurrentNumberOfGuesses = 0;
        CurrentGuessMinimum = 0;
        CurrentGuessMaximum = MaximumNumber / 2;
        
        // While the guess isn't the max value
        while (CurrentGuessMinimum != MaximumNumber)
        {
            // Increment guesses
            CurrentNumberOfGuesses++;
            
            // Ask the user if their number is between the range
            Console.WriteLine($"Is your number between {CurrentGuessMinimum} and {CurrentGuessMaximum}?");
            string response = Console.ReadLine();

            // If the user confirmed that their number is within the current range...
            if (response?.ToLower().FirstOrDefault() == 'y')
            {
                // We know the number is between the guessMax and guessMin
                MaximumNumber = CurrentGuessMaximum;
                
                // Change the next guess range to be half of the max range
                CurrentGuessMaximum -= (CurrentGuessMaximum - CurrentGuessMinimum) / 2;
            }
            // The number is greater than guessMax and less than or equal to max
            else
            {
                // The new minimum is one above the old maximum 
                CurrentGuessMinimum = CurrentGuessMaximum + 1;
                
                // Guess the bottom half of the new range
                int remaining = MaximumNumber - CurrentGuessMaximum;
                
                // The new maximum is half of the remaining numbers
                // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3
                CurrentGuessMaximum += (int)Math.Ceiling(remaining / 2f);
                
            }
            // If we only have 2 numbers left, guess one of them
            if (CurrentGuessMinimum + 1 == MaximumNumber)
            {
                // Increment guesses
                CurrentNumberOfGuesses++;
                
                // Assume that the answer is the lowest number
                Console.WriteLine($"Is your number {CurrentGuessMinimum}?");
                response = Console.ReadLine();
                
                // If the user confirmed that their number is the lower number...
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    break;
                }
                else
                {
                    CurrentGuessMinimum = MaximumNumber;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Announces the results of the guessing process 
    /// </summary>
    public void AnnounceResults()
    {
        // Tell the user the answer 
        Console.WriteLine($"Ah! So it's {CurrentGuessMinimum}!");
        
        // Tell the user how many guesses it took
        Console.WriteLine($"Guessed in {CurrentNumberOfGuesses} guesses!");

    } 
    
    #endregion
} 