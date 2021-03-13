using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Commitments.Builders;
using Commitments.Conversion.Converters;
using Commitments.Conversion.Extensions;
using Commitments.Types;
using MCL.BLS12_381.Net;
using Xunit;
using Xunit.Abstractions;

namespace Commitments.Tests
{
    public class CommitmentTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public CommitmentTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Foo()
        {
            //var secretBytes = new byte[] {164, 115, 49, 149, 40, 200, 182, 234, 77, 8, 204, 83, 24}; -- actual bytes which should be generated from this string. Works.
            var s = FrBuilder.FromString("1927409816240961209460912649124", 10);

            var bytes = s.ToBytes();


            var g1 = G1Builder.Build(17, s);

            var textValues = g1.Select(point => point.ToString()).ToList();

            textValues.ForEach(_outputHelper.WriteLine);

            //var commitment = poly.Commit(g1);

            //_ = commitment.ToBytes();
        }

        [Fact]
        public void FrBuilderFromStringSetsExactBytes()
        {
            // Arrange
            var expectedBytes = new byte[] {164, 115, 49, 149, 40, 200, 182, 234, 77, 8, 204, 83, 24};
            
            // Act
            var s = FrBuilder.FromString("1927409816240961209460912649124", 10);

            var bytes = s.ToBytes();

            // Assert
            bytes.Zip(expectedBytes)
                .ToList()
                .ForEach((pair) => Assert.Equal(pair.First, pair.Second));
        }


        [Fact]
        public void G1PointGeneratorShouldHaveExactBytes()
        {
            var bytes = new byte[]
            {
                151,
                241,
                211,
                167,
                49,
                151,
                215,
                148,
                38,
                149,
                99,
                140,
                79,
                169,
                172,
                15,
                195,
                104,
                140,
                79,
                151,
                116,
                185,
                5,
                161,
                78,
                58,
                63,
                23,
                27,
                172,
                88,
                108,
                85,
                232,
                63,
                249,
                122,
                26,
                239,
                251,
                58,
                240,
                10,
                219,
                34,
                198,
                187
            };

            //var g1 = G1.FromBytes(bytes);

            //var desBytes = g1.ToBytes();

            //var g1Point = G1Point.Generator.AsG1().ToBytes();

            //_ = g1;
        }
    }
}