﻿using System;
using System.Text.RegularExpressions;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Data.Api
{
    static class CheckValue
    {
        public static void RequireString(string value)
        {
            //TODO: Add any MassageBox
            if (value == null)
                throw new ArgumentNullException();
            else if (value.Trim().Length == 0)
                throw new ArgumentException();
        }

        public static void RequireForeignKey(int value)
        {
            if (value == null)
                throw new ArgumentNullException();
            else if (value == 0)
                throw new ArgumentException();
        }

        public static void RequireDateTime(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            else if (!Regex.IsMatch(value, Resources.DateTimeRegexPattern))
                throw new ArgumentException("Incompatible date format");
        }
    }
}
