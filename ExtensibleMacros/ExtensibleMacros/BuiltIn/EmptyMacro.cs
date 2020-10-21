using System.Collections.Generic;

namespace ExtensibleMacros
{
    public sealed class EmptyMacro : IMacro
    {
        public string Name => "$()";

        public string GetValue()
        {
            return string.Empty;
        }

        public string GetValue(string args, IDictionary<string, string> values = null)
        {
            return string.Empty;
        }
    }
}
