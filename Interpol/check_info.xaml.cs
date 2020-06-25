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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
namespace Interpol
{
    /// <summary>
    /// Логика взаимодействия для check_info.xaml
    /// </summary>
    public partial class check_info : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=desktop-r88bk96\sqlexpress;Initial Catalog=Interpol;Integrated Security=True");
        public check_info()
        {
            InitializeComponent();

            bindDataGrid(dataGrid1);
            comboBoxFillProfession(comboBox1, comboBox2);
  
        }

        public void bindDataGrid(DataGrid dg)
        {
  
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  Surname, Name, Nickname, Status, Name_Prof as 'Speciality', BirthdayDate as 'Date of Born', DangerLevel as 'Level of Dangeroud', Address, DeathDate as 'Date of Death' from (Criminal inner join Speciality on Criminal.ID_Criminal = Speciality.ID_Criminal) inner join Profession on Speciality.ID_Profession = Profession.ID_Profession Group by Surname, Name, Nickname, Status, BirthdayDate, DangerLevel, Address, DeathDate, Name_Prof";
            cmd.Connection = sqlConnection;
     
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Criminal");
            sda.Fill(dt);
            dg.ItemsSource = dt.DefaultView;

            sqlConnection.Close();
        }

        private void comboBoxFillProfession(ComboBox cb1, ComboBox cb2)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Name_Prof From Profession";
            cmd.Connection = sqlConnection;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string[] _Profession = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                _Profession[i] = dt.Rows[i]["Name_Prof"].ToString();
                cb1.Items.Add(_Profession[i]);
            }
           
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select Name from (Criminal inner join Speciality on Criminal.ID_Criminal = Speciality.ID_Criminal) inner join Profession on Speciality.ID_Profession = Profession.ID_Profession Where Name_Prof = '" + comboBox1.Text + "'";
            cmd1.Connection = sqlConnection;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            string[] Info = new string[dt1.Rows.Count];
            comboBox2.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; ++i)
            {
                Info[i] = dt1.Rows[i]["Name"].ToString();
               
                comboBox2.Items.Add(Info[i]);
            }
            sqlConnection.Close();

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname, Name, Nickname, Status, BirthdayDate as 'Date of Born', DangerLevel as 'Level of Dangeroud', Address, DeathDate as 'Date of Death' From Criminal Where Name = '" + comboBox2.SelectedItem + "'";
            cmd.Connection = sqlConnection;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Criminal");
            sda.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;

            sqlConnection.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bindDataGrid(dataGrid1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            find_criminal _find = new find_criminal();
            _find.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Diagramm diagramm = new Diagramm();
            diagramm.Show();
        }
    }
}
