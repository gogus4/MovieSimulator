using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Strategy
{
    public abstract class StrategyFight
    {
        public abstract int Degats();
        public abstract int Range();
    }
}