using System.Collections.Generic;

namespace ExtensibleMacros
{
    // ------------- ---------------- -------------- ---------------- -----------------
    public sealed class ArgsMacro : TextMacro
    {
        public override string Name => "$(ARGS)";

        public override string GetValue(string args, IDictionary<string, string> values = null)
        {
            string result = string.Empty;
            if (values.ContainsKey(args))
            {
                result = values[args];
            }
            return result;
        }
    }
}
