using Bermuda.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bermuda.Connector
{
    public class DcrXmlParser
    {
        public static List<Event> GetEventsFromDcr(string filePath)
        {
            XElement dcrEventsXml = XElement.Load(filePath);

            //var eventSequence = (from item in dcrEventsXml.Descendants("events") 
            //                                            select new KeyValuePair<string,int>((string)item.Attribute("id"),
            //                                            int.Parse((string)item.Descendants("custom").First().Element("sequence").Value))
            //                                            ).ToList<KeyValuePair<string,int>>();
            //var esDict = eventSequence.ToDictionary((x) => x.Key, (x) => x.Value);

            List<Event> eventList = (from item in dcrEventsXml.Descendants("labelMapping")
                                     select new Event((string)item.Attribute("eventId"), (string)item.Attribute("labelId"))).ToList();
                                    //select new Event(esDict[(string)item.Attribute("eventId")],(string)item.Attribute("labelId"))).ToList();
            return eventList;
        }

        public static void SaveMappings(string filePath,List<DomainKnowledge> listDks)
        {
            //TODO
        }
    }
}
