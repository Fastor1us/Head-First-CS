namespace PaintballGunConsole;

internal class PaintballGun
{
    public int MagazineSize { get; private set; } = 16;
    public int BallsLoaded { get; private set; }
    public bool IsEmpty() => BallsLoaded == 0;
    private int balls = 0;
    public int Balls
    {
        get => balls;
        set
        {
            if (value > 0) balls = value;
            Reload();
        }
    }
    public PaintballGun(int balls, int magazineSize, bool loaded)
    {
        this.balls = balls;
        MagazineSize = magazineSize;
        if (loaded) Reload();
    }

    public void Reload() =>
        BallsLoaded = balls > MagazineSize ? MagazineSize : balls;

    public bool Shoot()
    {
        if (BallsLoaded == 0) return false;
        BallsLoaded--;
        balls--;
        return true;
    }
}
