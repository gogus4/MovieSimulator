using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.PrisonBreak.Strategy
{
    class StrategyFightForTheKey : StrategyFight
    {
        public override int Degats()
        {
            return 0;
        }

        public override int Range()
        {
            return 2;
        }
    }
}
