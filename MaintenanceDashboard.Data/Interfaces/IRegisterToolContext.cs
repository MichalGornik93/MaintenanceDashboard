using System.Collections.Generic;
using MaintenanceDashboard.Data.Domain;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface IRegisterToolContext
    {
        void CreateRegisterTool(RegisterTool registerTool);
        
        ICollection<RegisterTool> GetRegisterToolList();
        
        void UpdateRegisterTool(RegisterTool registerTool);
        
        void DeleteRegisterTool(RegisterTool registerTool);
    }
}