namespace BeehiveManager;

internal interface IWorker
{
    string Job { get; }
    void WorkTheNextShift();
}
