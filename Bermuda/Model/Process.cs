using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public enum Arrow
    {
        Condition,
        Response,
        Include,
        Exclude,
        Milestone
    };


    public class Relation
    {
        public readonly Event src;
        public readonly Event tgt;
        public readonly Arrow rel;

        public Relation(Event src, Arrow rel, Event tgt)
        {
            this.src = src;
            this.tgt = tgt;
            this.rel = rel;
        }
    }


    public class Process
    {
        private HashSet<Event> events = new HashSet<Event>();
        private HashSet<Relation> relations = new HashSet<Relation>();

        public HashSet<Event> executed = new HashSet<Event>();
        public HashSet<Event> included = new HashSet<Event>();
        public HashSet<Event> pending = new HashSet<Event>();

        //Constructors
        public Process()
        {

        }

        public Process(List<Event> events)
        {
            foreach (var e in events)
            {
                addEvent(e);
            }
        }

        /* Construction. */

        /* Add an event to the graph. The event will be not executed, included,
         * and not pending.
         */
        public void addEvent(Event name)
        {
            events.Add(name);
            included.Add(name);
        }

        /* Add a relation to the graph. Events are assumed to exist already. 
         */
        public void addRelation(Event src, Arrow arr, Event tgt)
        {
            relations.Add(new Relation(src, arr, tgt));
        }

        /* Run-time. */

        /* Return the set of enabled events. */
        public ISet<Event> enabled()
        {
            var result = new HashSet<Event>(included);

            foreach (var r in relations)
            {
                switch (r.rel)
                {
                    case Arrow.Condition:
                        if (included.Contains(r.src) && !executed.Contains(r.src))
                            result.Remove(r.tgt);
                        break;

                    case Arrow.Milestone:
                        if (included.Contains(r.src) && pending.Contains(r.src))
                            result.Remove(r.tgt);
                        break;

                    default:
                        break;
                }
            }

            return result;
        }


        /* Execute event e. Assumes e is enabled. */
        public void execute(Event e)
        {
            pending.Remove(e);
            executed.Add(e);
            foreach (var r in relations)
            {
                if (r.src != e)
                    continue;

                switch (r.rel)
                {
                    case Arrow.Exclude:
                        included.Remove(r.tgt);
                        break;

                    case Arrow.Include:
                        included.Add(r.tgt);
                        break;

                    case Arrow.Response:
                        pending.Add(r.tgt);
                        break;

                    default:
                        break;
                }
            }
        }

        public bool isAccepting()
        {
            foreach (var e in pending)
            {
                if (included.Contains(e))
                    return false;
            }
            return true;
        }
    };
}
