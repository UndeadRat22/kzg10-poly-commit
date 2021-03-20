using mcl;

namespace Commitments.Extensions
{
    public static class G1Extensions
    {
        public static MCL.G1 MultiplyBy(this MCL.G1 value, MCL.Fr by)
        {
            var result = new MCL.G1();
            result.Mul(value, by);

            return result;
        }

        public static MCL.G1 AddWith(this MCL.G1 value, MCL.G1 with)
        {
            var result = new MCL.G1();
            result.Add(value, with);

            return result;
        }

        public static MCL.GT PairWith(this MCL.G1 value, MCL.G2 with)
        {
            var gt = new MCL.GT();
            gt.Pairing(value, with);

            return gt;
        }
    }
}