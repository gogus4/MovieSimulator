using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames
{
    public class BoardGameHungerGames : BoardGameAbstract
    {
        public BoardGameHungerGames()
        {

        }

        public BoardGameHungerGames(List<AreaAbstract> areas, int size)
            : base(areas, size)
        {
        }

        public BoardGameHungerGames(int size)
            : base(size)
        {
        }


    }
}
