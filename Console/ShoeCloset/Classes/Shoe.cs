namespace ShoeCloset.Classes;

internal class Shoe(Enums.Shoes shoe, Enums.Colors color)
{
    private readonly Enums.Shoes _shoe = shoe;
    private readonly Enums.Colors _color = color;
    public string Name => $"A {_color} {_shoe}";
}
