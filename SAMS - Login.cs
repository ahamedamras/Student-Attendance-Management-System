using Student_Attendance_Management_System;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SAMS_Project
{
    public partial class Form1 : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public Form1()
        {
            InitializeComponent();

            if (cmbRole.Items.Count > 0)
            {
                cmbRole.SelectedIndex = 0;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file missing! Please check the Debug folder.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT role FROM Users WHERE username=@user AND password=@pass AND role=@role";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string userRole = result.ToString();
                        MessageBox.Show("Welcome! Logged in as: " + userRole, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (userRole == "Admin")
                        {
                            AdminDashboard dash = new AdminDashboard();
                            dash.Show();
                            this.Hide();
                        }
                        else if (userRole == "Student")
                        {
                            string loggedInUser = txtUsername.Text.Trim(); 

                            StudentDashboard stdDash = new StudentDashboard(loggedInUser);
                            stdDash.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials or incorrect role selection.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentRegistration regForm = new StudentRegistration();
            regForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to exit the SAMS System?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}