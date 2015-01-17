using MovieSimulator.Common.BoardGame.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.HungerGames.Composite
{
    public class Poire : CompositeHealAbstract
    {
        public Poire()
        {
            this.name = "Poire";
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

        public override String ToString()
        {
            return name;
        }
    }
}
