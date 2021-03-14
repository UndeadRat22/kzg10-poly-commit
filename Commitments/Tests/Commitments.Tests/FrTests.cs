using System.Linq;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    public class FrTests
    {
        [Fact]
        public void FrBuilderFromStringSetsExactBytes()
        {
            // arrange
            MCL.Init(MCL.BLS12_381);
            MCL.ETHmode();
            var expectedBytes = new byte[] {164, 115, 49, 149, 40, 200, 182, 234, 77, 8, 204, 83, 24};

            // act

            var fr = new MCL.Fr();

            fr.SetStr("1927409816240961209460912649124", 10);

            var bytes = fr.Serialize().Reverse();

            // assert
            bytes.Zip(expectedBytes)
                .ToList()
                .ForEach((pair) => Assert.Equal(pair.First, pair.Second));
        }
    }
}