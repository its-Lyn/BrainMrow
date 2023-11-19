namespace BrainMrow.Source;

public static class FileSystem
{
    public static string ReadAllText(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        if (!path.EndsWith(".bm") && !BrainMrow.Quiet)
            Console.WriteLine("WARNING: Assuming file is a BrainMrow file. (.bm)");

        return File.ReadAllText(path);
    }
}