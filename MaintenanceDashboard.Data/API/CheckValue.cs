using System;

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
    }
}
