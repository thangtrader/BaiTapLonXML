using Microsoft.Data.SqlClient;
using System.Data;
namespace BAITAPLONXML
{
    public partial class DangNhap : Form
    {
        private string connectionString = "Server=localhost;Initial Catalog=Caffe;Integrated Security=True";

        public DangNhap()
        {
            InitializeComponent();
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

            string query = "SELECT id, fullname, role_id FROM Staff WHERE email = @Email AND password = @Password AND active = 1";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Email", email),
        new SqlParameter("@Password", password)
            };

            XULYDULIEU dataHandler = new XULYDULIEU();
            try
            {
                DataTable result = dataHandler.ExecuteQueryWithParams(query, parameters);
                if (result != null && result.Rows.Count > 0)
                {
                    string fullName = result.Rows[0]["fullname"].ToString();
                    int roleId = Convert.ToInt32(result.Rows[0]["role_id"]);
                    MessageBox.Show($"Đăng nhập thành công!\nXin chào: {fullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Điều hướng dựa trên vai trò (role_id)
                    if (roleId == 2)
                    {
                        QuanLy adminForm = new QuanLy();
                        adminForm.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!\nKiểm tra lại dữ liệu trong cơ sở dữ liệu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message);
            }
        }
    }
}
