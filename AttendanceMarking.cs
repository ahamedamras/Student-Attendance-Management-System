using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Drawing; 

namespace SAMS_Project
{
    public partial class AttendanceMarking : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public AttendanceMarking()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            LoadTodayAttendance();
        }

        private void txtStudentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Enter Key Pressed!");

                string studentID = txtStudentID.Text.Trim();
                MarkAttendance(studentID);
                if (e.KeyCode == Keys.Enter)
                {
                    studentID = txtStudentID.Text.Trim();
                    if (!string.IsNullOrEmpty(studentID))
                    {
                        MarkAttendance(studentID);
                        txtStudentID.Clear();
                        txtStudentID.Focus();
                    }

                    e.SuppressKeyPress = true;
                }
            }
        }

        private void MarkAttendance(string id)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string today = DateTime.Now.ToString("yyyy-MM-dd");

                    string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE student_id = @id AND date = @date";
                    SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", id);
                    checkCmd.Parameters.AddWithValue("@date", today);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        lblStatus.Text = "Already Marked for Today!";
                        lblStatus.BackColor = Color.Orange;
                    }
                    else
                    {
                        string query = "INSERT INTO Attendance (student_id, date, status) VALUES (@id, @date, 'Present')";
                        SQLiteCommand cmd = new SQLiteCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@date", today);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            lblStatus.Text = "Success: Attendance marked for ID " + id;
                            lblStatus.BackColor = Color.Green;
                            lblStatus.ForeColor = Color.White;

                            LoadTodayAttendance();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                    lblStatus.BackColor = Color.Red;
                }
            }
        }

        private void LoadTodayAttendance()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string today = DateTime.Now.ToString("yyyy-MM-dd");

                    string query = @"SELECT a.student_id AS 'ID', s.name AS 'Student Name', a.date AS 'Date', a.status AS 'Status' 
                                   FROM Attendance a 
                                   JOIN Students s ON a.student_id = s.student_id 
                                   WHERE a.date = @date";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@date", today);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTodayAttendance.DataSource = dt;
                }
                catch
                {
                  
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblStatus1_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTodayAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}