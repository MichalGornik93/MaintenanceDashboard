using MaintenanceDashboard.Common.PlcService;
using PlcService.Sharp7;
using System;

namespace MaintenanceDashbord.Common.PlcService
{
    public class RobotToolsPlcHelper: BaseS7PlcHelper
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsDoubler { get; private set; }
        public bool SendTrigger { get; private set; }
        public string SpendingEmployee { get; private set; }

        public RobotToolsPlcHelper():base(){}

        internal override void DbRead()
        {
            lock (base._locker)
            {
                var buffer = new byte[60];
                int result = _client.DBRead(53, 0, buffer.Length, buffer);
                if (result == 0) //If no error
                {
                    //Casting byte array to value type
                    Number = S7.GetIntAt(buffer, 0);
                    Name = S7.GetStringAt(buffer, 2);
                    IsDoubler = S7.GetBitAt(buffer, 28, 0);
                    SendTrigger = S7.GetBitAt(buffer, 28, 1);
                    SpendingEmployee = S7.GetStringAt(buffer, 30);
                }
                else
                {
                    throw new Exception(" Read error S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
                }
            }
        }
        public void DbWrite()
        {
            lock (_locker)
            {
                var buffer = new byte[1];

                int result = _client.DBWrite(53, 28, 1, buffer);
                if (result != 0)
                    throw new Exception(" Write error S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
}
