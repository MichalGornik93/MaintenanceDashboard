using System;

namespace MaintenanceDashboard.Data.Api
{
    static class CheckValue
    {
        public static void RequireString(string value)
        {
            if (value == null || value.Trim().Length == 0)
                throw new ArgumentNullException(nameof(value));
        }

        public static void RequireForeignKey(int value)
        {
            if (value == 0)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
