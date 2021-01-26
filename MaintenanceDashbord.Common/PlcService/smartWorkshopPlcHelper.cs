using PlcService.Sharp7;
using System;

namespace MaintenanceDashboard.Common.PlcService
{
    public class SmartWorkshopPlcHelper:BaseS7PlcHelper
    {
        public string Employee
        { get; private set; }
        public string Name { get; private set; }
        public string Action { get; private set; }
        public bool SendTrigger { get; private set; }
        public SmartWorkshopPlcHelper():base(){}
        internal override void DbRead()
        {
            lock (base._locker)
            {
                var buffer = new byte[770]; 
                int result = _client.DBRead(17, 0, buffer.Length, buffer); 
                if (result == 0) //If no error
                {
                    //Casting byte array to value type
                    Employee = S7.GetStringAt(buffer, 0);
                    Name = S7.GetStringAt(buffer, 256);
                    Action = S7.GetStringAt(buffer, 512);
                    SendTrigger = S7.GetBitAt(buffer, 768, 0);
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

                int result = _client.DBWrite(17, 768, 1, buffer);
                if (result!=0)
                    throw new Exception(" Write error S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
}
