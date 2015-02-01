using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.HungerGames.Strategy
{
    public class StrategyFightWithSword : StrategyFight
    {
        public override int Degats()
        {
            return 35;
        }

        public override int Range()
        {
            return 1;
        }
    }
}
