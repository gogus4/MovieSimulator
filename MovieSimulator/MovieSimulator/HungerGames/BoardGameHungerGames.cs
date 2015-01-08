using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.HungerGames.Characters;

namespace MovieSimulator.HungerGames
{
    public class BoardGameHungerGames : BoardGameAbstract
    {
        public BoardGameHungerGames() : base()
        {

        }

        public BoardGameHungerGames(List<AreaAbstract> areas, int size)
            : base(areas, size)
        {
        }

        public BoardGameHungerGames(int size)
            : base(size)
        {
            this.characters.Add(new Katniss());
            this.characters.Add(new Katniss(15, 8));
            this.characters.Add(new Katniss(20, 8));
            this.characters.Add(new Katniss(10, 8));
            this.characters.Add(new Katniss(8, 18));
            this.characters.Add(new Katniss(8,11));
            this.characters.Add(new Katniss(15,5));
        }
    }
}
