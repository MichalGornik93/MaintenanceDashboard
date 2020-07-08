using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IRegisterToolContext
    {
        void CreateRegisterTool(RegisterTool registerTool);
        ICollection<RegisterTool> GetRegisterToolList();
        void UpdateRegisterTool(RegisterTool registerTool);
        void DeleteRegisterTool(RegisterTool registerTool);
    }
}