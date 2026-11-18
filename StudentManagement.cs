using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SAMS_Project
{
    public partial class StudentManagement : Form
    {
        
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SAMS_Database.db");

        public StudentManagement()
        {
            InitializeComponent();
            LoadStudentData(); 
        }

        
        private void LoadStudentData()
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Students";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Student ID and Name are required.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    
                    string query = "INSERT INTO Students (student_id, name, class, contact_no) VALUES (@id, @name, @class, @contact)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@class", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student registered successfully.");
                    LoadStudentData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        {
            try
            {
               
                DataTable dt = (DataTable)dgvStudents.DataSource;
                if (dt != null)
                {
                   
                    dt.DefaultView.RowFilter = string.Format("student_id LIKE '%{0}%' OR name LIKE '%{0}%'", txtSearch.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            {
                
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Please select or enter a Student ID to delete.");
                    return;
                }

                
                DialogResult confirm = MessageBox.Show("Are you sure you want to remove this student record?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                    {
                        try
                        {
                            conn.Open();
                           
                            string query = "DELETE FROM Students WHERE student_id = @id";
                            SQLiteCommand cmd = new SQLiteCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Student record removed successfully.");
                                ClearFields(); 
                                LoadStudentData(); 
                            }
                            else
                            {
                                MessageBox.Show("Student ID not found.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error during deletion: " + ex.Message);
                        }
                    }
                }
            }
        }


      
        private void ClearFields()
        {
            txtID.Clear();
            txtName.Clear();
            txtClass.Clear();
            txtContact.Clear();
            txtSearch.Clear();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtID.Text = row.Cells["student_id"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                txtClass.Text = row.Cells["class"].Value.ToString();
                txtContact.Text = row.Cells["contact_no"].Value.ToString();
            }
        }
    }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
        {
            
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Student ID and Name.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    
                    string query = "INSERT INTO Students (student_id, name, class, contact_no) VALUES (@id, @name, @class, @contact)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                  
                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@class", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New student record added successfully.");

                    LoadStudentData(); 
                    ClearFields();    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding student: " + ex.Message);
                }
            }
        }
    }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a student record to update.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    conn.Open();
                    
                    string query = "UPDATE Students SET name=@name, class=@class, contact_no=@contact WHERE student_id=@id";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@class", txtClass.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Student details updated successfully.");
                        LoadStudentData(); // Refresh the display
                    }
                    else
                    {
                        MessageBox.Show("Student ID not found in database.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message);
                }
            }
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void StudentManagement_Load(object sender, EventArgs e)
        {

        }
    }
    }