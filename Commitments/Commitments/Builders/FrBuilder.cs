using System.Linq;
using System.Reflection;
using System.Text;
using MCL.BLS12_381.Net;

namespace Commitments.Builders
{
    public static class FrBuilder
    {
        public static Fr BuildFromString(string value, int fromBase)
        {
            var importsField = typeof(MclBls12381)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .First(prop => prop.Name == "Imports");

            var importsValue = importsField.GetValue(null);

            var mclBnFrSetStrField = importsValue.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(prop => prop.Name == "MclBnFrSetStr");

            dynamic mclBnFrSetStr = mclBnFrSetStrField.GetValue(importsValue);

            unsafe
            {
                var bytes = Encoding.ASCII.GetBytes(value);
                var method = mclBnFrSetStr.Value as mclBnFr_setStr;
                var fr = new Fr();
                fixed (byte* bytePtr = bytes)
                {
                    var result = method.Invoke(&fr, bytePtr, (ulong)bytes.Length, fromBase);
                }
                return fr;
            }
        }
    }
}