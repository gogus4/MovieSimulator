using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Characters.Team;

namespace MovieSimulator.Common.Statements
{
    public class StatementGameRunning : StatementGame
    {
        public override void Execute()
        {
            GamingEnvironment.Instance.boardGame.Next();

            
            if (GamingEnvironment.Instance.boardGame.characters.Count > 0)
            {
                if (GamingEnvironment.Instance.boardGame.characters.Count == 1)
                {
                    GameSimulator.Instance.statementGame = new StatementGameFinish();
                }
                else
                {
                    if (GamingEnvironment.Instance.boardGame.characters[0].team != null)
                    {
                        var listTeam = GamingEnvironment.Instance.boardGame.characters.Select(x => x.team.name).Distinct();
                        if (listTeam.Count() == 1)
                        {
                            GameSimulator.Instance.statementGame = new StatementGameFinish();
                        }
                    }
                }
            }
        }
    }
}
