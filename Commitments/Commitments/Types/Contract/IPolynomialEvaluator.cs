using mcl;

namespace Commitments.Types.Contract
{
    public interface IPolynomialEvaluator
    {
        MCL.Fr EvaluateAt(MCL.Fr point);
    }
}