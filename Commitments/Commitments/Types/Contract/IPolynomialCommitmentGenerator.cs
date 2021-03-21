using mcl;

namespace Commitments.Types.Contract
{
    public interface IPolynomialCommitmentGenerator
    {
        MCL.G1 Commit(MCL.G1[] g1Points);
    }
}