using CommandLine;

namespace BrainMrow.Source;

public class BrainMrowCli
{

    [Verb("run", HelpText = "Run a BrainMrow file.")]
    class RunOptions
    {
        [Option('f', "file", Required = true, HelpText = "Input file")]
        public required string File { get; set; }
        
        [Option('q', "quiet", Required = false, HelpText = "Suppress warnings.")]
        public bool Quiet { get; set; }
    }
    
    [Verb("convert", HelpText = "Convert a Brainfuck file into a BrainMrow file.")]
    class ConverterOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input file path")]
        public required string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file path")]
        public required string OutputFile { get; set; }
        
        [Option('q', "quiet", Required = false, HelpText = "Suppress warnings.")]
        public bool Quiet { get; set; }
    }

    public void Parse(string[] args)
    {
        Parser.Default.ParseArguments<RunOptions, ConverterOptions>(args)
            .WithParsed<RunOptions>(opts =>
            {
                string content = FileSystem.ReadBrainMrowText(opts.File, opts.Quiet);
                BrainMrowInterpreter.Interpret(content);
            })
            .WithParsed<ConverterOptions>(converterOpts =>
            {
                string bmSource = BrainMrowInterpreter.BrainfuckToBrainMrow(converterOpts.InputFile, converterOpts.Quiet);
                FileSystem.WriteBrainMrowText(converterOpts.OutputFile, bmSource, converterOpts.Quiet);
            });
    }
}