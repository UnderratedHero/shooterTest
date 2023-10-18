public interface IHealth
{
    float Current { get; }

    void Increase(float value);
    void Decrease(float value);
    void Reload();
}
