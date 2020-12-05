using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class DomainKnowledge
    {
        public DomainKnowledge()
        {

        }
        public DomainKnowledge(Screenshot scr, RegulatoryRule rr, SqlScript sql, Event e)
        {
            ScreenshotImage = scr;
            SqlScript = sql;
            RegulatoryRule = rr;
            Event = e;
        }

        public Screenshot ScreenshotImage { get; set; }
        public SqlScript SqlScript { get; set; }
        public RegulatoryRule RegulatoryRule { get; set; }
        public Event Event { get; set; }
    }
}
