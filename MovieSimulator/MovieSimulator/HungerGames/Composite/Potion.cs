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
            components = new List<CompositeHealAbstract>();
	    }

        public override void Remove(CompositeHealAbstract compositeAbstract)
        {
            if(components.Contains(compositeAbstract))
                components.Remove(compositeAbstract);
        }

        public override void Add(CompositeHealAbstract compositeAbstract)
        {
            components.Add(compositeAbstract);
        }

        public override int getHealPower()
        {
            int health = 0;
            foreach (CompositeHealAbstract component in components)
                health += component.getHealPower();

            return health;
        }

        public override String ToString()
        {
            String returnString = this.name + " : ";

            foreach (CompositeHealAbstract component in components)
                returnString += component.ToString() + ",";

            returnString.Remove(returnString.Length - 1);

            return returnString;
        }
    }
}
