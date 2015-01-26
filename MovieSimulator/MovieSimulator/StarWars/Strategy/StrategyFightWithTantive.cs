using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.StarWars.Strategy
{
    class StrategyFightWithTantive : StrategyFight
    {
        public override int Degats()
        {
            return 20;
        }

        public override int Range()
        {
            return 4;
        }
    }
}
