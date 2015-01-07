using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Command
{
    public class CommandUpdateCharacter : CommandAbstract
    {

        public override void UpdateAreaBoardGame(AreaAbstract area)
        {
            throw new NotImplementedException();
        }

        public override void UpdateCharacterBoardGame(Character character)
        {
            MainWindow.Instance.UpdateCharacter(character);
        }
    }
}