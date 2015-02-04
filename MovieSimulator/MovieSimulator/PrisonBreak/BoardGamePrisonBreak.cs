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
using MovieSimulator.Common.BoardGame.Characters.Decorator;
using MovieSimulator.PrisonBreak.Characters.Decorator;
using MovieSimulator.PrisonBreak.Strategy;
using MovieSimulator.PrisonBreak.Characters.Team;

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
            this.AddCharacter(new LincolnBurrows(1, 1));
            this.AddCharacter(new MichaelScofield(0, 1));
            this.AddCharacter(new Guard(4, 9));
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

        public override void SetOrganisationGroundDecorator(Character character, AreaAbstract area)
        {

        }

        public override void SetOrganisationAssaultDecorator(Character character, Character fromAttack)
        {
            character.AddDecoratorToDoMyReport(new InjuryDecorator());
            if (fromAttack.strategyFight.GetType().Equals(typeof(StrategyFightWithTruncheon)))
            {
                character.AddDecoratorToDoMyReport(new TruncheonBlowDecorator());
            }
        }

        public override void SetOrganisationFightDecorator(Character character, Character toAttack)
        {
            if (character.strategyFight.GetType().Equals(typeof(StrategyFightForTheKey)))
            {
                character.AddDecoratorToDoMyReport(new HasKey());

                foreach (Character gangster in characters.Where(x => x.team.GetType().Equals(typeof(LincolnTeam))))
                {
                    if(gangster.GetType().Equals(typeof(PrisonBreakCharacterAbstract))){
                        ((PrisonBreakCharacterAbstract)gangster).hasKey = true;
                        gangster.strategyFight = new StrategyFightWithScrewdriver();
                    }
                }

                ((PrisonBreakCharacterAbstract)toAttack).hasKey = false;
            }
            
        }
    }
}
