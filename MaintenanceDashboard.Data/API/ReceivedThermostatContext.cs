﻿using MaintenanceDashboard.Common.Properties;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard;

namespace MaintenanceDashboard.Data.API
{
    public class ReceivedThermostatContext
    {
        private readonly DataContext context;

        public ReceivedThermostatContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void Receive(ReceivedThermostat receivedThermostat)
        {
            Validator.RequireString(receivedThermostat.ReceivingEmployee);
            Validator.RequireString(receivedThermostat.ActivityPerformed);

            context.ReceivedThermostats.Add(receivedThermostat);
            context.SaveChanges();
        }

        public void Spend(SpendedThermostat spendedThermostat)
        {
            Validator.RequireString(spendedThermostat.ReceivingEmployee);
            Validator.RequireString(spendedThermostat.DescriptionIntervention);
            Validator.RequireString(spendedThermostat.SpendingEmployee);
            Validator.RequireString(spendedThermostat.ActivityPerformed);

            context.SpendedThermostats.Add(spendedThermostat);
            context.SaveChanges();
        }

        public void UpdateOnSpend(ReceivedThermostat receivedThermostat)
        {

            var entity = context.ReceivedThermostats
                .Where(c => c.ThermostatId == receivedThermostat.ThermostatId)
                .FirstOrDefault();

            receivedThermostat.Id = entity.Id;
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(receivedThermostat);
                context.SaveChanges();
            }
        }

        public void UpdateOnReceive(ReceivedThermostat receivedThermostat)
        {
            var entity = context.ReceivedThermostats
                .Where(c => c.ThermostatId == receivedThermostat.ThermostatId)
                .FirstOrDefault();

            receivedThermostat.Id = entity.Id;
            if(entity !=null)
            {
                context.Entry(entity).CurrentValues.SetValues(receivedThermostat);
                context.SaveChanges();
            }

        }

        public void Remove(ReceivedThermostat receivedThermostat)
        {
            context.ReceivedThermostats.Remove(receivedThermostat);
            context.SaveChanges();
        }

        public void SetLastPreventionDate(ReceivedThermostat receivedThermostat)
        {
            if (receivedThermostat.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
                t.LastPreventionDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void SetLastWashDate(ReceivedThermostat receivedThermostat)
        {
            if (receivedThermostat.ActivityPerformed == "Plukanie termostatu" || receivedThermostat.ActivityPerformed == "Awaria")
            {
                var t =
                    (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
                t.LastWashDate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void SetCurrentLocation(ReceivedThermostat receivedThermostat, string currentLocation)
        {
            var t = (from c in context.Thermostats
                    where c.Id == receivedThermostat.ThermostatId
                    select c).First();
            t.CurrentLocation=currentLocation;

            context.SaveChanges();
        }

        public void SetCurrentStatus(ReceivedThermostat receivedThermostat, string currentStatus)
        {
            var t = (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
            t.CurrentStatus = currentStatus;

            context.SaveChanges();
        }

        public int GetId(string number)
        {
            return context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number)
                .Id;
        }

        public bool IsExistInDb(string number)
        {
            var result = context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number);

            if (result == null)
                return true;

            return false;
        }

        public bool IsAccepted(string number)
        {
            var result = context.ReceivedThermostats
                .FirstOrDefault(c => c.Thermostat.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }

        public ICollection<ReceivedThermostat> GetAll()
        {
            return context.ReceivedThermostats
                .OrderBy(p => p.Id)
                .ToArray();
        }
    }
}
