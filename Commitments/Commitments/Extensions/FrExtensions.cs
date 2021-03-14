using mcl;

namespace Commitments.Extensions
{
    public static class FrExtensions
    {
        public static MCL.Fr Copy(this MCL.Fr value)
        {
            var fr = new MCL.Fr();
            fr.Deserialize(value.Serialize());

            return fr;
        }

        public static MCL.Fr MultiplyBy(this MCL.Fr value, MCL.Fr by)
        {
            var result = new MCL.Fr();
            result.Mul(value, by);

            return result;
        }

        public static MCL.Fr GetInverse(this MCL.Fr value)
        {
            var result = new MCL.Fr();
            result.Inv(value);

            return result;
        }

        public static MCL.Fr DivideBy(this MCL.Fr value, MCL.Fr by)
        {
            var result = new MCL.Fr();
            result.Div(value, by);

            return result;
        }


        public static MCL.Fr Subtract(this MCL.Fr value, MCL.Fr amount)
        {
            var result = new MCL.Fr();
            result.Sub(value, amount);

            return result;
        }
    }
}