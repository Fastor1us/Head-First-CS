namespace BeehiveManager;

abstract class Bee(string job) : IWorker
{
    public string Job { get; } = job;
    public abstract float CostPerShift { get; }

    public void WorkTheNextShift()
    {
        if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
    }

    protected abstract void DoJob();
}

