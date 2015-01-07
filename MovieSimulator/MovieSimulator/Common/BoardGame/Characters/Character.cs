using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public Character(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Character()
        {

        }

        public abstract void Move();
        public abstract Boolean Watch();
        public abstract void Fight();
    }
}
