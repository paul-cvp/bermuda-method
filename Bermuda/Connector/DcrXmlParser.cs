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

            List<Event> eventList = (from item in dcrEventsXml.Descendants("labelMapping")
                                          select new Event((string)item.Attribute("eventId"),(string)item.Attribute("labelId"))).ToList();
            return eventList;
        }

        public static void SaveMappings(string filePath,List<DomainKnowledge> listDks)
        {
            //TODO
        }
    }
}
