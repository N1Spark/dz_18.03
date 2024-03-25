using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using dz_18._03.Command;
using dz_18._03.Model;
using Microsoft.IdentityModel.Tokens;

namespace dz_18._03.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand commandBinding;
        public ObservableCollection<PositionViewModel> positionViewModels { get; set; }
        public ObservableCollection<EmployeeViewModel> employeeViewModels { get; set; }
        public MainViewModel(IQueryable<Position> positions, IQueryable<Employee> employees)
        {
            positionViewModels = new ObservableCollection<PositionViewModel>();
            employeeViewModels = new ObservableCollection<EmployeeViewModel>();
        }

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
        public string nameposition;
        public string Nameposition
        {
            get { return nameposition; }
            set
            {
                nameposition = value;
                OnPropertyChanged(nameof(Nameposition));
            }
        }
        private int positionIdEmployee;
        public int PositionIdEmployee
        {
            get { return positionIdEmployee; }
            set
            {
                positionIdEmployee = value;
                OnPropertyChanged(nameof(PositionIdEmployee));
            }
        }
        private string _userInfo;
        public string UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;
                OnPropertyChanged(nameof(UserInfo));
            }
        }
        public ICommand SearchEmployeePosition 
        {
            get
            {
                if (commandBinding == null)
                    commandBinding = new DelegateCommand(p=> SearchByPosition(), p=> CanSearchByPosition());
                return commandBinding;
            }
        }
        public string oldpositionChange;
        public string OldPositionChange
        {
            get { return oldpositionChange; }
            set
            {
                oldpositionChange = value;
                OnPropertyChanged(nameof(oldpositionChange));
            }
        }

        public string newposition;
        public string NewPositionChange
        {
            get { return newposition; }
            set
            {
                newposition = value;
                OnPropertyChanged(nameof(newposition));
            }
        }
        private int ageEmployee;
        public int AgeEmployee
        {
            get { return ageEmployee; }
            set
            {
                ageEmployee = value;
                OnPropertyChanged(nameof(AgeEmployee));
            }
        }

        private int salaryEmployee;
        public int SalaryEmployee
        {
            get { return salaryEmployee; }
            set
            {
                salaryEmployee = value;
                OnPropertyChanged(nameof(SalaryEmployee));
            }
        }
        public string nameemployee;
        public string NameEmployee
        {
            get { return nameemployee; }
            set
            {
                nameemployee = value;
                OnPropertyChanged(nameof(NameEmployee));
            }

        }
        private string surnameEmployee;
        public string SurnameEmployee
        {
            get { return surnameEmployee; }
            set
            {
                surnameEmployee = value;
                OnPropertyChanged(nameof(SurnameEmployee));
            }
        }
        public string enterPosition;
        public string EnterPosition
        {
            get { return enterPosition; }
            set
            {
                enterPosition = value;
                OnPropertyChanged(nameof(enterPosition));
            }
        }


        public void SearchByPosition()
        {
            using (var context = new ContextEmployeePosition())
            {
                UserInfo = "";
                var employees = context.employee.Where(e => e.position.NamePosition.Contains(Search)).ToList();
                if (employees.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var employee in employees)
                        sb.AppendLine($"Имя: {employee.Name}, Фамилия: {employee.Surname}, Возраст: {employee.Age}, Зарплата: {employee.Salary}");
                    UserInfo = sb.ToString();
                }
                else
                    UserInfo = $"Сотрудников не найден";
            }
        }

        public bool CanSearchByPosition()
        {
            return !string.IsNullOrEmpty(Search);
        }

        public DelegateCommand showAll;
        public ICommand ShowAll
        {
            get
            {
                if (showAll == null)
                    showAll = new DelegateCommand(p => ShowAllEmployee(), p => CanShowAllEmployee());
                return showAll;
            }
        }
        public void ShowAllEmployee()
        {
            using (var context = new ContextEmployeePosition())
            {
                UserInfo = "";
                var employee = context.employee;
                if (employee.IsNullOrEmpty())
                    UserInfo = $"Сотрудников нет";
                foreach (var i in employee)
                    UserInfo += $"Имя: {i.Name}, Фамилия: {i.Surname}, Возраст: {i.Age}, Зарплата: {i.Salary}\n";
            }
        }
        public bool CanShowAllEmployee()
        {
            return true;
        }

        public DelegateCommand findByName;
        public ICommand FindByName
        {
            get 
            {
                if (findByName == null)
                    findByName = new DelegateCommand(p=> SearchByName(), p=> CanSearchByName());
                return findByName;
            }
        }
        public void SearchByName() 
        {
            using (var context = new ContextEmployeePosition())
            {
                UserInfo = "";
                var employee = context.employee.Where(e => e.Name.Contains(Search));
                if (employee.IsNullOrEmpty())
                    UserInfo = $"Сотрудник не найден";
                foreach ( var i in employee)
                        UserInfo += $"Имя: {i.Name}, Фамилия: {i.Surname}, Возраст: {i.Age}, Зарплата: {i.Salary}\n";
            }
        }
        public bool CanSearchByName()
        {
            return !string.IsNullOrEmpty(Search);
        }
        public DelegateCommand changepositionCommand;
        public ICommand CangeCommandPosition
        {
            get 
            {
                if (changepositionCommand == null) 
                    changepositionCommand = new DelegateCommand(p => ChangePosition(), p => CanChangePosition());
                return changepositionCommand;
            }
        }
       

        public void ChangePosition()
        {
            using (var context = new ContextEmployeePosition())
            {
                var oldPositionEntity = context.position.FirstOrDefault(p => p.NamePosition == OldPositionChange);
                if (oldPositionEntity == null)
                {
                    MessageBox.Show($"Позиция не найдена");
                    return;
                }
                else
                {
                    var newPositionEntity = context.position.FirstOrDefault(p => p.NamePosition == NewPositionChange);
                    if (newPositionEntity != null)
                    {
                        MessageBox.Show($"Такаая позиция уже существует!");
                        return;
                    }
                    else
                    {
                        oldPositionEntity.NamePosition = NewPositionChange;
                        context.SaveChanges();
                        MessageBox.Show($"Позиция: {OldPositionChange}, заменена на позицию: {NewPositionChange}");
                    }
                }
            }
        }

        public bool CanChangePosition()
        {
            return !string.IsNullOrEmpty(OldPositionChange);
        }

        public DelegateCommand delegateCommand;
        public ICommand DeletePosition 
        {
            get 
            {
                if (delegateCommand == null)
                    delegateCommand = new DelegateCommand(p => DeletePositionFromDB(), p => CanDeletePosition());
                return delegateCommand;
            }
        }
        public void DeletePositionFromDB()
        {
            using (var context = new ContextEmployeePosition())
            {
                var positionDelete = context.position.FirstOrDefault(pos => pos.NamePosition == EnterPosition);
                if (positionDelete == null)
                {
                    MessageBox.Show($"Позиция не найдена");
                    return;
                }
                else if (positionDelete != null) 
                {
                    context.position.Remove(positionDelete);
                    context.SaveChanges();
                }
                MessageBox.Show($"Позиция удалена");
            }
        }
        public bool CanDeletePosition()
        {
            return !string.IsNullOrEmpty( EnterPosition );
        }

        public DelegateCommand addnewemployee;
        public ICommand AddNewEmployee
        {
            get
            {
                if (addnewemployee == null)
                    addnewemployee = new DelegateCommand(param => AddEmployee(), param => CanAddEmployee());
                return addnewemployee;
            }
        }
        public void AddEmployee()
        {
            Employee employee = new Employee { Name = NameEmployee, Surname = SurnameEmployee, Age = AgeEmployee, Salary = SalaryEmployee, PosititonId = PositionIdEmployee };
            using (var context = new ContextEmployeePosition())
            {
                context.employee.Add(employee);
                context.SaveChanges();
            }
            MessageBox.Show($"Работник добавлен в БД", "Добавление");
        }
        public bool CanAddEmployee()
        {
            return !string.IsNullOrEmpty(NameEmployee) && !string.IsNullOrEmpty(SurnameEmployee);
        }
        public DelegateCommand addnewposition;
        public ICommand AddNewPosition
        {
            get
            {
                if (addnewposition == null)
                    addnewposition = new DelegateCommand(p => AddnewPosition(), p => CanAddnewPosition());
                return addnewposition;
            }
        }
        public void AddnewPosition()
        {
            Position position = new Position { NamePosition = Nameposition };
            using (var context = new ContextEmployeePosition())
            {
                context.position.Add(position);
                context.SaveChanges();
            }
            MessageBox.Show($"Должность добавлена", "Добавление");
        }

        public bool CanAddnewPosition()
        {
            return !string.IsNullOrEmpty(Nameposition);
        }
    }
}
