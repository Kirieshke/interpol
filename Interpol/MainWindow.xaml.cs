using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
namespace Interpol
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=desktop-r88bk96\sqlexpress;Initial Catalog=Interpol;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            check_info check_Info = new check_info();
            check_Info.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_info _add = new add_info();
            _add.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            delete_info _delete = new delete_info();
            _delete.Show();
        }
    }
}
