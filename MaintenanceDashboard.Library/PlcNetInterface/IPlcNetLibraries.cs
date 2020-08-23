﻿using System;

namespace MaintenanceDashboard.Library
{
    internal interface IPlcNetLibrariesBaseInterface
    {
        string IpAddress { get; set; }
        
        int Rack { get; set; }
        
        int Slot { get; set; }
        
        string PlcLastErrorMessage { get; set; }

        event EventHandler ConnectedHandler;
        
        event EventHandler ErrorHandler;
        
        event EventHandler DisonnectedHandler;

        void RaiseIsConnected();
        
        void RaiseError();
        
        void RaiseInDisonnected();

        bool Connect();
        
        bool Disconnect();

    }
}
