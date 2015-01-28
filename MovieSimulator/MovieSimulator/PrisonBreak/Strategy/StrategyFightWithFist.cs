using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.PrisonBreak.Strategy
{
    public class StrategyFightWithFist : StrategyFight
    {
        public override int Degats()
        {
            return 15;
        }

        public override int Range()
        {
            return 1;
        }
    }
}
