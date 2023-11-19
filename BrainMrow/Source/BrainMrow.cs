namespace BrainMrow.Source;

// BrainMrow is a Brainfuck based language.
// All it does is change the keywords.

public static class BrainMrow
{
    public static void Main(string[] args)
    {
        BrainMrowCli cli = new BrainMrowCli();
        cli.Parse(args);
    }
}