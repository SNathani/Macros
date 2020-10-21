
using System;

namespace ExtensibleMacros
{
    internal static class AssemblyExtensions
    {
        internal static bool Implements<T>(this Type type)
        {
            return (typeof(T).IsAssignableFrom(type) && type.IsInterface == false);
        }
    }
}
