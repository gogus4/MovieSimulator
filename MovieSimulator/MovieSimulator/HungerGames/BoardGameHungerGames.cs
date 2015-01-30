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
            this.AddCharacter(new Katniss());
            this.AddCharacter(new Katniss(14, 8));
            this.AddCharacter(new Peeta(19, 8));
            this.AddCharacter(new Katniss(10, 8));
            this.AddCharacter(new Peeta(8, 18));
            this.AddCharacter(new Katniss(8, 11));
            this.AddCharacter(new Peeta(15, 5));
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
