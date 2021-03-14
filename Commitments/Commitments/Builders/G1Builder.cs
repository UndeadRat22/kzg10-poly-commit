using mcl;

namespace Commitments.Builders
{
    public class G1Builder
    {
        public const string G1GenX = "3685416753713387016781088315183077757961620795782546409894578378688607592378376318836054947676345821548104185464507";
        public const string G1GenY = "1339506544944476473020471379941921221584933875938349620426543736416511423956333506472724655353366534992391756441569";


        public G1Builder()
        {
            Generator = NewGenerator();
        }

        public MCL.G1 Generator { get; }

        public MCL.G1 NewGenerator()
        {
            var generator = new MCL.G1();
            
            generator.x.SetStr(G1GenX, 10);
            generator.y.SetStr(G1GenY, 10);
            generator.z.SetInt(1);

            return generator;
        }

        public MCL.G1[] Build(int depth, MCL.Fr secret)
        {
            var secretToPower = new MCL.Fr();
            secretToPower.SetInt(1);

            var result = new MCL.G1[depth];
            for (var i = 0; i < depth; i++)
            {
                MCL.mclBnG1_mul(ref result[i], Generator, secretToPower);

                var nextPower = new MCL.Fr();
                MCL.mclBnFr_mul(ref nextPower, secretToPower, secret);

                secretToPower = nextPower;
            }

            return result;
        }
        //public static G1Point[] Build(int depth, Fr secret)
        //{
        //    var sPow = Fr.One;

        //    var result = new G1Point[depth];
        //    for (var i = 0; i < depth; i++)
        //    {
        //        result[i] = (G1Point.Generator.AsG1() * sPow).AsG1Point();
        //        var sPowCopy = Fr.FromBytes(sPow.ToBytes());
        //        sPow = sPowCopy * secret;
        //    }

        //    return result;
        //}
    }
}