using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MovieSimulator.HungerGames.Area
{
    // User can go but can not fight
    public class Water : AreaAbstract
    {
        public Water()
        {
            Color = Brushes.Blue;
        }
    }
}
