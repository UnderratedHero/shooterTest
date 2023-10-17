public interface IHealth
{
    int Current { get; }

    void Increase(int value);
    void Decrease(int value);
    void Reload();
}
