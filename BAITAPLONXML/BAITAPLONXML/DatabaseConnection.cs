using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace BAITAPLONXML
{
    internal class DatabaseConnection
    {
        private string connectionString;
        private SqlConnection connection;

        public DatabaseConnection(string server, string database, string username, string password)
        {
            connectionString = $"Server={server}; Database={database}; User Id={username}; Password={password}; TrustServerCertificate=True;";
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đóng kết nối: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Câu lệnh đã thực thi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi câu lệnh: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SqlDataReader ExecuteReader(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi câu lệnh SELECT: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Thêm phương thức GetConnection
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
