using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using MCL.BLS12_381.Net;

namespace Commitments
{
    public class Polynomial
    {
        public Polynomial(IEnumerable<BigInteger> coefficients)
        {
            Coefficients = coefficients.ToImmutableList();
            Frs = Coefficients
                .Select(coefficient => coefficient.AsFr())
                .ToArray();
        }

        public Fr[] Frs { get; }
        public IReadOnlyList<BigInteger> Coefficients { get; }

        public BigInteger this[in int index] => Coefficients[index];

        public int Size => Coefficients.Count;

        public G1 Commit(G1[] g1)
        {
            var parts = g1
                .Zip(Frs)
                // g1[i] * fr[i]
                .Select(pair => pair.First * pair.Second);

            var commitment = parts.Aggregate(G1.Zero, (acc, e) => acc + e);

            return commitment;
        }
    }
}