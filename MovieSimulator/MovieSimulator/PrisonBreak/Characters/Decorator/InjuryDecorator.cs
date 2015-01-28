using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSimulator.Common.BoardGame.Characters.Decorator;

namespace MovieSimulator.PrisonBreak.Characters.Decorator
{
    public class InjuryDecorator : DecoratorAbstract
    {
        public override string DoMyReport()
        {
            return base.DoMyReport() + ", je suis blessé";
        }
    }
}
