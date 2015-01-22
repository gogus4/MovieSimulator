using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MovieSimulator.Common.Statements
{
    public class StatementGameInit : StatementGame
    {
        public override void Execute()
        {
            for (int i = 0; i < GamingEnvironment.Instance.boardGame.size; i++)
            {
                GameSimulator.Instance.Grid.ColumnDefinitions.Add(new ColumnDefinition());
                GameSimulator.Instance.Grid.RowDefinitions.Add(new RowDefinition());
            }

            GameSimulator.Instance.FillBoardGame();
            GameSimulator.Instance.statementGame = new StatementGameRunning();
        }

    }
}
