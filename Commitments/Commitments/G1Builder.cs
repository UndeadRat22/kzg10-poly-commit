using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using Commitments.Builders;
using Commitments.Conversion.Converters;
using Commitments.Conversion.Extensions;
using Commitments.Types;
using MCL.BLS12_381.Net;

namespace Commitments
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
    }
}