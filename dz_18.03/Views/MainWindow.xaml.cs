using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dz_18._03.Model;

namespace dz_18._03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           

            //using (var context = new ContextEmployeePosition())
            //{
            //    context.Database.EnsureCreated();


            //    Position position1 = new Position { NamePosition = "Кибербезопасность" };
            //    context.position.Add(position1);


            //    Employee employee1 = new Employee { Name = "Ivan", Surname = "Denisuk", Age = 22, Salary = 54000, position = position1 };
            //    context.employee.Add(employee1);

            //   /* context.SaveChanges();*/ 
            //}
        }
    }
}