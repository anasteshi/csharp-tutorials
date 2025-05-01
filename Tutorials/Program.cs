namespace Tutorials;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of our number guesser class
        var numberGuesser = new NumberGuesser();
        
        // Change the default maximum number
        numberGuesser.MaximumNumber = 2000;
        
        // Ask the user to think of a number
        numberGuesser.InformUser();
        
        // Discover the number the user thinks of
        numberGuesser.DiscoverNumber();
        
        // Announce the results 
        numberGuesser.AnnounceResults();
    }
}