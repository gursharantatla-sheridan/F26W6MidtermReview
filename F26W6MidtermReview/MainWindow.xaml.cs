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
    }
}