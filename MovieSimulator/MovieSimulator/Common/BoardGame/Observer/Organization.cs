using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Observer
{
    public class Organization : ObservedAbstractSubject
    {

        private EMode observerMode;

        public EMode ObserverMode
        {
            get {
                return this.observerMode;
            }

            set
            {
                this.observerMode = value;
                Update();
            }
        }

        public Organization parent { get; set; }

        public Organization()
            : base()
        {

        }

        public void Update()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }



    }
}
