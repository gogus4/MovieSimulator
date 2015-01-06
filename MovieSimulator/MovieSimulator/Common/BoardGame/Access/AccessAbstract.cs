using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Access
{
    public abstract class AccessAbstract
    {
        public AreaAbstract areaStart { get; set; }
        public AreaAbstract areaEnd { get; set; }

        public Boolean bidirectional { get; set; }

        public AccessAbstract(AreaAbstract areaStart, AreaAbstract areaEnd)
        {
            this.areaStart = areaStart;
            this.areaEnd = areaEnd;
        }
    }
}