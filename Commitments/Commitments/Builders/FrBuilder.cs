using System.Linq;
using System.Reflection;
using System.Text;
using MCL.BLS12_381.Net;

namespace Commitments.Builders
{
    public static class FrBuilder
    {
        public static Fr FromString(string value, int fromBase)
        {
            var setStrFunction = MclFunctionProvider.Provide<mclBnFr_setStr>("MclBnFrSetStr");

            var bytes = Encoding.ASCII.GetBytes(value);
            var fr = new Fr();
            unsafe
            {
                fixed (byte* bytePtr = bytes)
                {
                    var result = setStrFunction.Invoke(&fr, bytePtr, (ulong)bytes.Length, fromBase);
                }
            }
            return fr;
        }
    }
}