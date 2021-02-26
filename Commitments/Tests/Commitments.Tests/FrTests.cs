using System.Numerics;
using Xunit;

namespace Commitments.Tests
{
    public class FrTests
    {
        [Fact]
        public void BigIntToFrCycleDoesNotAlterValue()
        {
            //Arrange
            var bigint = new BigInteger(15);

            //Act
            var fr = bigint.AsFr();
            var result = fr.AsBigInt();
            //Assert
            Assert.Equal(bigint, result);
        }
    }
}
