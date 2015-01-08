using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.HungerGames.Strategy
{
    public class StrategyFightWithBow : StrategyFight
    {
        public override int Degats()
        {
            return 25;
        }

        public override int Range()
        {
            return 3;
        }
    }
}
