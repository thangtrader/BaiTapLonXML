using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

public class DatabaseConnection : IDisposable
{
    private readonly string connectionString;
    private SqlConnection connection;
    private bool disposed = false; // Để theo dõi trạng thái đã giải phóng tài nguyên

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
            return command.ExecuteReader();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thực thi câu lệnh SELECT: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    public SqlConnection GetConnection()
    {
        return connection;
    }

    // Triển khai IDisposable để giải phóng tài nguyên
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Ngăn Finalizer được gọi
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Giải phóng tài nguyên được quản lý
                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }
            }

            // Tài nguyên không được quản lý (nếu có)

            disposed = true;
        }
    }

    ~DatabaseConnection()
    {
        Dispose(false); // Finalizer chỉ giải phóng tài nguyên không được quản lý
    }
}
