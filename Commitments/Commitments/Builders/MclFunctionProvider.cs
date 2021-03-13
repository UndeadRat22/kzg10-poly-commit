using System;
using System.Linq;
using System.Reflection;
using MCL.BLS12_381.Net;

namespace Commitments.Builders
{
    public static class MclFunctionProvider
    {
        public static T Provide<T>(string methodName) where T : Delegate
        {
            var importsField = typeof(MclBls12381)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .First(prop => prop.Name == "Imports");

            var importsValue = importsField.GetValue(null);

            var lazyFunctionField = importsValue.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(prop => prop.Name == methodName);

            dynamic function = lazyFunctionField.GetValue(importsValue);

            return function.Value as T;
        }
    }
}