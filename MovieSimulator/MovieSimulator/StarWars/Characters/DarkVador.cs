using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Command;
using MovieSimulator.StarWars.Strategy;
using MovieSimulator.StarWars.Characters.Team;

namespace MovieSimulator.StarWars.Characters
{
    public class DarkVador : Character
    {
        public DarkVador(int x, int y)
            : base(x, y)
        {
            Init();
        }

        public DarkVador()
        {
            Init();
        }

        public void Init()
        {
            command = new CommandUpdateCharacter();
            strategyFight = new StrategyFightWithDeathStar();
            name = "Dark Vador";
            team = new RepublicTeam();
            hp = 300;
        }
    }
}
