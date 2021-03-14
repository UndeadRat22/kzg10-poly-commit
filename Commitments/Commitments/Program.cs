namespace Commitments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            mcl.MCL.Init(mcl.MCL.BLS12_381);
            mcl.MCL.ETHmode();

            mcl.MCL.Fr fr = new mcl.MCL.Fr();

            var isZero = mcl.MCL.mclBnFr_isZero(fr);

            _ = isZero;
        }
    }
}
