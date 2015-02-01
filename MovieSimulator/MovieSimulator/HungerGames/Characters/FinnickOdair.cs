using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.HungerGames.Strategy;

namespace MovieSimulator.HungerGames.Characters
{
    public class FinnickOdair : Character
    {
        public FinnickOdair(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public FinnickOdair()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithBow();
            name = "Finnick Odair";
            team = null;
        }

    }
}
