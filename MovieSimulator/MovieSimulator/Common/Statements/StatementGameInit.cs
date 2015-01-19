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
                MainWindow.Instance.Grid.ColumnDefinitions.Add(new ColumnDefinition());
                MainWindow.Instance.Grid.RowDefinitions.Add(new RowDefinition());
            }

            MainWindow.Instance.FillBoardGame();
            MainWindow.Instance.statementGame = new StatementGameRunning();
        }

    }
}
