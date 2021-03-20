using System;
using System.Collections.Generic;
using System.Linq;
using Commitments.Extensions;
using mcl;

namespace Commitments.Types
{
    public class Polynomial
    {
        public Polynomial(IEnumerable<int> coefficients)
        {
            Coefficients = coefficients
                .Select(coefficient =>
                {
                    var fr = new MCL.Fr();
                    fr.SetInt(coefficient);
                    return fr;
                }).ToArray();
        }

        public Polynomial(MCL.Fr[] coefficients)
        {
            Coefficients = coefficients;
        }

        public MCL.Fr[] Coefficients { get; }
        public int Size => Coefficients.Length;

        public MCL.G1 Commit(MCL.G1[] g1Points)
        {
            if (Coefficients.Length != g1Points.Length)
            {
                throw new ArgumentException($"Cannot commit a polynomial of length {Size} to curve points of length {g1Points.Length}");
            }

            return Coefficients.Zip(g1Points)
                .Aggregate(new MCL.G1(), (acc, val) => acc + val.Second * val.First);
        }

        public MCL.Fr EvaluateAt(MCL.Fr point)
        {
            var result = new MCL.Fr();
            MCL.mclBn_FrEvaluatePolynomial(ref result, Coefficients, Coefficients.Length, point);

            return result;
        }

        public MCL.G1 GenerateProofAt(MCL.G1[] secretG1, MCL.Fr point)
        {
            var divisor = new MCL.Fr[2];

            // { -x, 1 }
            divisor[0].Neg(point);
            divisor[1].SetInt(1);

            var quotientPolynomial = LongDivision(divisor);
            
            // basically a linear combination: sum(g1[i] * fr[i])
            var g1 = new MCL.G1();
            MCL.mclBnG1_mulVec(ref g1, secretG1, quotientPolynomial.Coefficients, Math.Min(secretG1.Length, quotientPolynomial.Size));

            return g1;
        }

        public Polynomial LongDivision(MCL.Fr[] divisor)
        {
            var polyCopy = Copy().Coefficients;

            var aPos = polyCopy.Length - 1;
            var bPos = divisor.Length - 1;
            var diff = aPos - bPos;

            var result = new MCL.Fr[diff + 1];

            while (diff >= 0)
            {
                result[diff] = polyCopy[aPos] / divisor[bPos];
                for (var i = bPos; i>= 0; i--)
                {
                    polyCopy[diff + i] = polyCopy[diff + i] - result[diff] * divisor[i];
                }
                aPos--;
                diff--;
            }

            return new Polynomial(result);
        }

        public Polynomial Copy()
        {
            var copiedCoefficients = Coefficients
                .Select(c => c.Copy())
                .ToArray();

            return new Polynomial(copiedCoefficients);
        }
    }
}