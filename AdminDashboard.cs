using Student_Attendance_Management_System;
using System;
using System.Windows.Forms;

namespace SAMS_Project
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentManagement smForm = new StudentManagement();
            smForm.Show();
            smForm.Activate();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            AttendanceMarking attendance = new AttendanceMarking();
            attendance.Show();
            attendance.Activate();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ViewReports reportForm = new ViewReports();
            reportForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            AlertSettings settingsForm = new AlertSettings();
            settingsForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();

            login.Show();

            this.Close();
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}