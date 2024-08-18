namespace EggsSpawner;

class Egg(double size, string color)
{
    public double Size { get; private set; } = size;
    public string Color { get; private set; } = color;

    public virtual string Description => $"A {Size:0.0}cm {Color} egg";
}
