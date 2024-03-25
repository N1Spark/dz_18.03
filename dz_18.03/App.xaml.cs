using System.Configuration;
using System.Data;
using System.Windows;
using dz_18._03.Model;
using dz_18._03.ViewModel;

namespace dz_18._03
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            try
            {
                using (var context = new ContextEmployeePosition())
                {
                    var position = from p in context.position
                                   select p;
                    var employee = from emp in context.employee
                                   select emp;
                    MainWindow mainWindow = new MainWindow();
                    MainViewModel viewModel = new MainViewModel(position, employee);
                    mainWindow.DataContext = viewModel;
                    mainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
