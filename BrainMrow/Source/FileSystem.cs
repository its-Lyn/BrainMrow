namespace BrainMrow.Source;

public static class FileSystem
{
    public static string ReadBrainMrowText(string path, bool quiet)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        if (!path.EndsWith(".bm") && !quiet)
            Console.WriteLine("WARNING: Assuming file is a BrainMrow file. (.bm)");

        return File.ReadAllText(path);
    }
    
    public static void WriteBrainMrowText(string path, string source, bool quiet)
    {
        if (File.Exists(path) && !quiet)
            Console.WriteLine($"WARNING: {path} already exists, overwriting.");
        
        File.WriteAllText(path, source);
    }
}