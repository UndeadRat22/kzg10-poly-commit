using System;
using mcl;

namespace Commitments.Tests.Fixtures
{
    public class CommitmentTestFixture : IDisposable
    {
        public CommitmentTestFixture()
        {
            MCL.Init(MCL.BLS12_381);
            MCL.ETHmode();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}