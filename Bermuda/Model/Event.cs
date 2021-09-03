using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class Event : IEquatable<Event>
    {
        public string EventLabel { get; set; }
        //public string IsIncluded { get; set; }
        //public string IsEnabled { get; set; }
        //public string IsPending { get; set; }
        //public string IsExecuted { get; set; }
        public string EventID { get; set; }
        public int EventSequence { get; set; }

        public Event()
        {

        }

        public Event(int EventSeq, string EventLabel)
        {
            this.EventSequence = EventSeq;
            this.EventLabel = EventLabel;
        }

        public Event(string EventID,string EventLabel)
        {
            this.EventID = EventID;
            this.EventLabel = EventLabel;
        }

        public override bool Equals(object obj)
        {
            return (obj is Event) & Equals((Event)obj);
        }

        public bool Equals(Event obj)
        {
            return (obj != null) & (EventID == obj.EventID & EventLabel == obj.EventLabel);
        }

        public override int GetHashCode()
        {
            return this.EventID.GetHashCode();
        }

        public static bool operator ==(Event person1, Event person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return Object.Equals(person1, person2);

            return person1.Equals(person2);
        }

        public static bool operator !=(Event person1, Event person2)
        {
            if (((object)person1) == null || ((object)person2) == null)
                return !Object.Equals(person1, person2);

            return !(person1.Equals(person2));
        }
    }
}
