
using System;
using System.Collections.Generic;

namespace ExtensibleMacros
{
    public class TodayMacro : IMacro
    {
        public string Name
        {
            get
            {
                return "$(TODAY)";
            }
        }

        public virtual string GetValue()
        {
            return DateTime.Today.ToString("MM-dd-yyyy");
        }

        public virtual string GetValue(string args, IDictionary<string, string> values = null)
        {
            return DateTime.Now.ToString(args);
        }
    }
}
