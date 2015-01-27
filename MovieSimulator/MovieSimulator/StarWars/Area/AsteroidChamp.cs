using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Area;
using System.Windows.Media;

namespace MovieSimulator.StarWars.Area
{
    public class AsteroidChamp : AreaAbstract
    {
        public AsteroidChamp()
        {
            Color = Brushes.Gray;
            isAccessible = false;
        }
    }
}
