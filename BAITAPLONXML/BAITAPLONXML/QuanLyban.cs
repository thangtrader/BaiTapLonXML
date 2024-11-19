using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAPLONXML
{
    public partial class QuanLyban : Form
    {
        private int selectedTableId = -1;
        public QuanLyban()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateTable();
            LoadDataGridView();
        }
        private void SearchTable(string searchKeyword)
        {
            try
            {
                // Kết nối với cơ sở dữ liệu
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Tìm kiếm theo từ khóa
                string query = @"
            SELECT t.id AS [ID], 
                   t.table_name AS [Tên bàn], 
                   f.floor_name AS [Tầng], 
                   t.number_of_seat AS [Chỗ ngồi],
                   t.description AS [Mô tả]
            FROM Tables t
            INNER JOIN Floors f ON t.floor_id = f.id
                WHERE t.table_name LIKE @keyword";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@keyword", $"%{searchKeyword}%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu vào DataTable
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLyban_Load(object sender, EventArgs e)
        {
            LoadFloorToComboBox();
            LoadDataGridView();
            if (comboBoxFloor.Items.Count > 0)
            {
                comboBoxFloor.SelectedIndex = 0;
            }
        }
        private void LoadDataGridView()
        {
            try
            {
                // Kết nối cơ sở dữ liệu
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Truy vấn dữ liệu từ bảng Products và Categories
                string query = @"
            SELECT t.id AS [ID], 
                   t.table_name AS [Tên bàn], 
                   f.floor_name AS [Tầng], 
                   t.number_of_seat AS [Chỗ ngồi],
                   t.description AS [Mô tả]
            FROM Tables t
            INNER JOIN Floors f ON t.floor_id = f.id";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;

                // Định dạng DataGridView (nếu cần)
                dataGridView1.Columns["ID"].Width = 50; // Đặt độ rộng cột ID
                dataGridView1.Columns["Tên bàn"].Width = 150; // Đặt độ rộng cột Tên sản phẩm
                dataGridView1.Columns["Tầng"].Width = 100; // Đặt độ rộng cột Danh mục
                dataGridView1.Columns["Chỗ ngồi"].Width = 80; // Đặt độ rộng cột Giá
                dataGridView1.Columns["Mô tả"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Mô tả tự động căn chỉnh

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFloorToComboBox()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Truy vấn danh mục
                string query = "SELECT id, floor_name FROM Floors";
                SqlCommand command = new SqlCommand(query, db.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục cũ trong ComboBox
                comboBoxFloor.Items.Clear();

                // Thêm danh mục vào ComboBox
                while (reader.Read())
                {
                    comboBoxFloor.Items.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(reader["id"]),
                        reader["floor_name"].ToString()
                    ));
                }

                // Hiển thị tên danh mục
                comboBoxFloor.DisplayMember = "Value"; // Hiển thị tên
                comboBoxFloor.ValueMember = "Key";    // Giá trị ẩn là id

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTable()
        {
            try
            {
                // Lấy thông tin từ giao diện
                string tableName = textBox1.Text.Trim();
                int floorId = ((KeyValuePair<int, string>)comboBoxFloor.SelectedItem).Key; // Lấy id từ ComboBox
                decimal numberOfSeat = Convert.ToDecimal(textBox3.Text);
                string description = textBox4.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tableName) || numberOfSeat < 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện INSERT
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                string query = "INSERT INTO Tables (table_name, floor_id, number_of_seat, description) " +
                               "VALUES (@table_name, @floor_id, @number_of_seat, @description)";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@table_name", tableName);
                command.Parameters.AddWithValue("@floor_id", floorId);
                command.Parameters.AddWithValue("@number_of_seat", numberOfSeat);
                command.Parameters.AddWithValue("@description", description);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTable()
        {
            string tableName = textBox1.Text.Trim();
            int floorId = ((KeyValuePair<int, string>)comboBoxFloor.SelectedItem).Key;
            decimal numberOfSeat = Convert.ToDecimal(textBox3.Text);
            string description = textBox4.Text.Trim();

            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxFloor.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tầng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                string query = "UPDATE Tables " +
                               "SET table_name = @tableName, floor_id = @floorId, number_of_seat = @numberOfSeat, description = @description " +
                               "WHERE id = @id";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@id", selectedTableId); // Tham số ID
                command.Parameters.AddWithValue("@tableName", tableName);
                command.Parameters.AddWithValue("@floorId", floorId);
                command.Parameters.AddWithValue("@numberOfSeat", numberOfSeat);
                command.Parameters.AddWithValue("@description", description);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteTable()
        {
            if (selectedTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa bàn có ID '{selectedTableId}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                // Kết nối với cơ sở dữ liệu
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Xóa sản phẩm dựa trên ID
                string query = "DELETE FROM Tables WHERE id = @id";
                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@id", selectedTableId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bàn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                db.CloseConnection();

                // Reset selectedProductId sau khi xóa
                selectedTableId = -1;
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBoxFloor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTable();
            LoadDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteTable();
            LoadDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy ID sản phẩm từ cột "ID"
                selectedTableId = Convert.ToInt32(row.Cells["ID"].Value);

                // Đổ dữ liệu vào các ô nhập liệu
                textBox1.Text = row.Cells["Tên bàn"].Value.ToString();
                textBox3.Text = row.Cells["Chỗ ngồi"].Value.ToString();
                textBox4.Text = row.Cells["Mô tả"].Value.ToString();

                // Tìm và chọn danh mục tương ứng trong ComboBox
                string floor = row.Cells["Tầng"].Value.ToString();
                for (int i = 0; i < comboBoxFloor.Items.Count; i++)
                {
                    var item = (KeyValuePair<int, string>)comboBoxFloor.Items[i];
                    if (item.Value == floor)
                    {
                        comboBoxFloor.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = textBox2.Text.Trim();

            // Chỉ tìm kiếm nếu từ khóa không trống
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                SearchTable(searchKeyword);
            }
            else
            {
                // Nếu TextBox rỗng, hiển thị toàn bộ dữ liệu
                LoadDataGridView();
            }
        }
    }
}
