using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Command
{
    public class CommandUpdateArea : CommandAbstract
    {
        public override void UpdateAreaBoardGame(AreaAbstract area)
        {
            MainWindow.Instance.UpdateArea(area);
        }

        public override void UpdateCharacterBoardGame(Characters.Character area)
        {
            throw new NotImplementedException();
        }
    }
}
