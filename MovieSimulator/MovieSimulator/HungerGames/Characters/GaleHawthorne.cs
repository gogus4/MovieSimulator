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
    public class GaleHawthorne : Character
    {
        public GaleHawthorne(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public GaleHawthorne()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithBow();
            name = "Gale Hawthorne";
            team = null;
        }

    }
}
