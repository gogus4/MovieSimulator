using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Factory
{
    public abstract class FactoryBoardGameAbstract
    {
        public FactoryBoardGameAbstract()
        {

        }

        public abstract BoardGameAbstract CreateBoardGame(int size);
    }
}
