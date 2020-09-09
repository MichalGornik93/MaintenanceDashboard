using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
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

        public void CreatePaddle(Paddle paddle)
        {
            CheckValue.RequireString(paddle.Number);
            CheckValue.RequireString(paddle.Model);
            CheckValue.RequireDateTime(paddle.AddedDate);

            context.Paddles.Add(paddle);
            context.SaveChanges();
        }


        public void UpdatePaddle(Paddle paddle)
        {
            var entity = context.Paddles.Find(paddle.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design.");
            }

            context.Entry(entity).CurrentValues.SetValues(paddle);

            context.SaveChanges();
        }

        public void DeletePaddle(Paddle paddle)
        {
            context.Paddles.Remove(paddle);
            context.SaveChanges();
        }


        public bool CheckIfPaddleExist(string number)
        {
            var result = context.Paddles.FirstOrDefault(c => c.Number == number);
            
            if (result !=null) 
                return true;
            
            return false; 
        }

     
        public ICollection<Paddle> GetPaddleList()
        {
            return context.Paddles.OrderBy(p => p.Id).ToArray();
        }

    }
}
