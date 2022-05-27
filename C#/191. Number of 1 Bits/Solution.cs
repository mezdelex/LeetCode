public record struct Solution()
{
    public int HammingWeight(uint n)
    {
        uint counter = 0;

        while (n > 0)
        {
            counter += n % 2;
            n /= 2;
        }

        return (int)counter;
    }

    public int HammingWeightLinQ(uint n) => Convert.ToString(n, 2).Count(bit => bit == '1');

    public int HammingWeightSystemLibrary(uint n) => System.Numerics.BitOperations.PopCount(n);
}
