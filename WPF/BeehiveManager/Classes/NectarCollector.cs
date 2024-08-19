namespace BeehiveManager;

internal class NectarCollector : Bee
{
    public override float CostPerShift { get; } = 1.95F;
    const float NECTAR_COLLECTED_PER_SHIFT = 33.25F;

    public NectarCollector() : base("NectarCollector") { }

    protected override void DoJob()
    {
        HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
    }
}
