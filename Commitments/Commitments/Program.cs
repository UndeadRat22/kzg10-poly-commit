using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MCL.BLS12_381.Net;

namespace Commitments
{
    public class Program
    {
        public static BigInteger Secret { get; } = new(1234);
        public static void Main(string[] args)
        {
            var poly = new Polynomial(new BigInteger[] { 5, 25, 125 });

            var g1 = G1Builder.Build(poly.Size, Secret);

            var parts = poly.Frs
                .Zip(g1)
                .Select(pair => pair.Second * pair.First);

            var commitment = parts.Aggregate(G1.Zero, (acc, e) => acc + e);
        }
    }

    public static class FrExtensions
    {
        public static BigInteger AsBigInt(this Fr value) => new(value.ToBytes());
    }

    public static class BigIntegerExtensions
    {
        private const int FrSize = 2 << 4;
        public static Fr AsFr(this BigInteger value)
        {
            var bytes = value.ToByteArray().Pad(FrSize).ToArray().AsSpan();

            return Fr.FromBytes(bytes);
        }

    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Pad<T>(this IEnumerable<T> source, int size)
        {
            return source.Concat(Enumerable.Repeat(default(T), size)).Take(size);
        }
    }
}
