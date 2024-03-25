using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz_18._03.Model;

namespace dz_18._03.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private Employee employee;
        public EmployeeViewModel(Employee employee)
        {
            this.employee = employee;
        }

        public string Name
        {
            get { return employee.Name!; }
            set
            {
                employee.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return employee.Surname!; }
            set
            {
                employee.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public int Age
        {
            get { return employee.Age!; }
            set
            {
                employee.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public int Salary
        {
            get { return employee.Salary!; }
            set
            {
                employee.Salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
    }
}
