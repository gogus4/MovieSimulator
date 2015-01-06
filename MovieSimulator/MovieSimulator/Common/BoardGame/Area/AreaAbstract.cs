using MovieSimulator.Common.BoardGame.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MovieSimulator.Common.BoardGame.Area
{
    // Zone
    public abstract class AreaAbstract
    {
        public int x { get; set; }
        public int y { get; set; }

        public bool isAccessible { get; set; }

        public List<AccessAbstract> access { get; set; }

        public Brush Color { get; set; }

        //public String background { get; set; }

        public AreaAbstract()
        {
            Color = Brushes.Red;
            access = new List<AccessAbstract>();
            isAccessible = true;
        }

        public void addAccess(AccessAbstract access)
        {
            this.access.Add(access);
        }
    }
}