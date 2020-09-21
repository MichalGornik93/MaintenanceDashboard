﻿using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Data.Models;

namespace MaintenanceDashboard.Data.API
{
    public class PaddleContext
    {
        private readonly DataContext context;

        public PaddleContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void Create(Paddle paddle)
        {
            CheckValue.RequireString(paddle.BarcodeNumber);
            CheckValue.RequireString(paddle.Model);
            CheckValue.RequireDateTime(paddle.AddedDate);

            context.Paddles.Add(paddle);
            context.SaveChanges();
        }


        public void Update(Paddle paddle)
        {
            var entity = context.Paddles.Find(paddle.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design.");
            }

            context.Entry(entity).CurrentValues.SetValues(paddle);
            context.SaveChanges();
        }

        public bool CheckIfExistInDb(string number)
        {
            var result = context.Paddles
                .FirstOrDefault(c => c.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }


        public ICollection<Paddle> GetAll()
        {
            return context.Paddles
                .OrderBy(p => p.Id)
                .ToArray();
        }

    }
}
