namespace BrainMrow.Source;

public static class BrainMrowInterpreter
{
    public static void Interpret(string source)
    {
        string[] keywords = source.Split();
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

    public static string BrainfuckToBrainMrow(string path, bool quiet)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);
        
        if (!path.EndsWith(".bf") && !path.EndsWith(".bfk") && !quiet)
            Console.WriteLine("WARNING: Assuming file is a BrainMrow file. (.bm)");
     
        string bmSource = string.Empty;
        
        using StreamReader reader = new StreamReader(path);
        while (reader.Peek() >= 0)
        {
            char cChar = (char)reader.Read();
            switch (cChar)
            {
                case '>':
                    bmSource += "mrow ";
                    break;
                case '<':
                    bmSource += "mrrp ";
                    break;
                case '+':
                    bmSource += "meow ";
                    break;
                case '-':
                    bmSource += "hiss ";
                    break;
                case '[':    
                    bmSource += "Purr ";
                    
                    break;
                case ']':
                    bmSource += "purR ";
                    break;
                case '.':
                    bmSource += "~ ";
                    break;
                default:
                    bmSource += cChar;
                    break;
            }
        }

        return bmSource.Trim();
    }
}