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
            //var secret = BigInteger.Parse("1927409816240961209460912649124");
            //var poly = new Polynomial(new BigInteger[] {1, 2, 3, 4, 7, 7, 7, 7, 13, 13, 13, 13, 13, 13, 13, 13});

            //var s = FrBuilder.BuildFromString("1927409816240961209460912649124", 10);
            //var s = Fr.FromInt(1234);
            var s = FrBuilder.BuildFromString("1927409816240961209460912649124", 16);

            var g1 = G1Builder.Build(17, s);



            var textValues = g1.Select(point => point.ToString()).ToList();

            textValues.ForEach(_outputHelper.WriteLine);

            //var commitment = poly.Commit(g1);

            //_ = commitment.ToBytes();
        }
    }
}