namespace BrainMrow.Source;

public class BrainMrow
{
    public static bool Quiet = false;
    public static string Path = string.Empty;
    
    public static void Main(string[] args)
    {
        BrainMrowCli cli = new BrainMrowCli();
        cli.Parse(args);
        
        if (string.IsNullOrEmpty(Path))
            Environment.Exit(-1);

        string content = FileSystem.ReadAllText(Path);
        string[] keywords = content.Split(' ');

        BrainMrowState bmState = new BrainMrowState();
        
        int pos = 0;
        while (pos < keywords.Length)
        {
            pos++;
        }
    }
}