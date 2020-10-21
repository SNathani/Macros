
using System;
using System.Collections.Generic;

namespace ExtensibleMacros
{
    public class TimeMacro : IMacro
    {
        public string Name
        {
            get
            {
                return "$(TIME)";
            }
        }

        public virtual string GetValue()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }

        public virtual string GetValue(string args, IDictionary<string, string> values = null)
        {
            return DateTime.Now.ToString(args);
        }
    }
}
