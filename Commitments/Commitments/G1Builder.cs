using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MCL.BLS12_381.Net;

namespace Commitments
{
    public static class G1Builder
    {
        public static G1[] Build(int depth, BigInteger secret) 
            => GetParts(depth, secret).ToArray();
        
        private static IEnumerable<G1> GetParts(int depth, BigInteger secret)
        {
            yield return G1.Generator;
            
            var currentSecret = secret.AsFr();
            for (var i = 0; i < depth; i++)
            {
                var next = G1.Generator * currentSecret;
                currentSecret *= secret.AsFr();

                yield return next;
            }
        }
    }
}