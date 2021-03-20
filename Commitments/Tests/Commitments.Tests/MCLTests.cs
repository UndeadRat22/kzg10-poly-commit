using Commitments.Tests.Fixtures;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    [Collection("Sequential")]
    public class MCLTests : IClassFixture<CommitmentTestFixture>
    {
        [Fact]
        public void G1ZeroThenIsZeroShouldReturnTrue()
        {
            // Arrange
            var g1 = MCL.G1.Zero();
            // Act
            var isZero = g1.IsZero();
            // Assert
            Assert.True(isZero);
        }

        [Fact]
        public void G2ZeroThenIsZeroShouldReturnTrue()
        {
            // Arrange
            var g2 = MCL.G2.Zero();
            // Act
            var isZero = g2.IsZero();
            // Assert
            Assert.True(isZero);
        }
    }
}