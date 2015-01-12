using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Composite
{
    public abstract class CompositeHealAbstract
    {
        public string name { get; set; }

        public abstract void Remove(CompositeHealAbstract compositeAbstract);

        public abstract void Add(CompositeHealAbstract compositeAbstract);

        public abstract int getHealPower();
    }
}