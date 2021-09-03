using Bermuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bermuda.Connector
{
    public class BpmnParser
    {
        internal static List<Event> GetEventsFromBpmn(string filePath, bool includeStartEnd = false)
        {
            XElement bpmnXml = XElement.Load(filePath);
            XNamespace bpmn = XNamespace.Get("http://www.omg.org/spec/BPMN/20100524/MODEL");
            var lanes = (from item in bpmnXml.Descendants(bpmn+"lane")
                         select (string)item.Attribute("name")).ToList();

            var laneIdMapping = new Dictionary<string,List<string>>();

            foreach (var lane in lanes)
            {
                var lane_ids = (from item in bpmnXml.Descendants(bpmn + "lane")
                                where item.Attribute("name").Value==lane
                                select (from item2 in item.Descendants(bpmn + "flowNodeRef") select item2.Value)).First().ToList();
                laneIdMapping.Add(lane, lane_ids);
            }

            List<Event> eventList = (from item in bpmnXml.Descendants(bpmn + "task")
                                     select new Event(item.Attribute("id").Value, item.Attribute("name").Value)).ToList();

            if (includeStartEnd)
            {
                eventList.AddRange((from item in bpmnXml.Descendants(bpmn + "startEvent")
                               select new Event(item.Attribute("id").Value, item.Attribute("name").Value)).ToList());
                eventList.AddRange((from item in bpmnXml.Descendants(bpmn + "endEvent")
                                    select new Event(item.Attribute("id").Value, item.Attribute("name").Value)).ToList());
            }

            return eventList;
        }
    }
}
