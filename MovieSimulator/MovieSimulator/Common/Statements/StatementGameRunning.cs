using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.Statements
{
    public class StatementGameRunning : StatementGame
    {
        public override void Execute()
        {
            GamingEnvironment.Instance.boardGame.Next();
            if(GamingEnvironment.Instance.boardGame.characters.Count == 1){
                GameSimulator.Instance.statementGame = new StatementGameFinish();
            }
        }
    }
}
