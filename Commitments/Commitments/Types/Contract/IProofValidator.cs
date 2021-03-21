using mcl;

namespace Commitments.Types.Contract
{
    public interface IProofValidator
    {
        bool IsProofValid(in MCL.G1 commitment, in MCL.G1 proof, in MCL.Fr x, in MCL.Fr y);
    }
}