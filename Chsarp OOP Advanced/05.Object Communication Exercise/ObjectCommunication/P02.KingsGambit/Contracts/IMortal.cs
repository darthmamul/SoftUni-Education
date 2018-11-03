using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit.Contracts
{
    public interface IMortal
    {
        bool IsAlive { get; }

        void Die();
    }
}
