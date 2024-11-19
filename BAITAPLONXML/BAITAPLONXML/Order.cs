using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BAITAPLONXML
{
    public partial class Order : Form
    {
        public string SelectedTableName { get; set; }

        public Order()
        {
            InitializeComponent();
        }

        // Cập nhật tổng tiền
        private void UpdateTotalAmount()
        {
            double total = 0;

            foreach (DataGridViewRow row in dvgOrder.Rows)
            {
                if (row.Cells["Thành tiền"].Value != null &&
                    double.TryParse(row.Cells["Thành tiền"].Value.ToString(), out double value))
                {
                    total += value;
                }
            }

            textBox6.Text = total.ToString("N0"); // Hiển thị tổng tiền định dạng tiền tệ
        }

        // Sự kiện khi form được tải
        private void Order_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedTableName))
            {
                labelSelectedTable.Text = $"Bàn: {SelectedTableName}";
            }

            textBox1.Enabled = false;
            textBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBox6.Enabled = false;

            LoadStaffToComboBox();
            RefreshTableStatus();
            ConfigureOrderDataGridView();
        }

        // Cấu hình DataGridView
        private void ConfigureOrderDataGridView()
        {
            dvgOrder.DataSource = null;

            dvgOrder.ColumnCount = 5;
            dvgOrder.Columns[0].Name = "STT";
            dvgOrder.Columns[1].Name = "Tên món";
            dvgOrder.Columns[2].Name = "Số lượng";
            dvgOrder.Columns[3].Name = "Đơn giá";
            dvgOrder.Columns[4].Name = "Thành tiền";

            dvgOrder.Columns[0].Width = 50;
            dvgOrder.Columns[1].Width = 200;
            dvgOrder.Columns[2].Width = 100;
            dvgOrder.Columns[3].Width = 100;
            dvgOrder.Columns[4].Width = 100;
        }


        // Tải danh sách nhân viên vào ComboBox
        private void LoadStaffToComboBox()
        {
            try
            {
                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();
                    var query = "SELECT fullname FROM Staff";
                    using (var reader = db.ExecuteReader(query))
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["fullname"].ToString());
                        }
                    }
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mở form chọn món
        private void button1_Click(object sender, EventArgs e)
        {
            ChonMon chonMon = new ChonMon
            {
                Owner = this
            };
            chonMon.ShowDialog();
        }

        // Thêm món vào DataGridView
        public void AddRowsToOrder(DataGridViewRowCollection rows)
        {
            try
            {
                foreach (DataGridViewRow row in rows)
                {
                    if (!row.IsNewRow)
                    {
                        int newRowIndex = dvgOrder.Rows.Add();
                        dvgOrder.Rows[newRowIndex].Cells["STT"].Value = row.Cells["STT"].Value;
                        dvgOrder.Rows[newRowIndex].Cells["Tên món"].Value = row.Cells["Tên món"].Value;
                        dvgOrder.Rows[newRowIndex].Cells["Số lượng"].Value = row.Cells["Số lượng"].Value;
                        dvgOrder.Rows[newRowIndex].Cells["Đơn giá"].Value = row.Cells["Đơn giá"].Value;
                        dvgOrder.Rows[newRowIndex].Cells["Thành tiền"].Value = row.Cells["Thành tiền"].Value;
                    }
                }

                UpdateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lưu thông tin order
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SelectedTableName))
                {
                    MessageBox.Show("Vui lòng chọn bàn trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string staffName = comboBox1.SelectedItem?.ToString();
                string note = textBox2.Text;
                DateTime orderDate = DateTime.Now;
                int tableId = GetTableIdByName(SelectedTableName);

                if (tableId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int staffId = GetStaffIdByName(staffName);
                if (staffId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string insertOrderQuery = @"
                        INSERT INTO Orders (staff_id, note, order_date)
                        VALUES (@staffId, @note, @orderDate);
                        SELECT SCOPE_IDENTITY();";

                    var orderCmd = new SqlCommand(insertOrderQuery, db.GetConnection());
                    orderCmd.Parameters.AddWithValue("@staffId", staffId);
                    orderCmd.Parameters.AddWithValue("@note", string.IsNullOrEmpty(note) ? DBNull.Value : note);
                    orderCmd.Parameters.AddWithValue("@orderDate", orderDate);

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    foreach (DataGridViewRow row in dvgOrder.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int productId = GetProductIdByName(row.Cells["Tên món"].Value.ToString());
                            int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
                            double price = Convert.ToDouble(row.Cells["Đơn giá"].Value);
                            double totalMoney = Convert.ToDouble(row.Cells["Thành tiền"].Value);

                            string insertOrderDetailQuery = @"
                                INSERT INTO Order_Detail (order_id, product_id, price, number_of_product, total_money, order_date, table_id)
                                VALUES (@orderId, @productId, @price, @quantity, @totalMoney, @orderDate, @tableId)";

                            var detailCmd = new SqlCommand(insertOrderDetailQuery, db.GetConnection());
                            detailCmd.Parameters.AddWithValue("@orderId", orderId);
                            detailCmd.Parameters.AddWithValue("@productId", productId);
                            detailCmd.Parameters.AddWithValue("@price", price);
                            detailCmd.Parameters.AddWithValue("@quantity", quantity);
                            detailCmd.Parameters.AddWithValue("@totalMoney", totalMoney);
                            detailCmd.Parameters.AddWithValue("@orderDate", orderDate);
                            detailCmd.Parameters.AddWithValue("@tableId", tableId);

                            detailCmd.ExecuteNonQuery();
                        }
                    }

                    string updateTableQuery = "UPDATE Tables SET status = 0 WHERE id = @tableId";
                    var updateTableCmd = new SqlCommand(updateTableQuery, db.GetConnection());
                    updateTableCmd.Parameters.AddWithValue("@tableId", tableId);
                    updateTableCmd.ExecuteNonQuery();

                    MessageBox.Show("Lưu đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu đơn hàng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetTableIdByName(string tableName)
        {
            try
            {
                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();
                    string query = "SELECT id FROM Tables WHERE table_name = @tableName";
                    var cmd = new SqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@tableName", tableName);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy ID bàn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        // Lấy ID nhân viên
        private int GetStaffIdByName(string staffName)
        {
            try
            {
                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();
                    string query = "SELECT id FROM Staff WHERE fullname = @staffName";
                    var cmd = new SqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@staffName", staffName);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }

        // Lấy ID món dựa trên tên
        private int GetProductIdByName(string productName)
        {
            try
            {
                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();
                    string query = "SELECT id FROM Product WHERE product_name = @productName";
                    var cmd = new SqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@productName", productName);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        // Thanh toán hóa đơn
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(SelectedTableName))
                {
                    MessageBox.Show("Vui lòng chọn bàn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dvgOrder.Rows.Count == 0)
                {
                    MessageBox.Show("Không có món ăn nào trong đơn hàng để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int tableId = GetTableIdByName(SelectedTableName);
                if (tableId == -1)
                {
                    MessageBox.Show("Không tìm thấy thông tin bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    // Cập nhật trạng thái paid ở Order_Detail
                    string updateOrderDetailQuery = "UPDATE Order_Detail SET paid = 1 WHERE table_id = @tableId AND paid = 0";
                    var updateOrderDetailCmd = new SqlCommand(updateOrderDetailQuery, db.GetConnection());
                    updateOrderDetailCmd.Parameters.AddWithValue("@tableId", tableId);
                    updateOrderDetailCmd.ExecuteNonQuery();

                    // Cập nhật trạng thái bàn
                    string updateTableQuery = "UPDATE Tables SET status = 1 WHERE id = @tableId";
                    var updateTableCmd = new SqlCommand(updateTableQuery, db.GetConnection());
                    updateTableCmd.Parameters.AddWithValue("@tableId", tableId);
                    updateTableCmd.ExecuteNonQuery();

                    // Xóa dữ liệu trong DataGridView
                    dvgOrder.Rows.Clear();
                    textBox6.Clear();

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadOrderData()
        {
            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = @"
                SELECT 
                    Product.product_name AS 'Tên món', 
                    Order_Detail.number_of_product AS 'Số lượng', 
                    Order_Detail.price AS 'Đơn giá', 
                    (Order_Detail.price * Order_Detail.number_of_product) AS 'Thành tiền'
                FROM Order_Detail
                INNER JOIN Product ON Order_Detail.product_id = Product.id
                WHERE Order_Detail.table_id = @tableId AND Order_Detail.paid = 0";

                    SqlCommand command = new SqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@tableId", GetTableIdByName(SelectedTableName));

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dvgOrder.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đơn hàng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateNewOrder()
        {
            try
            {
                // Xóa dữ liệu trong DataGridView
                dvgOrder.DataSource = null;
                dvgOrder.Rows.Clear();

                // Cập nhật ngày giờ hiện tại
                textBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");

                // Đặt tổng tiền về 0
                textBox6.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng mới: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Owner is QuanLy parentForm)
            //{
            //    parentForm.RefreshTableStatus();
            //}
        }
        // Phương thức để refresh trạng thái bàn
        public void RefreshTableStatus()
        {
            try
            {
                if (string.IsNullOrEmpty(SelectedTableName))
                {
                    labelSelectedTable.Text = "Chưa chọn bàn";
                    return;
                }

                int tableId = GetTableIdByName(SelectedTableName);
                if (tableId == -1)
                {
                    labelSelectedTable.Text = "Không tìm thấy thông tin bàn.";
                    return;
                }

                using (var db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();
                    string query = "SELECT status FROM Tables WHERE id = @tableId";
                    var cmd = new SqlCommand(query, db.GetConnection());
                    cmd.Parameters.AddWithValue("@tableId", tableId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int status))
                    {
                        // 0: đang sử dụng, 1: trống
                        labelSelectedTable.Text = status == 0
                            ? $"Bàn {SelectedTableName} - Đang sử dụng"
                            : $"Bàn {SelectedTableName} - Trống";
                    }
                    else
                    {
                        labelSelectedTable.Text = "Không thể lấy trạng thái bàn.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới trạng thái bàn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}