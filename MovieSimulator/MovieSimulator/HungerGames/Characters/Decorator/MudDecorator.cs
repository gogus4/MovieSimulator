using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters.Decorator;

namespace MovieSimulator.HungerGames.Characters.Decorator
{
    class MudDecorator : DecoratorAbstract
    {
        public override string DoMyReport()
        {
            return base.DoMyReport() + ", je suis couvert de boue";
        }
    }
}
