
using System;
using System.Collections.Generic;

namespace ExtensibleMacros
{
    public class TomorrowMacro : IMacro
    {
        public string Name
        {
            get
            {
                return "$(TOMORROW)";
            }
        }

        public virtual string GetValue()
        {
            return DateTime.Today.AddDays(1).ToString("MM-dd-yyyy");
        }

        public virtual string GetValue(string args, IDictionary<string, string> values = null)
        {
            return DateTime.Now.AddDays(1).ToString(args);
        }
    }
}
