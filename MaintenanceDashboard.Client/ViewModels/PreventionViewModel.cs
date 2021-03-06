﻿using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class PreventionViewModel : ViewModel
    {
        private readonly PreventionContext context;
        public ObservableCollection<PreventionPattern> Preventions { get; set; }
        public List<Paddle> ReviewPaddles { get; set; }

        public PreventionViewModel(PreventionContext context)
        {
            this.context = context;
            Preventions = new ObservableCollection<PreventionPattern>();
            ReviewPaddles = new List<Paddle>();
            GetReviewComponent();
        }

        private void GetReviewComponent()
        {
            Preventions.Clear();

            foreach (var item in context.GetToWashThermostat())
            {
                Preventions.Add(new PreventionPattern()
                {
                    BarcodeNumber = item.BarcodeNumber,
                    LastPrevention = item.LastWashDate,
                    SerialNumber = item.SerialNumber,
                    Model = item.Model,
                    PreventionDescription = "Wykonać płukanie termostatu"
                });
            }

            foreach (var item in context.GetReviewPaddles())
            {
                Preventions.Add(new PreventionPattern()
                {
                    BarcodeNumber = item.BarcodeNumber,
                    LastPrevention = item.LastPreventionDate,
                    Model = item.Model,
                    PreventionDescription = "Wykonać przegląd paletki"
                });
            }

            foreach (var item in context.GetReviewRobotTools())
            {
                Preventions.Add(new PreventionPattern()
                {
                    BarcodeNumber = item.Number.ToString(),
                    LastPrevention = item.Date,
                    SerialNumber = item.Name,
                    PreventionDescription = "Wykonać przegląd narzedzia robota"
                }); ;
            }
        }

    }

    public class PreventionPattern
    {
        public string BarcodeNumber { get; set; }
        public string SerialNumber { get; set; }
        public string PreventionDescription { get; set; }
        public DateTime LastPrevention { get; set; }
        public string Model { get; set; }
    }
}
