using System.Linq;

namespace MaintenanceDashboard.Data.API
{
    public static class BarcodeNumber
    {
        public static int ParseBarcodeNumberToInt(string barcodeNumber)
        {
            int.TryParse(new string(barcodeNumber
                .SkipWhile(x => !char.IsDigit(x))
                .TakeWhile(x => char.IsDigit(x))
                .ToArray()), out int number);
            number++;
            return number;
        }
    }
}
