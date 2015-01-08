using MovieSimulator.Common.BoardGame.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames.Composite
{
    public class Potion : CompositeHealAbstract
    {

        public List<CompositeHealAbstract> components { get; set; }

        public Potion (string name)
	    {
            this.name = name;
	    }

        public override void Remove(CompositeHealAbstract compositeAbstract)
        {
            throw new NotImplementedException();
        }

        public override void Add(CompositeHealAbstract compositeAbstract)
        {
            throw new NotImplementedException();
        }

        public override int getHealPower()
        {
            int health = 0;
            foreach (CompositeHealAbstract component in components)
            {
                health += component.getHealPower();
            }
            return health;
        }
    }
}
