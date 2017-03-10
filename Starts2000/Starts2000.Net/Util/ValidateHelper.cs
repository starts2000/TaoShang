using System;

namespace Starts2000.Net.Util
{
    internal static class ValidateHelper
    {
        public static void CheckNullArgument(string paramName, object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
