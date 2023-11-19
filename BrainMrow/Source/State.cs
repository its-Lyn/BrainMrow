namespace BrainMrow.Source;

public struct BrainMrowState
{
    private const int CellSize = 30000;
    public byte[] Cells { get; }

    public int CurrentIndex = 0;
    
    public Stack<int> LoopStack = new Stack<int>();
    
    public BrainMrowState()
        => Cells = new byte[CellSize];
}