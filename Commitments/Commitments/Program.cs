using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using Commitments.Conversion.Converters;
using Commitments.Conversion.Extensions;
using Commitments.Types;

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
