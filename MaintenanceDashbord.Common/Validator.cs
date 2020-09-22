using System;
using System.Text.RegularExpressions;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Data.API
{
    public static class Validator
    {
        public static void RequireString(string value)
        { 
            if (value == null)
                throw new ArgumentNullException();
            else if (value.Trim().Length == 0)
                throw new ArgumentException();
        }

        public static void RequireDateTime(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            else if (!Regex.IsMatch(value, Resources.DateTimeRegexPattern))
                throw new ArgumentException("Niepoprawny format daty");
        }
    }
}
