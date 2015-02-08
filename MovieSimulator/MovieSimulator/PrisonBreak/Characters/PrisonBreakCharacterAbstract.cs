using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.PrisonBreak.Characters.Team;
using MovieSimulator.PrisonBreak.Strategy;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;

namespace MovieSimulator.PrisonBreak.Characters
{
    public abstract class PrisonBreakCharacterAbstract : Character
    {
        public bool hasKey { get; set; }

        public PrisonBreakCharacterAbstract(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public PrisonBreakCharacterAbstract()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightForTheKey();
            team = new LincolnTeam();
            hasKey = false;
        }
    }
}
