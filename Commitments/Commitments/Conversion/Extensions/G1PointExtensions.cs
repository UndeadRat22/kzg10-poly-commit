using Commitments.Types;
using MCL.BLS12_381.Net;

namespace Commitments.Conversion.Extensions
{
    public static class G1PointExtensions
    {
        public static G1 AsG1(this G1Point point)
        {
            unsafe
            {
                var ptr = (G1*)&point;
                return *ptr;
            }
        }
    }
}