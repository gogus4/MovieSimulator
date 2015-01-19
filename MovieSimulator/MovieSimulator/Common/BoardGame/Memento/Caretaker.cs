using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Memento
{
    public class Caretaker
    {
        public int Current { get; set; }
        public List<Memento> savedMemento { get; set; }

        public Caretaker()
        {
            Current = 0;
            savedMemento = new List<Memento>();
        }

        public void AddMemento(Memento m)
        {
            savedMemento.Add(m);
        }

        public Memento GetMemento(int index)
        {
            return savedMemento[index];
        }
    }
}
