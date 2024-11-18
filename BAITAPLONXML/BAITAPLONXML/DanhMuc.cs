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
    public partial class DanhMuc : Form
    {
        private DatabaseConnection dbConnection;
        public DanhMuc()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("SORA\\SQLEXPRESS", "Caffe", "sa", "26042004");
        }

        private void DanhMuc_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            LoadDanhMucData();
            textBox1.Enabled = false;
            textBox2.Clear();
        }
        private void LoadDanhMucData()
        {
            string query = "SELECT id AS [Mã danh mục], category_name AS [Tên danh mục] FROM Category";

            try
            {
                dbConnection.OpenConnection();

                using (var reader = dbConnection.ExecuteReader(query))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        // Định dạng cột DataGridView
                        dataGridView1.Columns["Mã danh mục"].Width = 50;
                        dataGridView1.Columns["Tên danh mục"].Width = 200;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu danh mục để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void AddDanhMuc()
        {
            string query = "INSERT INTO Category (category_name) VALUES (@category_name)";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@category_name", textBox3.Text.Trim());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDanhMucData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm danh mục: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void UpdateDanhMuc()
        {
            string query = "UPDATE Category SET category_name = @category_name WHERE id = @id";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@category_name", textBox3.Text.Trim());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDanhMucData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật danh mục: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void DeleteDanhMuc()
        {
            string query = "DELETE FROM Category WHERE id = @id";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@id", textBox1.Text.Trim());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadDanhMucData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void SearchDanhMuc(string keyword)
        {
            string query = $"SELECT id, category_name FROM Category WHERE category_name LIKE '%{keyword}%' OR id LIKE '%{keyword}%'";
            try
            {
                dbConnection.OpenConnection();
                using (var reader = dbConnection.ExecuteReader(query))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                textBox1.Text = row.Cells["Mã danh mục"].Value.ToString(); // Tên cột là "Mã danh mục"
                textBox3.Text = row.Cells["Tên danh mục"].Value.ToString(); // Tên cột là "Tên danh mục"
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDanhMuc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDanhMuc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteDanhMuc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchDanhMuc(textBox2.Text.Trim());
        }
    }
}
