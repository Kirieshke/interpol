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
    /// Логика взаимодействия для find_criminal.xaml
    /// </summary>
    public partial class find_criminal : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=desktop-r88bk96\sqlexpress;Initial Catalog=Interpol;Integrated Security=True");

        public find_criminal()
        {
            InitializeComponent();
            bindDataGrid();
            ComboBoxFillingSign();
        }

        private void bindDataGrid()
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname, Name, Nickname, Status, BirthdayDate as 'Date of Born', DangerLevel as 'Level of Dangeroud', Address, DeathDate as 'Date of Death' From Criminal";
            cmd.Connection = sqlConnection;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Criminal");
            sda.Fill(dt);
            dataGrid2.ItemsSource = dt.DefaultView;

            sqlConnection.Close();
        }

        private void ComboBoxFillingSign()
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select Special_Signs from Signs Group by Special_Signs Order by Special_Signs";
            cmd1.Connection = sqlConnection;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            string[] Info = new string[dt1.Rows.Count];
            for (int i = 0; i < dt1.Rows.Count; ++i)
            {
                Info[i] = dt1.Rows[i]["Special_Signs"].ToString();

                comboBox4.Items.Add(Info[i]);
            }
            sqlConnection.Close();
        }

        private void Find_Criminal_Scum()
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select Surname, Name, Nickname, Status, BirthdayDate as 'Birth date', DangerLevel, Adress From Criminal inner join Signs on Criminal.ID_Criminal = Signs.ID_Criminal where (Tall between '" + textBox1.Text + "' and '" + textBox2.Text + "') and (EyeColor = '" + textBox3.Text + "' or EyeColor like null) and (HairColor = '" + textBox4.Text + "' or HairColor like null) and (Special_Signs = '" + comboBox4.SelectedItem + "' or Special_Signs = NULL) ";
            cmd1.Connection = sqlConnection;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGrid2.ItemsSource = dt1.DefaultView;

            sqlConnection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Find_Criminal_Scum();
                
        }
    }
}
