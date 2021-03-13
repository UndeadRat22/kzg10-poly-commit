﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using Commitments.Conversion.Converters;
using Commitments.Conversion.Extensions;
using Commitments.Types;
using MCL.BLS12_381.Net;

namespace Commitments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //internal readonly Lazy<mclBnFr_setStr> MclBnFrSetStr;

            var importsField = typeof(MclBls12381)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .First(prop => prop.Name == "Imports");

            var importsValue = importsField.GetValue(null);

            var mclBnFrSetStrField = importsValue.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(prop => prop.Name == "MclBnFrSetStr");

            dynamic mclBnFrSetStr = mclBnFrSetStrField.GetValue(importsValue);

            unsafe
            {
                var value = "1927409816240961209460912649124";
                var bytes = Encoding.ASCII.GetBytes(value);
                var method = mclBnFrSetStr.Value as mclBnFr_setStr;
                var fr = new Fr();
                fixed (byte* bytePtr = bytes)
                {
                    var result = method.Invoke(&fr, bytePtr, (ulong) bytes.Length, 10);
                }
            }


            unsafe
            {
                Console.WriteLine(sizeof(Fp));


                var generator = G1Point.GetNewGenerator();


                //lib
                Console.WriteLine(sizeof(G1));
                Console.WriteLine(sizeof(Fr));
            }
        }
    }
}
