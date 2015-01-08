using MovieSimulator.Common.BoardGame.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames.Composite
{
    public class Pomme : CompositeHealAbstract
    {
        public Pomme()
        {
            this.name = "pomme";
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
            return 10;
        }
    }
}
