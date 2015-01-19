using MovieSimulator.Common.BoardGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Memento
{
    public class Originator
    {
        public List<Character> characters { get; set; }

        public Originator() {
            characters = new List<Character>();
        }

        public Memento CreateMemento()
        {
            return new Memento(characters);
        }

        public void RestoreFromMemento(Memento m)
        {
            characters = new List<Character>();

            foreach (Character character in m.Characters)
            {
                characters.Add((Character)character.Clone());
            }
        }
    }
}
