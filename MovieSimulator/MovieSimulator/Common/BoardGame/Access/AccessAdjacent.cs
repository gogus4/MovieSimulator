﻿using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Access
{
    public class AccessAdjacent : AccessAbstract
    {
        public AccessAdjacent(AreaAbstract areaEnd)
            : base(areaEnd)
        {

        }
    }
}
