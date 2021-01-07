using MaintenanceDashboard.Data.Models;

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
    }
}
