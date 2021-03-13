using System;
using Commitments.Conversion.Converters;

namespace Commitments.Types
{
    public struct G1Point
    {
        public const string G1GenX = "17F1D3A73197D7942695638C4FA9AC0FC3688C4F9774B905A14E3A3F171BAC586C55E83FF97A1AEFFB3AF00ADB22C6BB";
        public const string G1GenY = "08B3F481E3AAA0F1A09E30ED741D8AE4FCF5E095D5D00AF600DB18CB2C04B3EDD03CC744A2888AE40CAA232946C5E7E1";
        public const string G1GenZ = "01";

        public const int ByteSize = Fp.ByteSize * 3;

        public Fp x;
        public Fp y;
        public Fp z;


        public static G1Point Generator = GetNewGenerator();
        public static G1Point GetNewGenerator()
        {
            var xBytes = StringConverter.StringToByteArray(G1GenX, 16);
            var yBytes = StringConverter.StringToByteArray(G1GenY, 16);
            var zBytes = StringConverter.StringToByteArray(G1GenZ, 16);

            return new G1Point
            {
                x = Fp.FromBytes(xBytes),
                y = Fp.FromBytes(yBytes),
                z = Fp.FromBytes(zBytes)
            };
        }

        public override string ToString() 
            => $"x: '{x}'{Environment.NewLine}y: '{y}'{Environment.NewLine}z: '{z}'{Environment.NewLine}";
    }
}