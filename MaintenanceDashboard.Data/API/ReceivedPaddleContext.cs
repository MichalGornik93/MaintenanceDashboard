using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Data.Api
{

    public class ReceivedPaddleContext : IReceivedPaddleContext
    {
        private readonly DataContext _context;

        public ReceivedPaddleContext()
        {
            _context = new DataContext();
        }

        public void CreateReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            CheckValue.RequireString(receivedPaddle.AddedDate);
            CheckValue.RequireString(receivedPaddle.ActivityPerformed);
            CheckValue.RequireString(receivedPaddle.PlannedRepairDate);
            CheckValue.RequireString(receivedPaddle.IsOrders);
            CheckValue.RequireString(receivedPaddle.ReceivingEmployee);

            _context.ReceivedPaddles.Add(receivedPaddle);
            _context.SaveChanges();
        }

        public Employee CheckEmployee(Employee employee)
        {
            return _context.Employees.FirstOrDefault(c => c.Id == employee.Id);
        }

        public void CreateSpendedPaddle(SpendedPaddle spendedPaddle)
        {
            _context.SpendedPaddles.Add(spendedPaddle);
            _context.SaveChanges();
        }

        public void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            _context.ReceivedPaddles.Remove(receivedPaddle);
            _context.SaveChanges();
        }

        public void UpdateLastPreventionDate(ReceivedPaddle receivedPaddle)
        {
            if (receivedPaddle.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in _context.Paddles
                     where c.Id == receivedPaddle.PaddleId
                     select c).First();
                t.LastPrevention = DateTime.Now.ToString("MM/dd/yyyy");

                _context.SaveChanges();
            }

        }

        public int CheckForeignKey(string number) => _context.Paddles.FirstOrDefault(c => c.Number == number)?.Id ?? 0;

        public bool CheckReceivedPaddleExist(string number) => _context.Paddles.FirstOrDefault(c => c.Number == number) == null;

        public bool CheckIfIsAccepted(string number) => _context.ReceivedPaddles.FirstOrDefault(c => c.Paddle.Number == number) != null;
        
        public ICollection<ReceivedPaddle> GetReceivedPaddleList() => _context.ReceivedPaddles.OrderBy(p => p.Id).ToArray();
    }
}
