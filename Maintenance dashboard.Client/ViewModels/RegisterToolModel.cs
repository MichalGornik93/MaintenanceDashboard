using MaintenanceDashbord.Library;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceDashboard.Client
{
    public class RegisterToolModel:ViewModel
    {
        private string employeeName;

        [Required]
        [StringLength(32, MinimumLength =2)]
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                NotifyPropertyChanged();
            }
        }
	}
}
