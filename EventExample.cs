using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class EventExample
    {
        public delegate string demoDel(string x, string y);
        public event demoDel myEvent;

        // Make the constructor public
        public EventExample()
        {
            this.myEvent += EventExample_myEvent;
        }

        private string EventExample_myEvent(string x, string y)
        {
            return ("Hello " + x + " " + y);
        }
        // Method to raise the event
        public string OnMyEvent(string x, string y)
        {
            // Check if there are any subscribers
            if (myEvent != null)
            {
                return myEvent(x, y);
            }
            else
            {
                return "No event subscribers.";
            }
        }

    }
}
