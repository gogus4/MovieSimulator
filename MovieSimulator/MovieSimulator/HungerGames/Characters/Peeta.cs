using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using MovieSimulator.HungerGames.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames.Characters
{
    public class Peeta : Character
    {
        public Peeta(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public Peeta()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithArm();
        }
    }
}
