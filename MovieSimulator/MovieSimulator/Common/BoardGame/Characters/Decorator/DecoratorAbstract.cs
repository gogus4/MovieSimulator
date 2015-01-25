using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Characters.Decorator
{
    public abstract class DecoratorAbstract : ComponentDecoratorAbstract
    {
        public DecoratorAbstract component;

        public void SetComponent(DecoratorAbstract imbriquedComponent)
        {
            component = imbriquedComponent;
        }

        public override string DoMyReport()
        {
            if (component != null)
            {
                return component.DoMyReport();
            }
            else
            {
                return "";
            }
        }
    }
}
