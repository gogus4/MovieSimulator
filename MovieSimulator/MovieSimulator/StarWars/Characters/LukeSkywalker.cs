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
    public class LukeSkywalker : Character
    {
        public LukeSkywalker(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public LukeSkywalker()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithXWing();
            name = "Luke Skywalker";
        }
    }
}
