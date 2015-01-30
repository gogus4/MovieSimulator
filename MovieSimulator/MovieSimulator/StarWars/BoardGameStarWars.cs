using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.StarWars.Characters;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common;
using MovieSimulator.Common.BoardGame;
using MovieSimulator.Common.BoardGame.Area;
using MovieSimulator.Common.BoardGame.Characters.Decorator;
using MovieSimulator.StarWars.Characters.Decorator;
using MovieSimulator.StarWars.Area;

namespace MovieSimulator.StarWars
{
    public class BoardGameStarWars : BoardGameAbstract
    {
        public BoardGameStarWars() : base()
        {

        }

        public BoardGameStarWars(List<AreaAbstract> areas, int size)
            : base(areas, size)
        {
        }

        public BoardGameStarWars(int size)
            : base(size)
        {
            placeCharacters();
        }

        private void placeCharacters()
        {
            this.AddCharacter(new LeiaOrgana());
            this.AddCharacter(new HanSolo(14, 8));
            this.AddCharacter(new StormTrooper(19, 8));
            this.AddCharacter(new DarkVador(10, 10));
            this.AddCharacter(new LukeSkywalker(8, 18));
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
            if (typeof(AsteroidChamp).Equals(area.GetType()))
            {
                character.AddDecoratorToDoMyReport(new ScratchDecorator());
            }

        }

        public override void SetOrganisationAssaultDecorator(Character character, Character fromAssault)
        {
            character.AddDecoratorToDoMyReport(new LaserHoleDecorator());
        }

        public override void SetOrganisationFightDecorator(Character character, Character toAttack)
        {
            
        }
    }
}
