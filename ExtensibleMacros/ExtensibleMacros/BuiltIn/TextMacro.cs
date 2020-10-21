using System.Collections.Generic;

namespace ExtensibleMacros
{
    public class TextMacro : IMacro
    {
        public virtual string Name => "$(TEXT)";

        public virtual string GetValue()
        {
            return string.Empty;
        }

        public virtual string GetValue(string args, IDictionary<string, string> values = null)
        {
            return args;
        }
    }
}
