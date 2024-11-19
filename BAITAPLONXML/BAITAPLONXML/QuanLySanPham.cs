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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BAITAPLONXML
{
    public partial class QuanLySanPham : Form
    {
        private int selectedProductId = -1;
        public QuanLySanPham()
        {
            InitializeComponent();
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
            SELECT p.id AS [ID], 
                   p.product_name AS [Tên sản phẩm], 
                   c.category_name AS [Danh mục], 
                   p.price AS [Giá], 
                   p.description AS [Mô tả]
            FROM Product p
            INNER JOIN Category c ON p.category_id = c.id";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;

                // Định dạng DataGridView (nếu cần)
                dataGridView1.Columns["ID"].Width = 50; // Đặt độ rộng cột ID
                dataGridView1.Columns["Tên sản phẩm"].Width = 150; // Đặt độ rộng cột Tên sản phẩm
                dataGridView1.Columns["Danh mục"].Width = 100; // Đặt độ rộng cột Danh mục
                dataGridView1.Columns["Giá"].Width = 80; // Đặt độ rộng cột Giá
                dataGridView1.Columns["Mô tả"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Mô tả tự động căn chỉnh

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadCategoriesToComboBox()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Truy vấn danh mục
                string query = "SELECT id, category_name FROM Category";
                SqlCommand command = new SqlCommand(query, db.GetConnection());
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục cũ trong ComboBox
                comboBoxDanhMuc.Items.Clear();

                // Thêm danh mục vào ComboBox
                while (reader.Read())
                {
                    comboBoxDanhMuc.Items.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(reader["id"]),
                        reader["category_name"].ToString()
                    ));
                }

                // Hiển thị tên danh mục
                comboBoxDanhMuc.DisplayMember = "Value"; // Hiển thị tên
                comboBoxDanhMuc.ValueMember = "Key";    // Giá trị ẩn là id

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddProduct()
        {
            try
            {
                // Lấy thông tin từ giao diện
                string productName = txtTenSanPham.Text.Trim();
                int categoryId = ((KeyValuePair<int, string>)comboBoxDanhMuc.SelectedItem).Key; // Lấy id từ ComboBox
                decimal price = Convert.ToDecimal(txtGia.Text);
                string description = txtMoTa.Text.Trim();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(productName) || price <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện INSERT
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                string query = "INSERT INTO Product (product_name, category_id, price, description) " +
                               "VALUES (@productName, @categoryId, @price, @description)";

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@description", description);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView();
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProduct()
        {
            string tenSanPham = txtTenSanPham.Text.Trim();
            string gia = txtGia.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxDanhMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int categoryId = ((KeyValuePair<int, string>)comboBoxDanhMuc.SelectedItem).Key;

            if (string.IsNullOrEmpty(gia) || !decimal.TryParse(gia, out decimal giaDecimal))
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                string query = "UPDATE Product " +
                               "SET product_name = @productName, category_id = @categoryId, price = @price, description = @description " +
                               "WHERE id = @id"; // Sử dụng ID để cập nhật

                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@id", selectedProductId); // Tham số ID
                command.Parameters.AddWithValue("@productName", tenSanPham);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.Parameters.AddWithValue("@price", giaDecimal);
                command.Parameters.AddWithValue("@description", moTa);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteProduct()
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm có ID '{selectedProductId}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                string query = "DELETE FROM Product WHERE id = @id";
                SqlCommand command = new SqlCommand(query, db.GetConnection());
                command.Parameters.AddWithValue("@id", selectedProductId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                db.CloseConnection();

                // Reset selectedProductId sau khi xóa
                selectedProductId = -1;
                txtTenSanPham.Clear();
                txtGia.Clear();
                txtMoTa.Clear();
                comboBoxDanhMuc.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct();
            LoadDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateProduct();
            LoadDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteProduct();
            LoadDataGridView();
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadCategoriesToComboBox();

            if (comboBoxDanhMuc.Items.Count > 0)
            {
                comboBoxDanhMuc.SelectedIndex = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy ID sản phẩm từ cột "ID"
                selectedProductId = Convert.ToInt32(row.Cells["ID"].Value);

                // Đổ dữ liệu vào các ô nhập liệu
                txtTenSanPham.Text = row.Cells["Tên sản phẩm"].Value.ToString();
                txtGia.Text = row.Cells["Giá"].Value.ToString();
                txtMoTa.Text = row.Cells["Mô tả"].Value.ToString();

                // Tìm và chọn danh mục tương ứng trong ComboBox
                string danhMuc = row.Cells["Danh mục"].Value.ToString();
                for (int i = 0; i < comboBoxDanhMuc.Items.Count; i++)
                {
                    var item = (KeyValuePair<int, string>)comboBoxDanhMuc.Items[i];
                    if (item.Value == danhMuc)
                    {
                        comboBoxDanhMuc.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private void SearchProduct()
        {
            string searchKeyword = textBox2.Text.Trim(); // Lấy từ khóa từ TextBox

            if (string.IsNullOrEmpty(searchKeyword))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kết nối với cơ sở dữ liệu
                DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                db.OpenConnection();

                // Tìm kiếm theo từ khóa
                string query = @"
            SELECT p.id AS [ID], 
                   p.product_name AS [Tên sản phẩm], 
                   c.category_name AS [Danh mục], 
                   p.price AS [Giá], 
                   p.description AS [Mô tả]
            FROM Product p
            INNER JOIN Category c ON p.category_id = c.id
            WHERE p.product_name LIKE @keyword";

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
                    MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchProduct();
        }
    }
}
