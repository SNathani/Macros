using System.Collections.Generic;
using System.Reflection;

namespace ExtensibleMacros
{
    public interface IMacroService
    {
        /// <summary>
        /// Adds IMacro implementations from the provided assembly
        /// </summary>
        /// <param name="asm"></param>
        void AddFromAssemblyScan(Assembly asm);

        /// <summary>
        /// Gets a list of all macros registered. 
        /// Names are unique and macros can be overridden with the same name to override the implementations
        /// </summary>
        /// <returns></returns>
        IEnumerable<IMacro> GetMacros();

        /// <summary>
        /// Gets a list of tokens parsed from a given inputText
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        IEnumerable<string> GetMacroTokens(string inputText);

        /// <summary>
        /// Applies macro values by replacing the tokens found in the inputText
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        string ProcessMacros(string inputText, IDictionary<string, string> values = null);
    }
}
