
using System;
using System.Collections.Generic;

namespace ExtensibleMacros
{
    public class YesterdayMacro : IMacro
    {
        public string Name
        {
            get
            {
                return "$(YESTERDAY)";
            }
        }

        public virtual string GetValue()
        {
            return DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy");
        }

        public virtual string GetValue(string args, IDictionary<string, string> values = null)
        {
            return DateTime.Now.AddDays(-1).ToString(args);
        }
    }
}
