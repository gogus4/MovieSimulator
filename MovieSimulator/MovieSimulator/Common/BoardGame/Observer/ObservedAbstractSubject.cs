using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSimulator.Common.BoardGame.Observer
{
    public abstract class ObservedAbstractSubject
    {
        public List<IObserver> observers { get; set; }


        public ObservedAbstractSubject()
        {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer){
            this.observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Update()
        {

        }
    }
}
