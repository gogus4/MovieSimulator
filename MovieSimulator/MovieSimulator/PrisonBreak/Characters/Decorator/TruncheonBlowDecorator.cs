using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters.Decorator;

namespace MovieSimulator.PrisonBreak.Characters.Decorator
{
    class TruncheonBlowDecorator : DecoratorAbstract
    {
        public override string DoMyReport()
        {
            return base.DoMyReport() + ", j'ai mal car je me suis pris un coup de matraque";
        }
    }
}
