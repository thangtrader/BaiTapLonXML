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
    public partial class ChonMon : Form
    {
        public ChonMon()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChonMon_Load(object sender, EventArgs e)
        {
            textBox2.Text = "1";
            textBox2.Enabled = false;
            LoadCategoriesToComboBox();
            comboBoxDanhMuc.SelectedIndexChanged += comboBoxDanhMuc_SelectedIndexChanged;

            if (comboBoxDanhMuc.Items.Count > 0)
            {
                comboBoxDanhMuc.SelectedIndex = 0;
            }
            LoadProductToComboBox();
            if (comboBoxProduct.Items.Count > 0)
            {
                comboBoxProduct.SelectedIndex = 0;
            }
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "STT";
            dataGridView1.Columns[1].Name = "Tên món";
            dataGridView1.Columns[2].Name = "Số lượng";
            dataGridView1.Columns[3].Name = "Đơn giá";
            dataGridView1.Columns[4].Name = "Thành tiền";

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
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

                comboBoxDanhMuc.Items.Clear();

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
        private void LoadProductToComboBox()
        {
            try
            {
                // Lấy id danh mục từ comboBoxDanhMuc
                if (comboBoxDanhMuc.SelectedItem is KeyValuePair<int, string> selectedCategory)
                {
                    int categoryId = selectedCategory.Key;

                    DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008");
                    db.OpenConnection();

                    // Truy vấn sản phẩm dựa theo id danh mục
                    string query = "SELECT id, product_name FROM Product WHERE category_id = @CategoryId";
                    SqlCommand command = new SqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa các mục cũ trong ComboBox
                    comboBoxProduct.Items.Clear();

                    // Thêm sản phẩm vào ComboBox
                    while (reader.Read())
                    {
                        comboBoxProduct.Items.Add(new KeyValuePair<int, string>(
                            Convert.ToInt32(reader["id"]),
                            reader["product_name"].ToString()
                        ));
                    }

                    // Hiển thị tên sản phẩm
                    comboBoxProduct.DisplayMember = "Value";
                    comboBoxProduct.ValueMember = "Key";

                    if (comboBoxProduct.Items.Count > 0)
                    {
                        comboBoxProduct.SelectedIndex = 0; // Chọn mục đầu tiên nếu có sản phẩm
                    }

                    db.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductToComboBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int value = int.Parse(textBox2.Text); // Lấy giá trị hiện tại
            value++; // Tăng giá trị lên 1
            textBox2.Text = value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int value = int.Parse(textBox2.Text); // Lấy giá trị hiện tại
            if (value > 1) // Chỉ giảm nếu giá trị lớn hơn 1
            {
                value--; // Giảm giá trị xuống 1
                textBox2.Text = value.ToString(); // Cập nhật lại TextBox2
            }
        }
        private double GetPriceByProductName(string productName)
        {
            double price = 0; // Giá mặc định là 0 (nếu không tìm thấy hoặc lỗi)

            try
            {
                // Cập nhật chuỗi kết nối với TrustServerCertificate=True
                string connectionString = "Server=LAPTOP-4EGGSF0D;Database=Caffe;User Id=sa;Password=Thang@3008;TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy giá sản phẩm theo tên
                    string query = "SELECT price FROM Product WHERE product_name = @ProductName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName); // Truyền tham số

                        // Thực thi truy vấn và đọc dữ liệu
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("price"))) // Kiểm tra giá trị không null
                        {
                            price = Convert.ToDouble(reader["price"]); // Chuyển đổi giá trị từ cột "price"
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi (nếu có)
                MessageBox.Show($"Lỗi khi lấy giá sản phẩm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return price; // Trả về giá sản phẩm (hoặc 0 nếu không tìm thấy)
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các control
                string productName = comboBoxProduct.Text; // Tên món
                int quantity = int.Parse(textBox2.Text);   // Số lượng

                // Kiểm tra sản phẩm có được chọn hay không
                if (string.IsNullOrEmpty(productName) || quantity < 1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy đơn giá từ cơ sở dữ liệu
                Double unitPrice = GetPriceByProductName(productName);

                if (unitPrice == 0)
                {
                    MessageBox.Show("Không tìm thấy đơn giá cho sản phẩm đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tính thành tiền
                Double totalPrice = quantity * unitPrice;

                // Tính STT (Số thứ tự)
                int stt = dataGridView1.Rows.Count;

                // Thêm dòng mới vào DataGridView
                dataGridView1.Rows.Add(stt, productName, quantity, unitPrice.ToString("N0"), totalPrice.ToString("N0"));

                // Xóa dữ liệu sau khi thêm
                comboBoxProduct.SelectedIndex = -1; // Reset ComboBox
                textBox2.Text = "1";                // Reset TextBox về giá trị mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Owner is Order orderForm)
            {
                // Gửi dữ liệu từ DataGridView trong ChonMon sang Order
                orderForm.AddRowsToOrder(dataGridView1.Rows);
            }

            // Đóng form ChonMon
            this.Close();
        }
    }
}
