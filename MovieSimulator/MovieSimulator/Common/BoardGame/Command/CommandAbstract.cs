using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Command
{
    public abstract class CommandAbstract
    {
        public CommandAbstract()
        {

        }

        public abstract void UpdateAreaBoardGame(AreaAbstract area);
        public abstract void UpdateCharacterBoardGame(Character area);

    }
}
