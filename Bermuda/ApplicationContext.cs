using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bermuda.Connector;
using System.Data;

namespace Bermuda
{
    public sealed class ApplicationContext
    {
        private static readonly Lazy<ApplicationContext> lazy = new Lazy<ApplicationContext>(() => new ApplicationContext());

        public static ApplicationContext Instance { get { return lazy.Value; } }

        private List<DomainKnowledge> domainKnowldges;
        private Dictionary<Event, bool> eventInDk;
        private List<Event> events;
        public List<Event> Events {
            get {
                return events;
            } 
            set { 
            foreach(var v in value)
                {
                    eventInDk.Add(v, false);
                }
                events = value;
            } }
        public Dictionary<string, string> connectionStrings;
        public DomainKnowledge currentDK { get; set; }
        public Process process { get; set; }
        private ApplicationContext()
        {
            domainKnowldges = new List<DomainKnowledge>();
            eventInDk = new Dictionary<Event, bool>();
            Events = new List<Event>();
            var storedCS = LocalSettings.GetDataFromLocalSettings<Dictionary<string, string>>("ConnStrings");
            if (storedCS == default(Dictionary<string, string>))
            {
                connectionStrings = new Dictionary<string, string>();
                connectionStrings.Add("New", null);
            } else
            {
                connectionStrings = storedCS;
            }
        }
        public DataTable ConcatenatedData { get; set; }

        public void AddDomainKnowledge(DomainKnowledge dk)
        {
            eventInDk[dk.Event] = true;
            domainKnowldges.Add(dk);
        }

        public void AddDomainKownledge(Screenshot scr, RegulatoryRule rr, SqlScript sql, Event e)
        {
            eventInDk[e] = true;
            domainKnowldges.Add(new DomainKnowledge(scr, rr, sql, e));
        }

        public void ClearAll()
        {
            domainKnowldges = new List<DomainKnowledge>();
            eventInDk = new Dictionary<Event, bool>();
            Events = new List<Event>();
            process = new Process();
        }

        public void ClearOnlyDomainKnowledge()
        {
            domainKnowldges = new List<DomainKnowledge>();
            eventInDk = new Dictionary<Event, bool>();
        }
    }
}
