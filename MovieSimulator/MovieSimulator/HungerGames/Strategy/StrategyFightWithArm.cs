using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;

namespace MovieSimulator.HungerGames.Strategy
{
    public class StrategyFightWithArm : StrategyFight
    {
        public override int Degats()
        {
            return 10;
        }

        public override int Range()
        {
            return 1;
        }
    }
}