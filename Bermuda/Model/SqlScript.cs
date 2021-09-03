using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public class SqlScript
    {
        public Guid ScriptID { get; set; }
        public string Sql { get; set; }

        public SqlScript()
        {

        }

        public SqlScript(string script)
        {
            this.Sql = script;
            this.ScriptID = Guid.NewGuid();
        }
    }
}
