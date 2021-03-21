using Commitments.Types;
using mcl;

namespace Commitments.Builders.Contract
{
    public interface ICurveBuilder
    {
        MCL.G1 G1Gen { get; }
        MCL.G2 G2Gen { get; }

        MCL.G1 NewG1Generator();
        MCL.G2 NewG2Generator();

        Curve Build(int depth, MCL.Fr secret);
    }
}