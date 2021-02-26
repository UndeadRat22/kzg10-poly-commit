using System.Numerics;

namespace Cryptography.FiniteFields.Elements
{
    public class FiniteFieldElement
    {
        public BigInteger Order { get; set; }
        public BigInteger Value { get; set; }
    }
}