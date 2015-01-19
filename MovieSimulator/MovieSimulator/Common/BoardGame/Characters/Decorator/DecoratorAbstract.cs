using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Characters.Decorator
{
    public abstract class DecoratorAbstract : ComponentDecoratorAbstract
    {
        protected ComponentDecoratorAbstract component;

        public void SetComponent(ComponentDecoratorAbstract imbriquedComponent)
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
