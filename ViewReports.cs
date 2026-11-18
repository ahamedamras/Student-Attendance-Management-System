using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace SAMS_Project
{
    public partial class ViewReports : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public ViewReports()
        {
            InitializeComponent();
            SetupComboBox();
        }

        private void SetupComboBox()
        {
            cmbClass.Items.Add("All Classes");
            cmbClass.Items.Add("Semester 1");
            cmbClass.Items.Add("Semester 2");
            cmbClass.Items.Add("Semester 3");
            cmbClass.SelectedIndex = 0;
        }

        
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedDate = dtpFilterDate.Value.ToString("dd-MM-yyyy");
            LoadReport(selectedDate);
        }

        private void LoadReport(string date)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                   
                    string query = @"SELECT A.student_id, S.name, S.class, A.date, A.status 
                                   FROM Attendance A 
                                   INNER JOIN Students S ON A.student_id = S.student_id 
                                   WHERE A.date = @date";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@date", date);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReports.DataSource = dt;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message);
                }
            }
        }

        
        private void UpdateSummary()
        {
            int present = 0;
            int absent = 0;

            foreach (DataGridViewRow row in dgvReports.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    if (row.Cells["status"].Value.ToString() == "Present") present++;
                    else absent++;
                }
            }

            lblPresentCount.Text = "Total Present: " + present;
            lblAbsentCount.Text = "Total Absent: " + absent;
        }

        private void dgvReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dgvReports.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Present")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                    e.CellStyle.ForeColor = System.Drawing.Color.Black;
                }
                else if (status == "Absent")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Attendance_Report_" + DateTime.Now.ToString("ddMMyyyy") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            sw.WriteLine("Student ID, Name, Status, Date");

                            foreach (DataGridViewRow row in dgvReports.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    sw.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value}");
                                }
                            }
                        }
                        MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string selectedDate = dtpFilterDate.Value.ToString("yyyy-MM-dd");

                    string query = @"SELECT a.student_id, s.name, a.status, a.date 
                             FROM Attendance a 
                             JOIN Students s ON a.student_id = s.student_id 
                             WHERE a.date = @date";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@date", selectedDate);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvReports.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No attendance records found for this date.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}