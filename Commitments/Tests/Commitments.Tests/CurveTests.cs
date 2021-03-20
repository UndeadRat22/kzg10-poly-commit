using Commitments.Builders;
using Commitments.Tests.Fixtures;
using Commitments.Types;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    [Collection("Sequential")]
    public class CurveTests : IClassFixture<CommitmentTestFixture>
    {
        [Fact]
        public void IsProofValidShouldReturnTrueWhenSameParametersUsedForGenIsPassed()
        {
            // Arrange
            var polynomial = new Polynomial(new[] { 1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13 });

            var secret = new MCL.Fr();
            secret.SetStr("1927409816240961209460912649124", 10);
            var curve = new CurveBuilder().Build(polynomial.Size, secret);

            var x = new MCL.Fr();
            x.SetInt(17);

            var proof = polynomial.GenerateProofAt(curve.G1Points, x);
            var commitment = polynomial.Commit(curve.G1Points);
            var y = polynomial.EvaluateAt(x);

            // Act
            var isValid = curve.IsProofValid(commitment, proof, x, y);

            // Assert
            Assert.True(isValid);
        }
    }
}