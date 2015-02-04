using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.PrisonBreak.Strategy;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using MovieSimulator.PrisonBreak.Characters.Team;

namespace MovieSimulator.PrisonBreak.Characters
{
    public class LincolnBurrows : PrisonBreakCharacterAbstract
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
            base.Init();
            name = "Lincoln Burrows";
        }
    }
}
