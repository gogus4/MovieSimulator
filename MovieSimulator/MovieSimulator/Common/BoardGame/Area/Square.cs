using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MovieSimulator.Common.BoardGame.Area
{
    public class Square : AreaAbstract
    {
        public Square() : base()
        {
            Color = Brushes.LightGray;
        }
    }
}
