namespace csharp.src;

public record struct Frecuency
{
    private static int GetFrecuency(string[] items) =>
        items.Select(s => s.Order().Aggregate("", (acc, next) => acc += next)).ToHashSet().Count;

    public class FrecuencyTests()
    {
        [Theory]
        [InlineData(new string[] { "aaabbb", "aabb", "aabb", "ababababab", "acb" }, 4)]
        [InlineData(new string[] { "aabb", "aabb", "ababababab", "acb" }, 3)]
        [InlineData(new string[] { "aabb", "aabb", "ababababab", "acb", "bca" }, 3)]
        [InlineData(new string[] { "aabb", "aabb", "ababababab", "acb", "bca", "bbb" }, 4)]
        public void Tests(string[] input, int expected)
        {
            Assert.Equal(expected, GetFrecuency(input));
        }
    }
}
