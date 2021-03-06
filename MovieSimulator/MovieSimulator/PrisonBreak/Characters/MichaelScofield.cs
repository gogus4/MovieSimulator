﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.PrisonBreak.Strategy;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using MovieSimulator.PrisonBreak.Characters.Team;

namespace MovieSimulator.PrisonBreak.Characters
{
    public class MichaelScofield : PrisonBreakCharacterAbstract
    {
        public MichaelScofield(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public MichaelScofield()
        {
            Init();
        }

        public void Init()
        {
            base.Init();
            name = "Michael Scofield";
        }
    }
}
