using Microsoft.Data.SqlClient;
using System.Data;
namespace BAITAPLONXML
{
    public partial class DangNhap : Form
    {
        private DatabaseConnection dbConnection;

        public DangNhap()
        {
            InitializeComponent();
            // Khởi tạo kết nối với database
            dbConnection = new DatabaseConnection("SORA\\SQLEXPRESS", "Caffe", "sa", "26042004");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT id, fullname, role_id FROM Staff WHERE email = @Email AND password = @Password";

            try
            {
                // Mở kết nối
                dbConnection.OpenConnection();

                using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
                {
                    // Gán tham số cho câu lệnh SQL
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    // Thực thi câu lệnh và đọc kết quả
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string fullName = reader["fullname"].ToString();
                                int roleId = Convert.ToInt32(reader["role_id"]);

                                MessageBox.Show($"Đăng nhập thành công!\nXin chào: {fullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Điều hướng dựa trên vai trò (role_id)
                                if (roleId == 2)
                                {
                                    QuanLy adminForm = new QuanLy();
                                    adminForm.Show();
                                }
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai email hoặc mật khẩu!\nKiểm tra lại dữ liệu trong cơ sở dữ liệu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                dbConnection.CloseConnection();
            }
        }
    }
}
