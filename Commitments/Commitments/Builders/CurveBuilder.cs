using Commitments.Types;
using mcl;

namespace Commitments.Builders
{
    public class CurveBuilder
    {
        public const string G1GenX = "3685416753713387016781088315183077757961620795782546409894578378688607592378376318836054947676345821548104185464507";
        public const string G1GenY = "1339506544944476473020471379941921221584933875938349620426543736416511423956333506472724655353366534992391756441569";

        public const string G2GenXD0 = "352701069587466618187139116011060144890029952792775240219908644239793785735715026873347600343865175952761926303160";
        public const string G2GenXD1 = "3059144344244213709971259814753781636986470325476647558659373206291635324768958432433509563104347017837885763365758";
        public const string G2GenYD0 = "1985150602287291935568054521177171638300868978215655730859378665066344726373823718423869104263333984641494340347905";
        public const string G2GenYD1 = "927553665492332455747201965776037880757740193453592970025027978793976877002675564980949289727957565575433344219582";
        

        public CurveBuilder()
        {
            G1Gen = NewG1Generator();
            G2Gen = NewG2Generator();
        }

        public MCL.G1 G1Gen { get; }
        public MCL.G2 G2Gen { get; }

        public MCL.G1 NewG1Generator()
        {
            var generator = new MCL.G1();
            
            generator.x.SetStr(G1GenX, 10);
            generator.y.SetStr(G1GenY, 10);
            generator.z.SetInt(1);

            return generator;
        }

        public MCL.G2 NewG2Generator()
        {
            var generator = new MCL.G2();

            generator.x.a.SetStr(G2GenXD0, 10);
            generator.x.b.SetStr(G2GenXD1, 10);
            generator.y.a.SetStr(G2GenYD0, 10);
            generator.y.b.SetStr(G2GenYD1, 10);
            generator.z.a.SetInt(1);
            generator.z.b.Clear();

            return generator;
        }

        public Curve Build(int depth, MCL.Fr secret)
        {
            var secretToPower = MCL.Fr.One();

            var g1Points = new MCL.G1[depth];
            var g2Points = new MCL.G2[depth];

            for (var i = 0; i < depth; i++)
            {
                g1Points[i] = G1Gen * secretToPower;
                g2Points[i] = G2Gen * secretToPower;
                secretToPower *= secret;
            }

            return new Curve(depth, g1Points, g2Points);
        }
    }
}