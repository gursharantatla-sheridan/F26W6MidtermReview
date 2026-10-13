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

            GenerateEmployeeData();
            RefreshListBox();
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

        private void RefreshListBox()
        {
            var names = from e in _employees
                        select e.Name;

            lstEmployees.ItemsSource = names;
        }

        private void lstEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstEmployees.SelectedIndex >= 0)
            {
                var selectedEmp = _employees[lstEmployees.SelectedIndex];

                txtId.Text = selectedEmp.Id.ToString();
                txtName.Text = selectedEmp.Name;
                cmbType.Text = selectedEmp.EmpType.ToString();
                chkIsUnionMember.IsChecked = selectedEmp.IsUnionMember;

                lblEarnings.Content = selectedEmp.Earnings().ToString("C");

                if (selectedEmp is HourlyEmployee hrEmp)
                {
                    rdoHourly.IsChecked = true;

                    //HourlyEmployee hrEmp = selectedEmp as HourlyEmployee;

                    txtHoursOrGrossSales.Text = hrEmp.Hours.ToString();
                    txtWageOrCommRate.Text = hrEmp.Wage.ToString();
                }
                else if (selectedEmp is CommissionEmployee commEmp)
                {
                    rdoCommission.IsChecked = true;

                    txtHoursOrGrossSales.Text = commEmp.GrossSales.ToString();
                    txtWageOrCommRate.Text = (commEmp.CommissionRate * 100).ToString();
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lstEmployees.SelectedIndex >= 0)
            {
                // edit existing emp
                EditEmployee();
            }
            else
            {
                // add new emp
                AddEmployee();
            }
        }

        private void EditEmployee()
        {
            var emp = _employees[lstEmployees.SelectedIndex];

            emp.Name = txtName.Text;
            emp.EmpType = (EmployeeType)cmbType.SelectedIndex;
            emp.IsUnionMember = (bool)chkIsUnionMember.IsChecked!;

            if (emp is HourlyEmployee hrEmp)
            {
                hrEmp.Hours = int.Parse(txtHoursOrGrossSales.Text);
                hrEmp.Wage = double.Parse(txtWageOrCommRate.Text);
            }
            else if (emp is CommissionEmployee commEmp)
            {
                commEmp.GrossSales = double.Parse(txtHoursOrGrossSales.Text);
                commEmp.CommissionRate = double.Parse(txtWageOrCommRate.Text) / 100;
            }

            RefreshListBox();
            MessageBox.Show("Employee updated");
        }

        private void AddEmployee()
        {
            int newId = 1;

            if (_employees.Count > 0)
                newId = _employees.Last().Id + 1;  // last emp ID + 1

            string name = txtName.Text;
            EmployeeType empType = (EmployeeType)cmbType.SelectedIndex;
            bool isUnionMember = (bool)chkIsUnionMember.IsChecked!;

            if (rdoHourly.IsChecked == true)
            {
                int hours = int.Parse(txtHoursOrGrossSales.Text);
                double wage = double.Parse(txtWageOrCommRate.Text);

                HourlyEmployee hrEmp = new HourlyEmployee(newId, name, empType, isUnionMember, hours, wage);
                _employees.Add(hrEmp);
            }
            else
            {
                double grossSales = double.Parse(txtHoursOrGrossSales.Text);
                double commRate = double.Parse(txtWageOrCommRate.Text) / 100;

                CommissionEmployee commEmp = new CommissionEmployee(newId, name, empType, isUnionMember, grossSales, commRate);
                _employees.Add(commEmp);
            }

            RefreshListBox();
            MessageBox.Show("New employee added");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var emp = _employees[lstEmployees.SelectedIndex];
            _employees.Remove(emp);

            RefreshListBox();
            ClearData();
            MessageBox.Show("Employee deleted");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            rdoHourly.IsChecked = true;
            txtId.Text = txtName.Text = txtHoursOrGrossSales.Text = txtWageOrCommRate.Text = "";
            cmbType.SelectedIndex = -1;
            chkIsUnionMember.IsChecked = false;
            lblEarnings.Content = "";
        }

        private void btnResetListBox_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            GenerateEmployeeData();
            RefreshListBox();
        }
    }
}