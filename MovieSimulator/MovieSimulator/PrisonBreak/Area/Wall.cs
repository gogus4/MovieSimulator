﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MovieSimulator.Common.BoardGame.Area;

namespace MovieSimulator.PrisonBreak.Area
{
    public class Wall : AreaAbstract
    {
        public Wall()
        {
            Color = Brushes.DarkGray;
            isAccessible = false;
        }
    }
}
