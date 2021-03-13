using System;
using Commitments.Conversion.Converters;

namespace Commitments.Types
{
    public struct G1Point
    {
        public const string G1GenX = "17f1d3a73197d7942695638c4fa9ac0fc3688c4f9774b905a14e3a3f171bac586c55e83ff97a1aeffb3af00adb22c6bb";
        public const string G1GenY = "8b3f481e3aaa0f1a09e30ed741d8ae4fcf5e095d5d00af600db18cb2c04b3edd03cc744a2888ae40caa232946c5e7e10";
        public const string G1GenZ = "01";

        public const int ByteSize = Fp.ByteSize * 3;

        public Fp x;
        public Fp y;
        public Fp z;


        public static G1Point Generator = GetNewGenerator();
        public static G1Point GetNewGenerator()
        {
            var xBytes = StringConverter.HexStringToByteArray(G1GenX);
            var yBytes = StringConverter.HexStringToByteArray(G1GenY);
            var zBytes = StringConverter.HexStringToByteArray(G1GenZ);

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