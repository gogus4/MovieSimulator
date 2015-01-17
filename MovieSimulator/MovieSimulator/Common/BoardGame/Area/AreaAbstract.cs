using MovieSimulator.Common.BoardGame.Access;
using MovieSimulator.Common.BoardGame.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MovieSimulator.Common.BoardGame.Composite;

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

        public CommandAbstract graphicCommand { get; set; }

        public CompositeHealAbstract item { get; set; }

        public AreaAbstract()
        {
            graphicCommand = new CommandUpdateArea();
            access = new List<AccessAbstract>();
            item = null;
            isAccessible = true;
        }

        public void SetItem(CompositeHealAbstract composite)
        {
            this.item = composite;
        }

        public void UpdateGraphic()
        {
            graphicCommand.UpdateAreaBoardGame(this);
        }

        public void addAccess(AccessAbstract access)
        {
            this.access.Add(access);
        }
    }
}