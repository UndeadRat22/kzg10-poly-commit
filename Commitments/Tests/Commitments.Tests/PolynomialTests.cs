using Commitments.Builders;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    public class PolynomialTests
    {
        [Fact]
        public void Foo()
        {
            // Arrange
            MCL.Init(MCL.BLS12_381);
            MCL.ETHmode();
            var polynomial = new Polynomial(new[] {1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13});
            
            var secret = new MCL.Fr();
            secret.SetStr("1927409816240961209460912649124", 10);
            var g1Points = new G1Builder().Build(polynomial.Size, secret);

            // Act
            var commitment = polynomial.Commit(g1Points);
            
            // Assert
            var expected = "1 2477800657478396280496910737712311876776119382023479023481824166251818861301026600704438635866253640104679377733301 2954229993619572531997767690230550003591055333364019243777247691138518393343620011708288769387987906907914339131963";
            var actual = commitment.GetStr(10);
            
            Assert.Equal(expected, actual);
        }
    }
}