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
    /// Логика взаимодействия для update_info.xaml
    /// </summary>
    public partial class delete_info : Window
    {
        public static string connectionString = @"Data Source=desktop-r88bk96\sqlexpress;Initial Catalog=Interpol;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;

        public delete_info()
        {
            InitializeComponent();
            comboBox1.Items.Add("Criminal");
            comboBox1.Items.Add("Grouping");
            comboBox1.Items.Add("Professional");

            
        }

        public void fill_criminal_scum_box()
        {
            InitializeComponent();
            comboBox2.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Criminal";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string[] Criminal = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Criminal[i] = dt.Rows[i]["ID_Criminal"].ToString() + "." + dt.Rows[i]["Name"].ToString() + dt.Rows[i]["Surname"].ToString();
                comboBox2.Items.Add(Criminal[i]);
            }
            sqlConnection.Close();
        }

        public void fill_profession_scum_box()
        {
            InitializeComponent();
            comboBox2.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Profession";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string[] Professional = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Professional[i] = dt.Rows[i]["ID_Profession"].ToString() + "." + dt.Rows[i]["Name_Prof"].ToString();
                comboBox2.Items.Add(Professional[i]);
            }
            sqlConnection.Close();
        }

        public void fill_grouping_scum_box()
        {
            InitializeComponent();
            comboBox2.Items.Clear();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Grouping";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            string[] Grouping = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                Grouping[i] = dt.Rows[i]["ID_Grouping"].ToString() + "." + dt.Rows[i]["Name_Grouping"].ToString();
                comboBox2.Items.Add(Grouping[i]);
            }
            sqlConnection.Close();
        }

        public void delete_criminal_scum(ComboBox cb1)
        {
            string[] sq = cb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Criminal where ID_Criminal = @ID_Criminal", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Criminal", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Criminal scum Deleted Successfully!");

            }
        }
        
        public void delete_professional_scum(ComboBox cb1)
        {
            string[] sq = cb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Profession where ID_Profession = @ID_Profession", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Profession", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Profession scum Deleted Successfully!");

            }
        }

        public void delete_grouping_scum(ComboBox cb1)
        {
            string[] sq = cb1.Text.Split(new char[] { '.' });
            for (int i = 0; i < sq.Length; ++i)
            {
                cmd = new SqlCommand("delete from Grouping where ID_Grouping = @ID_Grouping", sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@ID_Grouping", sq[0]);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Grouping scum Deleted Successfully!");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Criminal")
            {
                delete_criminal_scum(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Professional")
            {
                delete_professional_scum(comboBox2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Grouping")
            {
                delete_grouping_scum(comboBox2);
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            label1.Visibility = Visibility.Visible;
            comboBox2.Visibility = Visibility.Visible;

            if (comboBox1.SelectedItem.ToString() == "Criminal")
            {
                fill_criminal_scum_box();
            }
            if (comboBox1.SelectedItem.ToString() == "Professional")
            {
                fill_profession_scum_box();
            }
            if (comboBox1.SelectedItem.ToString() == "Grouping")
            {
                fill_grouping_scum_box();
            }
        }
    }
}
