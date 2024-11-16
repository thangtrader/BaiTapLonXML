using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BAITAPLONXML
{
    internal class XULYDULIEU
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Caffe;Integrated Security=True"; // Chuỗi kết nối

        // Hàm để mở kết nối
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Phương thức thực thi câu lệnh SELECT và trả về một DataTable
        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                    return null;
                }
            }
        }

        // Phương thức thực thi câu lệnh INSERT, UPDATE, DELETE và trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    return command.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                    return 0;
                }
            }
        }

        // Phương thức thực thi câu lệnh SELECT với tham số (ví dụ SELECT ... WHERE)
        public DataTable ExecuteQueryWithParams(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddRange(parameters); // Thêm các tham số vào câu lệnh

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi kết nối: {ex.Message}");
                    return null;
                }
            }
        }
    } 
}
