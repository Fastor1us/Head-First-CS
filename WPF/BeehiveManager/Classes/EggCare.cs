namespace BeehiveManager;

internal class EggCare(Queen queen) : Bee("EggCare")
{
    public override float CostPerShift { get; } = 1.35F;
    const float CARE_PROGRESS_PER_SHIFT = 0.15F;
    private readonly Queen queen = queen;

    protected override void DoJob()
    {
        queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
    }
}
