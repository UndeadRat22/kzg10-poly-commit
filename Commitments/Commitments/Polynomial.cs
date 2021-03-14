using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                MCL.mclBnG1_mul(ref coefficientOnPoint, point, coefficient);
                
                MCL.mclBnG1_add(ref commitment, commitment, coefficientOnPoint);
            }
            return commitment;
        }

        public MCL.G1 GenerateProof(MCL.Fr position)
        {
            var divisor = new MCL.Fr[2];

            divisor[0].Neg(position); // -x;
            divisor[1].SetInt(1); // 1

            // quotientPolynomial := polyLongDiv(poly, divisor[:])
            var quotientPolynomial = LongDivision(divisor);


            //TODO:
            // evaluate quotient poly at shared secret, in G1
            //    return bls.LinCombG1(ks.SecretG1[:len(quotientPolynomial)], quotientPolynomial)

            return new MCL.G1();
        }

        //TODO:
        public Polynomial LongDivision(MCL.Fr[] divisor)
        {
            return null;
        }
    }
}