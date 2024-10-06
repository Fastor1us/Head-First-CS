namespace GoFishTests.Utils;

/// <summary>
/// Mock Random for testing that always returns a specific value
/// </summary>
internal class MockRandom : Random
{
    public int ValueToReturn { get; set; } = 0;
    public override int Next() => ValueToReturn;
    public override int Next(int maxValue) => ValueToReturn;
    public override int Next(int minValue, int maxValue) => ValueToReturn;
}
