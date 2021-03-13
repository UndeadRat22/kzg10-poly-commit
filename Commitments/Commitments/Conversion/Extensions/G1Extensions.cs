using Commitments.Types;
using MCL.BLS12_381.Net;

namespace Commitments.Conversion.Extensions
{
    public static class G1Extensions
    {
        public static G1Point AsG1Point(this G1 g1)
        {
            unsafe
            {
                var ptr = (G1Point*)&g1;
                return *ptr;
            }
        }
    }
}