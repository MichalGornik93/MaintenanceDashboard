using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Data.Api
{
    public class PaddleContext : IPaddleContext
    {
        private readonly DataContext _context;

        public PaddleContext()
        {
            _context = new DataContext();
        }

        public void CreatePaddle(Paddle paddle)
        {
            CheckValue.RequireString(paddle.Number);
            CheckValue.RequireString(paddle.Model);

            _context.Paddles.Add(paddle);
            _context.SaveChanges();
        }


        public void UpdatePaddle(Paddle paddle)
        {
            var entity = _context.Paddles.Find(paddle.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            _context.Entry(entity).CurrentValues.SetValues(paddle);

            _context.SaveChanges();
        }

        public void DeletePaddle(Paddle paddle)
        {
            _context.Paddles.Remove(paddle);
            _context.SaveChanges();
        }


        public bool CheckPaddleExist(string number)
        {
            var result = _context.Paddles.FirstOrDefault(c => c.Number == number);
            
            if (result !=null) 
                return true;
            
            return false; 
        }

     
        public ICollection<Paddle> GetPaddleList()
        {
            return _context.Paddles.OrderBy(p => p.Id).ToArray();
        }
    }
}
