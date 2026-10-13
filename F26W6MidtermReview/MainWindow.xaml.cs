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

namespace F26W6MidtermReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> _employees;

        public MainWindow()
        {
            InitializeComponent();

            rdoHourly.IsChecked = true;
            lblPercentageSymbol.Visibility = Visibility.Hidden;
        }

        private void rdoHourly_Checked(object sender, RoutedEventArgs e)
        {
            lblHoursOrGrossSales.Content = "Hours";
            lblWageOrCommRate.Content = "Wage";
            lblPercentageSymbol.Visibility = Visibility.Hidden;
        }

        private void rdoCommission_Checked(object sender, RoutedEventArgs e)
        {
            lblHoursOrGrossSales.Content = "Gross Sales";
            lblWageOrCommRate.Content = "Commission Rate";
            lblPercentageSymbol.Visibility = Visibility.Visible;
        }

        private void GenerateEmployeeData()
        {
            _employees = new List<Employee>()
            {
                // hourly emps
                new HourlyEmployee(1, "John", EmployeeType.FullTime, true, 40, 30),
                new HourlyEmployee(2, "Anne", EmployeeType.PartTime, true, 55, 20),
                new HourlyEmployee(3, "Mark", EmployeeType.Contractor, false, 30, 18),

                // comm emps
                new CommissionEmployee(4, "Alice", EmployeeType.FullTime, true, 15000, 0.12),
                new CommissionEmployee(5, "James", EmployeeType.FullTime, true, 10000, 0.10),
                new CommissionEmployee(6, "Megan", EmployeeType.PartTime, false, 12000, 0.08)
            };
        }
    }
}