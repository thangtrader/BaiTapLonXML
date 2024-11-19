using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BAITAPLONXML
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            LoadFloorsToComboBox();

            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;

            // Chọn tầng mặc định
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
        }

        private void LoadFloorsToComboBox()
        {
            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = "SELECT floor_name FROM Floors";
                    SqlDataReader reader = db.ExecuteReader(query);

                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Tất cả"); // Thêm tùy chọn "Tất cả"

                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["floor_name"].ToString());
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách tầng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFloor = comboBox3.SelectedItem.ToString();

            List<TableModel> tables = selectedFloor == "Tất cả"
                ? GetAllTables()
                : GetTablesByFloor(selectedFloor);

            DisplayTablesInGroupBox(tables);

            UpdateTableStatusLabels(selectedFloor);
        }

        private List<TableModel> GetAllTables()
        {
            List<TableModel> tables = new List<TableModel>();

            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = "SELECT table_name, status FROM Tables";
                    SqlDataReader reader = db.ExecuteReader(query);

                    while (reader.Read())
                    {
                        tables.Add(new TableModel
                        {
                            TableName = reader["table_name"].ToString(),
                            IsActive = Convert.ToBoolean(reader["status"])
                        });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách bàn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tables;
        }

        private List<TableModel> GetTablesByFloor(string floorName)
        {
            List<TableModel> tables = new List<TableModel>();

            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = @"SELECT table_name, status 
                                     FROM Tables 
                                     INNER JOIN Floors ON Tables.floor_id = Floors.id 
                                     WHERE Floors.floor_name = @floorName";
                    SqlCommand command = new SqlCommand(query, db.GetConnection());
                    command.Parameters.AddWithValue("@floorName", floorName);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tables.Add(new TableModel
                        {
                            TableName = reader["table_name"].ToString(),
                            IsActive = Convert.ToBoolean(reader["status"])
                        });
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách bàn theo tầng: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tables;
        }

        private void DisplayTablesInGroupBox(List<TableModel> tables)
        {
            groupBox2.Controls.Clear();

            int x = 10, y = 20;
            int buttonWidth = 136, buttonHeight = 136;
            int margin = 10;

            foreach (var table in tables)
            {
                Button tableButton = new Button
                {
                    Text = table.TableName,
                    ForeColor = table.IsActive ? Color.Green : Color.Red,
                    BackColor = Color.White,
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Location = new Point(x, y),
                    TextAlign = ContentAlignment.BottomCenter
                };

                // Xử lý ảnh
                string imagePath = "D:/XML/table.jpg";
                if (File.Exists(imagePath))
                {
                    tableButton.Image = Image.FromFile(imagePath);
                    tableButton.ImageAlign = ContentAlignment.TopCenter;
                }

                tableButton.Click += (s, e) => OpenOrderForm(table);

                groupBox2.Controls.Add(tableButton);

                x += buttonWidth + margin;
                if (x + buttonWidth > groupBox2.Width - 20)
                {
                    x = 10;
                    y += buttonHeight + margin;
                }
            }
        }

        private void OpenOrderForm(TableModel table)
        {
            Order orderForm = new Order
            {
                SelectedTableName = table.TableName
            };

            if (table.IsActive)
            {
                // Bàn đã có đơn hàng, tải dữ liệu
                orderForm.LoadOrderData();
            }
            else
            {
                // Tạo mới đơn hàng
                orderForm.CreateNewOrder();
            }

            orderForm.ShowDialog();

            orderForm.RefreshTableStatus();
        }


        private void UpdateTableStatusLabels(string floorName)
        {
            int totalTables = GetTotalTablesByFloor(floorName);
            int availableTables = GetAvailableTablesByFloor(floorName);

            label1.Text = $"Tổng số bàn: {totalTables}";
            label2.Text = $"Bàn còn trống: {availableTables}";
        }

        private int GetTotalTablesByFloor(string floorName)
        {
            int totalTables = 0;

            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = floorName == "Tất cả"
                        ? "SELECT COUNT(*) FROM Tables"
                        : @"SELECT COUNT(*) 
                           FROM Tables 
                           INNER JOIN Floors ON Tables.floor_id = Floors.id 
                           WHERE Floors.floor_name = @floorName";

                    SqlCommand command = new SqlCommand(query, db.GetConnection());

                    if (floorName != "Tất cả")
                    {
                        command.Parameters.AddWithValue("@floorName", floorName);
                    }

                    totalTables = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đếm tổng số bàn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalTables;
        }

        private int GetAvailableTablesByFloor(string floorName)
        {
            int availableTables = 0;

            try
            {
                using (DatabaseConnection db = new DatabaseConnection("LAPTOP-4EGGSF0D", "Caffe", "sa", "Thang@3008"))
                {
                    db.OpenConnection();

                    string query = floorName == "Tất cả"
                        ? "SELECT COUNT(*) FROM Tables WHERE status = 1"
                        : @"SELECT COUNT(*) 
                           FROM Tables 
                           INNER JOIN Floors ON Tables.floor_id = Floors.id 
                           WHERE Tables.status = 1 AND Floors.floor_name = @floorName";

                    SqlCommand command = new SqlCommand(query, db.GetConnection());

                    if (floorName != "Tất cả")
                    {
                        command.Parameters.AddWithValue("@floorName", floorName);
                    }

                    availableTables = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đếm số bàn còn trống: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return availableTables;
        }
    }

    public class TableModel
    {
        public string TableName { get; set; }
        public bool IsActive { get; set; }
    }
}
