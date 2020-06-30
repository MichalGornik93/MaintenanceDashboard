﻿using System;

namespace MaintenanceDashboard.Data.Domain
{
    static class CheckString
    {
        public static void Require(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            else if (value.Trim().Length == 0)
                throw new ArgumentException();
        }
    }
}