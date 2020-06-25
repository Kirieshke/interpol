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
using System.Text.RegularExpressions;

namespace Interpol
{
    /// <summary>
    /// Логика взаимодействия для add_info.xaml
    /// </summary>
   
    public partial class add_info : Window
    {
        public static string connectionString = @"Data Source=desktop-r88bk96\sqlexpress;Initial Catalog=Interpol;Integrated Security=True";
        public static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static SqlCommand cmd;/// 


        public add_info()
        {
            InitializeComponent();
            comboBox1.Items.Add("Criminal");
            comboBox1.Items.Add("Grouping");
            comboBox1.Items.Add("Profession");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Criminal")
            {
                insert_criminal_scum();
            }
            else if (comboBox1.SelectedItem.ToString() == "Grouping")
            {  
                insert_groupung_scum();
            }
            else if (comboBox1.SelectedItem.ToString() == "Profession")
            {
                insert_professional_scum();
            }
          
        }
        
        public void criminal_scum_visible()
        {
            surname_lable.Visibility = Visibility.Visible;
            name_lable.Visibility = Visibility.Visible;
            nickname_lable.Visibility = Visibility.Visible;
            address_lable.Visibility = Visibility.Visible;
            status_label.Visibility = Visibility.Visible;
            danger_label.Visibility = Visibility.Visible;
            group_label.Visibility = Visibility.Visible;
            type_label.Visibility = Visibility.Visible;


            surname_textBox.Visibility = Visibility.Visible;
            name_textBox.Visibility = Visibility.Visible;
            nickname_textBox.Visibility = Visibility.Visible;
            address_textBox.Visibility = Visibility.Visible;
            status_textBox.Visibility = Visibility.Visible;
            danger_textBox.Visibility = Visibility.Visible;
            grouping_textBox.Visibility = Visibility.Visible;
            type_textBox.Visibility = Visibility.Visible;
        }

        public void criminal_scum_hidden()
        {
            surname_lable.Visibility = Visibility.Hidden;
            name_lable.Visibility = Visibility.Hidden;
            nickname_lable.Visibility = Visibility.Hidden;
            address_lable.Visibility = Visibility.Hidden;
            status_label.Visibility = Visibility.Hidden;
            danger_label.Visibility = Visibility.Hidden;
            group_label.Visibility = Visibility.Hidden;
            type_label.Visibility = Visibility.Hidden;

            surname_textBox.Visibility = Visibility.Hidden;
            name_textBox.Visibility = Visibility.Hidden;
            nickname_textBox.Visibility = Visibility.Hidden;
            address_textBox.Visibility = Visibility.Hidden;
            status_textBox.Visibility = Visibility.Hidden;
            danger_textBox.Visibility = Visibility.Hidden;
            grouping_textBox.Visibility = Visibility.Hidden;
            type_textBox.Visibility = Visibility.Hidden;
        }

        public void groupung_scum_visible()
        {
            name_Label.Visibility = Visibility.Visible;
            type_Label.Visibility = Visibility.Visible;
            status_Label.Visibility = Visibility.Visible;
            danger_Label.Visibility = Visibility.Visible;

            Name_textBox.Visibility = Visibility.Visible;
            Type_textBox.Visibility = Visibility.Visible;
            Status_textBox.Visibility = Visibility.Visible;
            Danger_textBox.Visibility = Visibility.Visible;
        }

        public void groupung_scum_hidden()
        {
            name_Label.Visibility = Visibility.Hidden;
            type_Label.Visibility = Visibility.Hidden;
            status_Label.Visibility = Visibility.Hidden;
            danger_Label.Visibility = Visibility.Hidden;

            Name_textBox.Visibility = Visibility.Hidden;
            Type_textBox.Visibility = Visibility.Hidden;
            Status_textBox.Visibility = Visibility.Hidden;
            Danger_textBox.Visibility = Visibility.Hidden;
        }

