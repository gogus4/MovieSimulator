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
    public class Guard : Character
    {
        public Guard(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public Guard()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithTruncheon();
            name = "Garde";
        }

    }
}
