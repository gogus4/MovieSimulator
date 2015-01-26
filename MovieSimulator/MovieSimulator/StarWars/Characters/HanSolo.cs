using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using MovieSimulator.StarWars.Strategy;

namespace MovieSimulator.StarWars.Characters
{
    public class HanSolo : Character
    {
        public HanSolo(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public HanSolo()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithFalconMilenium();
            name = "Han Solo";
        }
    }
}
