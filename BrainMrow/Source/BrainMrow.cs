namespace BrainMrow.Source;

// BrainMrow is a Brainfuck based language.
// All it does is change the keywords.

public static class BrainMrow
{
    public static bool Quiet = false;
    public static string Path = string.Empty;
    
    public static void Main(string[] args)
    {
        BrainMrowCli cli = new BrainMrowCli();
        cli.Parse(args);
        
        if (string.IsNullOrEmpty(Path))
            Environment.Exit(0);

        string content = FileSystem.ReadAllText(Path);
        string[] keywords = content.Split();

        BrainMrowState bmState = new BrainMrowState();
        
        int pos = 0;
        while (pos < keywords.Length)
        {
            string keyword = keywords[pos];
            switch (keyword)
            {
                // +
                case "meow":
                    bmState.Cells[bmState.CurrentIndex]++;
                    break;
                // -
                case "hiss":
                    bmState.Cells[bmState.CurrentIndex]--;
                    break;
                // >
                case "mrow":
                    bmState.CurrentIndex++;
                    break;
                // <
                case "mrrp":
                    bmState.CurrentIndex--;
                    break;
                // [
                case "Purr":
                    bmState.LoopStack.Push(pos);
                    break;
                // ]
                case "purR":
                    if (bmState.Cells[bmState.CurrentIndex] == 0)
                    {
                        bmState.LoopStack.Pop();
                        break;
                    }
                    
                    pos = bmState.LoopStack.Peek();
                    break;
                // .
                case "~":
                    Console.Write((char)bmState.Cells[bmState.CurrentIndex]);
                    break;
            }

            pos++;
        }
    }
}