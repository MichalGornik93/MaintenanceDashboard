using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Data.Api
{
    public sealed class RegisterToolContext : IRegisterToolContext
    {
        private readonly DataContext _context;

        public RegisterToolContext()
        {
            _context = new DataContext();
        }


        public void CreateRegisterTool(RegisterTool registerTool)
        {
            CheckValue.RequireString(registerTool.ToolName);

            _context.RegisterTools.Add(registerTool);
            _context.SaveChanges();
        }


        public void UpdateRegisterTool(RegisterTool registerTool)
        {
            var entity = _context.RegisterTools.Find(registerTool.Id)
                ?? throw new NotImplementedException(ErrorText.UNHANDLED_BY_API);

            _context.Entry(entity).CurrentValues.SetValues(registerTool);

            _context.SaveChanges();
        }

        public void DeleteRegisterTool(RegisterTool registerTool)
        {
            _context.RegisterTools.Remove(registerTool);
            _context.SaveChanges();
        }

        public ICollection<RegisterTool> GetRegisterToolList()
        {
            return _context.RegisterTools.OrderBy(p => p.Id).ToArray();
        }
    }
}
