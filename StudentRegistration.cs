using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SAMS_Project
{
    public partial class StudentRegistration : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void btnRegisterSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegID.Text) || string.IsNullOrWhiteSpace(txtRegUsername.Text) || string.IsNullOrWhiteSpace(txtRegPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        string studentQuery = "INSERT INTO Students (student_id, name, class, contact_no) VALUES (@id, @name, @class, @contact)";
                        SQLiteCommand cmd1 = new SQLiteCommand(studentQuery, conn);
                        cmd1.Parameters.AddWithValue("@id", txtRegID.Text.Trim());
                        cmd1.Parameters.AddWithValue("@name", txtRegName.Text.Trim());
                        cmd1.Parameters.AddWithValue("@class", cmbRegClass.Text);
                        cmd1.Parameters.AddWithValue("@contact", txtRegContact.Text.Trim());
                        cmd1.ExecuteNonQuery();

                        string userQuery = "INSERT INTO Users (username, password, role) VALUES (@user, @pass, 'Student')";
                        SQLiteCommand cmd2 = new SQLiteCommand(userQuery, conn);
                        cmd2.Parameters.AddWithValue("@user", txtRegUsername.Text.Trim());
                        cmd2.Parameters.AddWithValue("@pass", txtRegPassword.Text.Trim());
                        cmd2.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Registration Successful! You can now log in.", "Success");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registration Failed: " + ex.Message);
                }
            }
        }

        private void lnkBackLogin_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void btnRegisterSubmit_Click_1(object sender, EventArgs e)
        {

        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}