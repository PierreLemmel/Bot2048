using System;

namespace Bot2048.Core
{
    public static class Check
    {
        public static void NotNull(object param, string paramName = "")
        {
            if (param is null) throw new ArgumentNullException(paramName);
        }
    }
}