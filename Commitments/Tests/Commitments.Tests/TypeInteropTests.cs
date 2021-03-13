using Commitments.Types;
using MCL.BLS12_381.Net;
using Xunit;

namespace Commitments.Tests
{
    public class TypeInteropTests
    {
        [Fact]
        public void G1PointShouldHaveTheSameSizeAsG1()
        {
            unsafe
            {
                Assert.Equal(sizeof(G1), sizeof(G1Point));
            }
        }
    }
}