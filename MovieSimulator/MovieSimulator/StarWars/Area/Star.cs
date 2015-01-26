using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Area;
using System.Windows.Media;

namespace MovieSimulator.StarWars.Area
{
    public class Star : AreaAbstract
    {
        public Star()
        {
            Color = Brushes.White;
            isAccessible = false;
        }
    }
}
