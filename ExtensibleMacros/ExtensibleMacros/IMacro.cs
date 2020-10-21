using System.Collections.Generic;

namespace ExtensibleMacros
{
    #region Extensions
    #endregion

    public interface IMacro
    {
        string Name { get; }
        string GetValue();
        string GetValue(string args, IDictionary<string, string> values = null);

    }
}
