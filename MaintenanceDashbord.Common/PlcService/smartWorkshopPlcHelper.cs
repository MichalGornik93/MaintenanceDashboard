using PlcService.Sharp7;
using System;
using System.Collections.Generic;

namespace MaintenanceDashboard.Common.PlcService
{
    public class SmartWorkshopPlcHelper : BaseS7PlcHelper
    {
        public string Employee { get; private set; }
        public string Name { get; private set; }
        public string Action { get; private set; }
        public bool SendTrigger { get; private set; }
        public SmartWorkshopPlcHelper() : base() { }
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
                if (result != 0)
                    throw new Exception(" Write error S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
            }
        }

        public List<Object> GetRegisterEquipment()
        {
            var RegisterEquipments = new List<object>();

            lock (base._locker)
            {
                var buffer = new byte[1080];
                int result = _client.DBRead(16, 0, buffer.Length, buffer);
                if (result == 0) //If no error
                {
                    //Start offset
                    int numberAddress = 0;
                    int nameAddress = 2;
                    int statusAddress = 34;
                    const int bitPosition = 0;
                    const int numberOfRecord = 30;

                    for (int i = 0; i < numberOfRecord; i++)
                    {
                        if (!String.IsNullOrEmpty(S7.GetStringAt(buffer, nameAddress)))
                        {
                            RegisterEquipments.Add(new 
                            { 
                                Number = S7.GetSIntAt(buffer, numberAddress), 
                                Name = S7.GetStringAt(buffer, nameAddress), 
                                Status = S7.GetBitAt(buffer, statusAddress, bitPosition) 
                            });
                        }
                        //calculated record lenght
                        numberAddress += 36; 
                        nameAddress += 36;
                        statusAddress += 36;
                    }
                }
                else
                {
                    throw new Exception(" Read error S7-1200 error: " + _client.ErrorText(result) + " Time: " + DateTime.Now.ToString("HH:mm:ss"));
                }
            }
            return RegisterEquipments;
        }
    }
}
