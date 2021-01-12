using MaintenanceDashboard.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.API
{
    public class RetrievedEquipmentContext
    {
        private readonly DataContext context;

        public RetrievedEquipmentContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void Create(RetrievedEquipment retrievedEquipment)
        {
            context.RetrievedEquipments.Add(retrievedEquipment);
            context.SaveChanges();
        }

        public ICollection<RetrievedEquipment> GetAll()
        {
            return context.RetrievedEquipments
                .OrderByDescending(p => p.Date)
                .ToArray();
        }
        public ICollection<RetrievedEquipment> GetFiltredList(string name)
        {
            return context.RetrievedEquipments
                .Where(c => c.Name == name)
                .OrderByDescending(p => p.Date)
                .ToArray();
        }
    }
}
