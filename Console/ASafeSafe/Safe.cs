namespace ASafeSafe;

internal class Safe
{
    private readonly string contents = "precious jewels";
    private readonly string safeCombination = "12345";
    public string Open(string? combination)
    {
        return combination == safeCombination ? contents : "";
    }
    public void PickLock(Locksmith lockpicker)
    {
        lockpicker.Combination = safeCombination;
    }
}
