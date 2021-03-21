using mcl;

namespace Commitments.Types.Contract
{
    public interface IPolynomialProofGenerator
    {
        MCL.G1 GenerateProofAt(MCL.G1[] secretG1, MCL.Fr point);
    }
}