        public void professional_scum_visible()
        {
            name_prof_label.Visibility = Visibility.Visible;
            name_prof_textBox.Visibility = Visibility.Visible;
        }

        public void professional_scum_hidden()
        {
            name_prof_label.Visibility = Visibility.Hidden;
            name_prof_textBox.Visibility = Visibility.Hidden;
        } 
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Criminal")
            {
                professional_scum_hidden();
                groupung_scum_hidden();
                criminal_scum_visible();
            }
            else if (comboBox1.SelectedItem.ToString() == "Grouping")
            {
                professional_scum_hidden(); 
                criminal_scum_hidden();
                groupung_scum_visible();
            }
            else if (comboBox1.SelectedItem.ToString() == "Profession")
            {
                criminal_scum_hidden();
                groupung_scum_hidden();
                professional_scum_visible();
            }
        }

        public void insert_criminal_scum()
        {
            cmd = new SqlCommand("insert into Criminal (Surname, Name, Nickname,  Address, Status, BirthdayDate, DangerLevel, DeathDate) values (@Surname, @Name, @Nickname, @Address, @Status, @BirthdayDate,@DangerLevel, @DeathDate)", sqlConnection);
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@Surname", surname_textBox.Text);
            cmd.Parameters.AddWithValue("@Name", name_textBox.Text);
            cmd.Parameters.AddWithValue("@Nickname", nickname_textBox.Text);
            cmd.Parameters.AddWithValue("@Address", address_textBox.Text);
            cmd.Parameters.AddWithValue("@BirthdayDate",timePicker1.SelectedDate);
            cmd.Parameters.AddWithValue("@DangerLevel", danger_textBox.Text);
            cmd.Parameters.AddWithValue("@DeathDate", timePicker2.SelectedDate);
            cmd.Parameters.AddWithValue("@Status", status_textBox.Text);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Criminal scum Inserted Successfully");

            sqlConnection.Close();

            sqlConnection.Close();
        }

        public void insert_groupung_scum()
        {
            cmd = new SqlCommand("insert into Grouping (Name_Grouping,Type, Status,DangerLevel) values (@Name_Grouping, @Type,@Status,@DangerLevel)", sqlConnection);
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@Name_Grouping", Name_textBox.Text);
            cmd.Parameters.AddWithValue("@Type", Type_textBox.Text);
            cmd.Parameters.AddWithValue("@Status", Status_textBox.Text);
            cmd.Parameters.AddWithValue("@DangerLevel", Danger_textBox.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Grouping scum Inserted Successfully");

            sqlConnection.Close();

            sqlConnection.Close();
        }

        public void insert_professional_scum()
        {
            cmd = new SqlCommand("insert into Profession (Name_Prof) values (@Name_Prof)", sqlConnection);
            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@Name_Prof", name_prof_textBox.Text);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Professional scum Inserted Successfully");

            sqlConnection.Close();

            sqlConnection.Close();
        }

        public void fill_data_grid(DataGrid dg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Surname, Name, Nickname, Criminal.Status, BirthdayDate as 'Birth date', Criminal.DangerLevel, Address, DeathDate as 'Death date', Name_Grouping, Type, Grouping.Status from (Criminal inner join Belongs on Criminal.ID_Criminal = Belongs.ID_Criminal) inner join Grouping on Belongs.ID_Grouping = Grouping.ID_Grouping";
            cmd.Connection = sqlConnection;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Criminal");
            sda.Fill(dt);
            dg.ItemsSource = dt.DefaultView;

            sqlConnection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            check_info check = new check_info();
            dataGrid2.Visibility = Visibility.Visible;
            date_birth_label.Visibility = Visibility.Hidden;
            date_death_label.Visibility = Visibility.Hidden;
            timePicker1.Visibility = Visibility.Hidden;
            timePicker2.Visibility = Visibility.Hidden;
            fill_data_grid(dataGrid2);
        }
    }
}
