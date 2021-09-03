using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class RegulatoryRule
    {
        public Guid RegulatoryRuleID { get; set; }
        public string RuleText { get; set; }

        public RegulatoryRule()
        {

        }

        public RegulatoryRule(string ruleText)
        {
            this.RuleText = ruleText;
            this.RegulatoryRuleID = Guid.NewGuid();
        }
    }
}
