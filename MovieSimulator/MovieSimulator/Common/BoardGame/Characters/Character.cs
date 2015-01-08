using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Strategy;
using MovieSimulator.HungerGames.Strategy;

namespace MovieSimulator.Common.BoardGame.Characters
{
    public abstract class Character
    {
        public String name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public int hp { get; set; }

        public string pathBackground { get; set; }

        public CommandAbstract command { get; set; }

        public StrategyFight strategyFight { get; set; }

        public Character(int x, int y)
            : this()
        {
            this.x = x;
            this.y = y;
        }

        public Character()
        {
            strategyFight = new StrategyFightWithArm();
        }

        public abstract void Move();
        public abstract Boolean Watch();
        public abstract void Fight();
    }
}