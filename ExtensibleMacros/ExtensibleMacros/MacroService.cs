using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ExtensibleMacros
{
    public sealed class MacroService : IMacroService
    {
        const string TOKEN_PATTERN = @"\$\(([A-Za-z]*([-+]?){0,1}[0-9]*)?\)|\$\(([A-Za-z]*([-+]?){0,1}[0-9]*)?#([A-za-z0-9+-_:,;'=%@\?\s]*)?\)";
        const RegexOptions OPTIONS = RegexOptions.ExplicitCapture | RegexOptions.Singleline;
        readonly Dictionary<string, IMacro> macros;

        readonly IConfiguration _configuration;

        public MacroService()
        {
            //Register
            macros = new Dictionary<string, IMacro>();
            var asm = Assembly.GetExecutingAssembly();
            AddFromAssemblyScan(asm);
        }

        public MacroService(IConfiguration configuration) : this()
        {
            _configuration = configuration;
        }


        public void AddFromAssemblyScan(Assembly asm)
        {
            var types = asm.GetTypes();
            var macroImpls = types.Where(a => a.Implements<IMacro>());

            IMacro instance;

            foreach (var t in macroImpls)
            {
                instance = CreateInstance(t) ?? new EmptyMacro();
                //Already defined macro can be overwritten from this assembly
                macros[instance.Name] = instance;
            }
        }

        private IMacro CreateInstance(Type type)
        {
            IMacro result;
            try
            {
                result = (IMacro)Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                result = null;
                Trace.WriteLine(ex.ToString());
            }
            return result;
        }


        public IEnumerable<string> GetMacroTokens(string inputText)
        {
            var mc = Regex.Matches(inputText, TOKEN_PATTERN, OPTIONS);
            var results = new List<string>();

            foreach (Match item in mc.ToArray())
            {
                results.Add(item.Value);
            }
            return results;
        }

        public IEnumerable<IMacro> GetMacros()
        {
            return macros.Values.AsEnumerable();
        }


        public string ProcessMacros(string inputText, IDictionary<string, string> values = null)
        {
            var result = inputText;
            var tokens = GetMacroTokens(inputText);

            foreach (var item in tokens)
            {
                var macroParts = item.Split('#', 2, StringSplitOptions.None);

                string macroName = string.Empty;
                string macroArgs = string.Empty;

                if (macroParts.Length > 1)
                {
                    macroName = macroParts.Take(1).First() + ")";
                    macroArgs = macroParts.Skip(1).First().Replace(")", string.Empty);
                }
                else if (macroParts.Length == 1)
                {
                    macroName = item;
                }

                macros.TryGetValue(macroName, out IMacro macro);

                if (macro != null)
                {
                    if (string.IsNullOrEmpty(macroArgs))
                    {
                        result = result.Replace(item, macro.GetValue());
                    }
                    else
                    {
                        result = result.Replace(item, macro.GetValue(macroArgs, values));
                    }
                }
            }

            return result;
        }
    }
}
