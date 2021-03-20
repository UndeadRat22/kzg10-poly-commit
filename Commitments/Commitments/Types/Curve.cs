using System.Linq;
using Commitments.Builders;
using Commitments.Extensions;
using mcl;

namespace Commitments.Types
{
    public class Curve
    {
        public Curve(int order, MCL.G1[] g1Points, MCL.G2[] g2Points)
        {
            Order = order;
            G1Points = g1Points;
            G2Points = g2Points;
        }

        public int Order { get; }
        public MCL.G1[] G1Points { get; }
        public MCL.G2[] G2Points { get; }

        private MCL.G1 GenG1 => G1Points[0];
        private MCL.G2 GenG2 => G2Points[0];

        public bool IsProofValid(in MCL.G1 commitment, in MCL.G1 proof, in MCL.Fr x, in MCL.Fr y)
        {
            var xOnG2 = GenG2 * x;

            var sMinusX = G2Points[1] - xOnG2;

            var yOnG1 = GenG1 * y;

            var commitmentMinusY = commitment - yOnG1;

            //e([commitment - interpolation_polynomial]^(-1), [1]) * e([proof],  [s^n - x^n]) = 1_T
            //e(a1^(-1), a2) * e(b1,  b2) = 1_T
            //e(a1, a2)^(-1) * e(b1, b2) = 1_T
            var pairing1 = commitmentMinusY.PairWith(GenG2).GetInverse();
            var pairing2 = proof.PairWith(sMinusX);

            var final = (pairing1 * pairing2).GetFinalExp();

            return final.IsOne();
        }
    }
}