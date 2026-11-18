using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace SAMS_Project
{
    public partial class AlertSettings : Form
    {
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public AlertSettings()
        {
            InitializeComponent();
        }

        private void btnSendAlerts_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string today = DateTime.Now.ToString("yyyy-MM-dd");

                    string query = @"SELECT name, contact_no FROM Students 
                                     WHERE student_id NOT IN (SELECT student_id FROM Attendance WHERE date = @date)";

                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@date", today);

                    DataTable dtAbsentees = new DataTable();
                    da.Fill(dtAbsentees);

                    if (dtAbsentees.Rows.Count > 0)
                    {
                        int successCount = 0;
                        string template = txtMessageBody.Text; 

                        foreach (DataRow row in dtAbsentees.Rows)
                        {
                            string studentName = row["name"].ToString();
                            string phoneNo = row["contact_no"].ToString();

                            string personalizedMessage = template.Replace("[Name]", studentName);

                            Console.WriteLine($"Alert Sent to {phoneNo}: {personalizedMessage}");
                            successCount++;
                        }

                        MessageBox.Show($"{successCount} Alerts processed successfully for today's absentees!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("All students are present today. No alerts to send!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending alerts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
