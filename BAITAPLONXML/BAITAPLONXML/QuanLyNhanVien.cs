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
    public partial class QuanLyNhanVien : Form
    {
        private DatabaseConnection dbConnection;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("SORA\\SQLEXPRESS", "Caffe", "sa", "26042004");
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            LoadStaffData();
            textBox1.Enabled = false;
        }
        
        private void LoadStaffData()
        {
            // Truy vấn dữ liệu nhân viên
            string query = @"SELECT 
                                id AS [ID], 
                                fullname AS [Họ và Tên], 
                                address AS [Địa chỉ], 
                                phone_number AS [Số điện thoại], 
                                date_of_birth AS [Ngày sinh], 
                                cccd AS [CCCD], 
                                email AS [Email], 
                                password AS [Mật khẩu]
                            FROM Staff";

            try
            {
                // Mở kết nối cơ sở dữ liệu
                dbConnection.OpenConnection();

                // Thực thi truy vấn và tải dữ liệu vào DataTable
                using (var reader = dbConnection.ExecuteReader(query))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Gán dữ liệu vào DataGridView
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;

                        // Định dạng cột DataGridView
                        dataGridView1.Columns["ID"].ReadOnly = true;
                        dataGridView1.Columns["Họ và Tên"].Width = 150;
                        dataGridView1.Columns["Địa chỉ"].Width = 200;
                        dataGridView1.Columns["Số điện thoại"].Width = 100;
                        dataGridView1.Columns["Ngày sinh"].Width = 100;
                        dataGridView1.Columns["CCCD"].Width = 100;
                        dataGridView1.Columns["Email"].Width = 150;
                        dataGridView1.Columns["Mật khẩu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Mật khẩu tự động căn chỉnh
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nhân viên để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có vấn đề trong quá trình tải dữ liệu
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối dù có xảy ra lỗi hay không
                dbConnection.CloseConnection();
            }
        }
        private void AddStaff()
        {
            string query = "INSERT INTO Staff (fullname, address, phone_number, date_of_birth, cccd, email, password) " +
                   "VALUES (@FullName, @Address, @Phone, @Birthday, @CCCD, @Email, @Password)";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@FullName", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@Address", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@Phone", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(textBox6.Text.Trim()));
                    command.Parameters.AddWithValue("@CCCD", textBox5.Text.Trim());
                    command.Parameters.AddWithValue("@Email", textBox8.Text.Trim());
                    command.Parameters.AddWithValue("@Password", textBox9.Text.Trim());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadStaffData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void UpdateStaff()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // Kiểm tra xem ID có rỗng không
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Staff SET fullname = @FullName, address = @Address, phone_number = @Phone, " +
                           "date_of_birth = @Birthday, cccd = @CCCD, email = @Email, password = @Password " +
                           "WHERE id = @Id";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@FullName", textBox2.Text.Trim());
                    command.Parameters.AddWithValue("@Address", textBox4.Text.Trim());
                    command.Parameters.AddWithValue("@Phone", textBox3.Text.Trim());
                    command.Parameters.AddWithValue("@Birthday", Convert.ToDateTime(textBox6.Text.Trim()));
                    command.Parameters.AddWithValue("@CCCD", textBox5.Text.Trim());
                    command.Parameters.AddWithValue("@Email", textBox8.Text.Trim());
                    command.Parameters.AddWithValue("@Password", textBox9.Text.Trim());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadStaffData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void DeleteStaff()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // Kiểm tra xem ID có rỗng không
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "DELETE FROM Staff WHERE id = @Id";
            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", textBox1.Text.Trim());

                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadStaffData(); // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
        private void SearchStaff(string keyword)
        {
            string query = @"SELECT id AS [ID], fullname AS [Họ và Tên], address AS [Địa chỉ], 
                     phone_number AS [Số điện thoại], date_of_birth AS [Ngày sinh], 
                     cccd AS [CCCD], email AS [Email], password AS [Mật khẩu] 
                     FROM Staff 
                     WHERE fullname LIKE @Keyword OR id LIKE @Keyword";

            try
            {
                dbConnection.OpenConnection();
                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
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
                textBox1.Text = row.Cells["ID"].Value.ToString(); // Tên cột hiển thị là "ID"
                textBox2.Text = row.Cells["Họ và Tên"].Value.ToString(); // Tên cột hiển thị là "Họ và Tên"
                textBox4.Text = row.Cells["Địa chỉ"].Value.ToString(); // Tên cột hiển thị là "Địa chỉ"
                textBox3.Text = row.Cells["Số điện thoại"].Value.ToString(); // Tên cột hiển thị là "Số điện thoại"
                textBox6.Text = Convert.ToDateTime(row.Cells["Ngày sinh"].Value).ToString("yyyy-MM-dd"); // Tên cột hiển thị là "Ngày sinh"
                textBox5.Text = row.Cells["CCCD"].Value.ToString(); // Tên cột hiển thị là "CCCD"
                textBox8.Text = row.Cells["Email"].Value.ToString(); // Tên cột hiển thị là "Email"
                textBox9.Text = row.Cells["Mật khẩu"].Value.ToString(); // Tên cột hiển thị là "Mật khẩu"
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateStaff();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteStaff();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchStaff(textBox7.Text.Trim());
        }
    }
}
