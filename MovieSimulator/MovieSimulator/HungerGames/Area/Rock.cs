using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MovieSimulator.HungerGames.Area
{
    public class Rock : AreaAbstract
    {
        public Rock()
        {
            this.isAccessible = false;
            Color = Brushes.Gray;
        }
    }
}
