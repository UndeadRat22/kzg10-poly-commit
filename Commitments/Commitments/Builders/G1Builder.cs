using System.Text;
using Commitments.Conversion.Extensions;
using Commitments.Types;
using MCL.BLS12_381.Net;

namespace Commitments.Builders
{
    public static class G1Builder
    {
        public static G1Point[] Build(int depth, Fr secret)
        {
            var sPow = Fr.One;

            var result = new G1Point[depth];
            for (var i = 0; i < depth; i++)
            {
                result[i] = (G1Point.Generator.AsG1() * sPow).AsG1Point();
                var sPowCopy = Fr.FromBytes(sPow.ToBytes());
                sPow = sPowCopy * secret;
            }

            return result;
        }


        public static G1 CustomFromBytes(byte[] bytes)
        {
            var setStrFunction = MclFunctionProvider.Provide<mclBnG1_deserialize>("MclBnG1Deserialize");

            var g1 = new G1();
            unsafe
            {
                fixed (byte* bytePtr = bytes)
                {
                    var result = setStrFunction.Invoke(&g1, bytePtr, (ulong)bytes.Length);
                }
            }
            return g1;
        }
    }
}