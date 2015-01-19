using MovieSimulator.Common.BoardGame.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Memento
{
    public class Memento
    {
        public List<Character> Characters { get; set; }

        public Memento(List<Character> characters)
        {
            Characters = new List<Character>();
            foreach(Character character in characters)
            {
                Characters.Add((Character)character.Clone());
            }
        }
    }
}
