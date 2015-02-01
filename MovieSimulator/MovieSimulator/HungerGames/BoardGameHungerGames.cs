using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.HungerGames.Characters;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame.Characters.Decorator;
using MovieSimulator.HungerGames.Area;
using MovieSimulator.HungerGames.Characters.Decorator;

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
            placeCharacters();
        }

        private void placeCharacters()
        {
            this.AddCharacter(new Katniss(1,1));
            this.AddCharacter(new Peeta(1,18));
            this.AddCharacter(new FinnickOdair(18,1));
            this.AddCharacter(new GaleHawthorne(18,18));
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

        public override void SetOrganisationGroundDecorator(Character character, AreaAbstract area)
        {
            if (typeof(Grass).Equals(area.GetType()))
            {
                character.AddDecoratorToDoMyReport(new GrassDecorator());
            }
            else if (typeof(Water).Equals(area.GetType()))
            {
                character.AddDecoratorToDoMyReport(new WaterDecorator());
            }
        }

        public override void SetOrganisationAssaultDecorator(Character character, Character fromAssault)
        {
            character.AddDecoratorToDoMyReport(new BloodDecorator());
        }

        public override void SetOrganisationFightDecorator(Character character, Character toAttack)
        {

        }
    }
}
