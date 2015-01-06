using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame
{
    public abstract class BoardGameAbstract
    {
        public List<AreaAbstract> areas { get; set; }

        public int size { get; set; }

        public BoardGameAbstract()
        {
            areas = new List<AreaAbstract>();
            size = 10;
        }

        public BoardGameAbstract(List<AreaAbstract> areas, int size)
        {
            this.areas = areas;
            this.size = size;
        }

        public BoardGameAbstract(int size)
        {
            areas = new List<AreaAbstract>();
            this.size = size;
        }

        public void AddArea(AreaAbstract area)
        {
            areas.Add(area);
        }
    }
}
