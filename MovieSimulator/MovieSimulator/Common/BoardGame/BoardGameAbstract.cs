using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters;

namespace MovieSimulator.Common.BoardGame
{
    public abstract class BoardGameAbstract
    {
        public List<AreaAbstract> areas { get; set; }
        public List<Character> characters { get; set; }

        public int size { get; set; }

        public BoardGameAbstract()
        {
            areas = new List<AreaAbstract>();
            characters = new List<Character>();

            size = 10;
        }

        public BoardGameAbstract(List<AreaAbstract> areas, int size)
        {
            this.areas = areas;
            this.size = size;
        }

        public BoardGameAbstract(int size)
        {
            areas = new List<AreaAbstract>();
            characters = new List<Character>();
            this.size = size;
        }

        public void AddArea(AreaAbstract area)
        {
            areas.Add(area);
        }

        public void AddCharacter(Character character)
        {
            this.characters.Add(character);
        }
    }
}
