using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SAMS_Project
{
    public partial class StudentDashboard : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");
        string currentStudentName = "";

        public StudentDashboard(string studentName)
        {
            InitializeComponent();
            currentStudentName = studentName;
            lblWelcome.Text = "Welcome, " + currentStudentName;

            LoadStudentData();
        }

        private void LoadStudentData()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT date, status FROM Attendance WHERE student_id = (SELECT student_id FROM Students WHERE name = @name)";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@name", currentStudentName);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMyAttendance.DataSource = dt;

                    CalculateStats(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void CalculateStats(DataTable dt)
        {
            int totalPresent = dt.Rows.Count;

            int totalWorkingDays = 30;

            double percentage = (double)totalPresent / totalWorkingDays * 100;

            lblPresentDays.Text = "Total Present: " + totalPresent;
            lblPercentage.Text = $"Attendance: {percentage:F2}%";

            if (percentage < 75)
            {
                lblPercentage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblPercentage.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}