using CommandLine;

namespace BrainMrow.Source;

public class BrainMrowCli
{
    class Options
    {
        [Option('f', "file", Required = true, HelpText = "Input file")]
        public required string File { get; set; }
        
        [Option('q', "quiet", Required = false, HelpText = "Suppress warnings.")]
        public bool Quiet { get; set; }
    }

    public void Parse(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(opts => {
                if (opts.Quiet)
                    BrainMrow.Quiet = true;

                BrainMrow.Path = opts.File;
            });
    }
}