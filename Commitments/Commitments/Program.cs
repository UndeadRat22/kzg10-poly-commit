using System;
using System.Linq;

namespace Commitments
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    /// <summary>
    /// Represent a polynomial of the n'th degree with an array of n coefficients
    /// corresponding to the i'th degree where i is the position in the coefficient array.
    /// </summary>
    public class Polynomial
    {
        //TODO:? arbitrarily large coefficients
        public int[] Coefficients { get; }

        public bool IsZero() => Coefficients.All(c => c == 0);

        #region Factory

        /// <summary>
        /// Creates a "zero" polynomial of the degree'th degree
        /// </summary>
        public static Polynomial Zero(int degree)
        {
            var poly = new Polynomial(new int[degree]);
            return poly;
        }

        private Polynomial(int[] coefficients)
        {
            Coefficients = coefficients;
        }

        #endregion
    }


    /// <summary>
    /// from http://cacr.uwaterloo.ca/techreports/2010/cacr2010-10.pdf 3.1 Definition
    /// </summary>
    public interface ICommitmentScheme
    {
        KeyPair Setup(/*TODO? 1**k*/int degree);
        Commitment Commit(PublicKey publicKey, Polynomial polynomial);
        Polynomial Open(PublicKey publicKey, Polynomial polynomial, Decommitment decommitment);
        bool VerifyPoly(PublicKey publicKey, Commitment commitment, Polynomial polynomial, Decommitment decommitment);
        WitnessGroup CreateWitness(PublicKey publicKey, Polynomial polynomial, int index, Decommitment decommitment);
        bool VerifyEval(PublicKey publicKey, Commitment commitment, int index, Polynomial polynomial, Witness witness);
    }

    public class WitnessGroup
    {
        public int Index { get; set; }
        public Polynomial Polynomial { get; set; }
        public Witness Witness { get; set; }
    }

    public class Witness
    {

    }

    public class Decommitment
    {

    }

    public class Commitment
    {

    }

    public class KeyPair
    {
        public PublicKey PublicKey { get; set; }
        public PrivateKey PrivateKey { get; set; }
    }

    public class PrivateKey
    {

    }

    public class PublicKey
    {

    }
}
