using System;
using System.Collections.Generic;
using System.Linq;
using Commitments.Extensions;
using mcl;

namespace Commitments
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


            var commitment = new MCL.G1();
            foreach (var (coefficient, point) in Coefficients.Zip(g1Points))
            {
                var coefficientOnPoint = new MCL.G1();
                coefficientOnPoint.Mul(point, coefficient);
                
                commitment.Add(commitment, coefficientOnPoint);
            }
            return commitment;
        }

        public MCL.G1 GenerateProofAt(MCL.G1[] secretG1, MCL.Fr position)
        {
            var divisor = new MCL.Fr[2];

            // { -x, 1 }
            divisor[0].Neg(position);
            divisor[1].SetInt(1);

            var quotientPolynomial = LongDivision(divisor);

            // mclBnG1_mulVec does should do exactly the same thing, doesn't exist
            // basically a linear combination: sum(g1[i] * fr[i])
            var values = secretG1.Zip(quotientPolynomial.Coefficients)
                .Select(pair => pair.First.MultiplyBy(pair.Second))
                .ToArray();

            return values.Aggregate(new MCL.G1()/*"0"*/, (acc, val) => acc.AddWith(val));
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
                result[diff] = polyCopy[aPos].DivideBy(divisor[bPos]);
                for (var i = bPos; i>= 0; i--)
                {
                    // a[d+i] -= result[d] * divisor[i];
                    polyCopy[diff + i] = polyCopy[diff + i]
                        .Subtract(result[diff].MultiplyBy(divisor[i]));
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