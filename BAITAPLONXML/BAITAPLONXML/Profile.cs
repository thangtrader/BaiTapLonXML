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
    public partial class Profile : Form
    {
        private DatabaseConnection dbConnection;
        private string staffId; // ID nhân viên đăng nhập

        public Profile(string id)
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection("SORA\\SQLEXPRESS", "Caffe", "sa", "26042004");
            staffId = id; // Lưu ID của nhân viên đăng nhập
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadProfileInfo();
        }

        private void LoadProfileInfo()
        {
            // Câu lệnh truy vấn
            string query = $"SELECT id, fullname, address, phone_number, date_of_birth, cccd, email, password FROM Staff WHERE id = '{staffId}'";

            try
            {
                // Mở kết nối
                dbConnection.OpenConnection();

                using (var reader = dbConnection.ExecuteReader(query))
                {
                    if (reader != null && reader.Read())
                    {
                        // Đẩy dữ liệu lên các label
                        label16.Text = reader["id"].ToString();
                        label15.Text = reader["fullname"].ToString();
                        label14.Text = reader["address"].ToString();
                        label13.Text = reader["phone_number"].ToString();
                        label12.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("dd/MM/yyyy");
                        label10.Text = reader["cccd"].ToString();
                        label9.Text = reader["email"].ToString();
                        label11.Text = reader["password"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
