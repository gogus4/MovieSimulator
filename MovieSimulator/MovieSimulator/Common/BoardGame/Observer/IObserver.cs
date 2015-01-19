using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Observer
{
    public interface IObserver
    {
        EMode boardgameMode { get; set; }

        void Update();

        string ExecuteBoardgameStrategy();
    }
}
