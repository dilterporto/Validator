using System;
using System.Linq;
using System.Reflection;
using Validator.Helpers;

namespace Validator.Extensions
{
    internal static class MemberInfoExtensions
    {
        public static T[] GetCustomAttributes<T>(this MemberInfo methodInfo, bool inherit)
            where T : Attribute
        {
            Checker.ArgumentIsNull(methodInfo, "methodInfo");

            return 
                methodInfo.GetCustomAttributes(typeof(T), inherit)
                    .Cast<T>()
                    .ToArray();
        }
    }
}
