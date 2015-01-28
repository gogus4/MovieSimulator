using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.PrisonBreak.Characters;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;

namespace MovieSimulator.PrisonBreak
{
    public class BoardGamePrisonBreak : BoardGameAbstract
    {
        public BoardGamePrisonBreak()
            : base()
        {

        }

        public BoardGamePrisonBreak(List<AreaAbstract> areas, int size)
            : base(areas, size)
        {
        }

        public BoardGamePrisonBreak(int size)
            : base(size)
        {
            placeCharacters();
        }

        private void placeCharacters()
        {
            this.AddCharacter(new LincolnBurrows());
            this.AddCharacter(new MichaelScofield(0, 1));
            this.AddCharacter(new Guard(19, 8));
            this.AddCharacter(new Guard(10, 10));
            this.AddCharacter(new Guard(8, 18));
        }

        public override void Next()
        {
            List<Character> toKeep = new List<Character>();
            foreach (Character character in characters)
            {
                if (character.hp > 0)
                {
                    character.Action();
                    toKeep.Add(character);
                }
            }
            characters = toKeep;
        }
    }
}
