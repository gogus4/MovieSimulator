using MovieSimulator.Common.BoardGame.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters;
using MovieSimulator.Common.BoardGame.Observer;
using MovieSimulator.Common.BoardGame.Characters.Decorator;

namespace MovieSimulator.Common.BoardGame
{
    public abstract class BoardGameAbstract
    {
        public List<AreaAbstract> areas { get; set; }

        public List<Character> characters { get; set; }

        public int size { get; set; }

        public Organization staff { get; set; }

        public BoardGameAbstract()
        {
            Init(10, new List<AreaAbstract>());
        }

        public BoardGameAbstract(int size)
        {
            Init(size, new List<AreaAbstract>());
        }

        public BoardGameAbstract(List<AreaAbstract> areas, int size)
        {
            Init(size, areas);
        }

        private void Init(int size, List<AreaAbstract> areas)
        {
            characters = new List<Character>();
            staff = new Organization();
            this.size = size;
            this.areas = areas;
        }

        public void AddArea(AreaAbstract area)
        {
            areas.Add(area);
        }

        public void AddCharacter(Character character)
        {
            this.characters.Add(character);
            this.staff.AddObserver(character);
        }

        public void RemoveCharacter(Character character)
        {
            this.characters.Remove(character);
            this.staff.RemoveObserver(character);
        }

        public void ExecuteOrganisationStrategy()
        {
            foreach (Character character in characters)
            {
                GameSimulator.Instance.actionText.AppendText(character.ExecuteBoardgameStrategy() + Environment.NewLine);
            }
        }

        public abstract void SetOrganisationGroundDecorator(Character character, AreaAbstract area);

        public abstract void SetOrganisationAssaultDecorator(Character character, Character fromAssault);

        public abstract void SetOrganisationFightDecorator(Character character, Character toAttack);

        public void ChangeObserverMode(EMode eMode)
        {
            staff.ObserverMode = eMode;
            ExecuteOrganisationStrategy();
        }

        public abstract void Next();
    }
}
