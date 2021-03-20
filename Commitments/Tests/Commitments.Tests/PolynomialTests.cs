using Commitments.Builders;
using Commitments.Tests.Fixtures;
using Commitments.Types;
using mcl;
using Xunit;

namespace Commitments.Tests
{
    [Collection("Sequential")]
    public class PolynomialTests : IClassFixture<CommitmentTestFixture>
    {
        [Fact]
        public void CommitShouldHaveASpecificValueGivenExactInputs()
        {
            // Arrange
            var polynomial = new Polynomial(new[] {1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13});

            var secret = new MCL.Fr();
            secret.SetStr("1927409816240961209460912649124", 10);
            var g1Points = new CurveBuilder().Build(polynomial.Size, secret).G1Points;

            // Act
            var commitment = polynomial.Commit(g1Points);

            // Assert
            var expected =
                "1 2477800657478396280496910737712311876776119382023479023481824166251818861301026600704438635866253640104679377733301 2954229993619572531997767690230550003591055333364019243777247691138518393343620011708288769387987906907914339131963";
            var actual = commitment.GetStr(10);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProofAtShouldHaveASpecificValueGivenExactInputs()
        {
            // Arrange
            var polynomial = new Polynomial(new[] {1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13});

            var secret = new MCL.Fr();
            secret.SetStr("1927409816240961209460912649124", 10);
            var g1Points = new CurveBuilder().Build(polynomial.Size, secret).G1Points;

            // Act
            var fr = new MCL.Fr();
            fr.SetInt(17);

            var proof = polynomial.GenerateProofAt(g1Points, fr);

            // Assert
            var expected =
                "1 867803339007397142967426903694725732786398875082812714585913536387867789215930966591756718433944432919654354450045 1056604647851765547809696011101405958529416282518275445556537937608095695960215709670255078026676619389223749112525";
            var actual = proof.GetStr(10);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateAtShouldHaveASpecificValueGivenExactInput()
        {
            //Arrange
            var fr = new MCL.Fr();
            fr.SetInt(17);
            var polynomial = new Polynomial(new[] {1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13});

            //Act
            var point = polynomial.EvaluateAt(fr);

            //Assert
            var actual = point.GetStr(10);
            var expected = "39537218396363405614";
            Assert.Equal(expected, actual);
        }
    }
}