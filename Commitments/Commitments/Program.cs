using mcl;

namespace Commitments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MCL.Init(mcl.MCL.BLS12_381);
            MCL.ETHmode();

            var fr = new mcl.MCL.Fr();

            var isZero = mcl.MCL.mclBnFr_isZero(fr);

            _ = isZero;
        }
    }
}
