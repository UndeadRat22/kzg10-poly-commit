using mcl;

namespace Commitments.Extensions
{
    public static class GTExtensions
    {
        public static MCL.GT GetInverse(this in MCL.GT value)
        {
            var result = new MCL.GT();
            result.Inv(value);

            return result;
        }

        public static MCL.GT GetFinalExp(this in MCL.GT value)
        {
            var result = new MCL.GT();
            result.FinalExp(value);

            return result;
        }
    }
}