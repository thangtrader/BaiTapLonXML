using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BAITAPLONXML
{
    public partial class QuanLyCaLam : Form
    {
        private DatabaseConnection dbConnection;
        public QuanLyCaLam()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("SORA\\SQLEXPRESS", "Caffe", "sa", "26042004");
        }

        private void QuanLyCaLam_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            LoadShiftData();
            LoadNhanVienToComboBox();
            textBox1.Enabled = false;
        }
        private void LoadNhanVienToComboBox()
        {
            string query = "SELECT id, fullname FROM Staff";

            try
            {
                dbConnection.OpenConnection();
                SqlCommand command = new SqlCommand(query, dbConnection.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                // Gán dữ liệu vào ComboBox
                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "fullname"; // Hiển thị tên nhân viên
                comboBox1.ValueMember = "id";         // Giá trị thực là ID nhân viên
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void LoadShiftData()
        {
            string query = "SELECT s.id, s.shift_name, s.start_time, s.end_time, st.fullname, s.staff_id " +
                           "FROM Shift s " +
                           "LEFT JOIN Staff st ON s.staff_id = st.id";

            try
            {
                dbConnection.OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(query, dbConnection.GetConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ca làm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["id"].Value.ToString(); // Lấy ID ca
                textBox2.Text = row.Cells["shift_name"].Value.ToString();
                textBox3.Text = row.Cells["start_time"].Value.ToString();
                textBox4.Text = row.Cells["end_time"].Value.ToString();

                // Tìm và chọn đúng nhân viên trong ComboBox
                comboBox1.SelectedValue = row.Cells["staff_id"].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Shift (shift_name, start_time, end_time, staff_id) " +
                   "VALUES (@shift_name, @start_time, @end_time, @staff_id)";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@shift_name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@start_time", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@end_time", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@staff_id", comboBox1.SelectedValue);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadShiftData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm ca làm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Shift SET shift_name = @shift_name, start_time = @start_time, " +
                   "end_time = @end_time, staff_id = @staff_id WHERE id = @id";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@shift_name", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@start_time", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@end_time", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@staff_id", comboBox1.SelectedValue);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Sửa ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadShiftData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa ca làm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Shift WHERE id = @id";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim()); // ID của ca làm

                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa ca làm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadShiftData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa ca làm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
