using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.PrisonBreak.Strategy;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;

namespace MovieSimulator.PrisonBreak.Characters
{
    public class LincolnBurrows : Character
    {
        public LincolnBurrows(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public LincolnBurrows()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithFist();
            name = "Lincoln Burrows";
        }
    }
}
