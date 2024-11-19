namespace BAITAPLONXML
{
    partial class QuanLySanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button5 = new Button();
            textBox2 = new TextBox();
            button4 = new Button();
            groupBox1 = new GroupBox();
            txtMoTa = new TextBox();
            label5 = new Label();
            txtGia = new TextBox();
            label4 = new Label();
            comboBoxDanhMuc = new ComboBox();
            txtTenSanPham = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(527, 90);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(616, 341);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(527, 63);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 16;
            label1.Text = "Danh sách sản phẩm";
            // 
            // button5
            // 
            button5.BackColor = Color.Lime;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(770, 18);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(94, 27);
            button5.TabIndex = 15;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.Silver;
            textBox2.Location = new Point(527, 21);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(238, 27);
            textBox2.TabIndex = 14;
            textBox2.Text = "Nhập thông tin cần tìm";
            // 
            // button4
            // 
            button4.BackColor = Color.Tomato;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button4.Location = new Point(185, 351);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(133, 27);
            button4.TabIndex = 13;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtGia);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxDanhMuc);
            groupBox1.Controls.Add(txtTenSanPham);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(32, 111);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(396, 217);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(153, 161);
            txtMoTa.Margin = new Padding(2);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(146, 27);
            txtMoTa.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label5.Location = new Point(22, 161);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 23);
            label5.TabIndex = 9;
            label5.Text = "Mô tả :";
            // 
            // txtGia
            // 
            txtGia.Location = new Point(153, 118);
            txtGia.Margin = new Padding(2);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(146, 27);
            txtGia.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(22, 118);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(44, 23);
            label4.TabIndex = 7;
            label4.Text = "Giá :";
            // 
            // comboBoxDanhMuc
            // 
            comboBoxDanhMuc.FormattingEnabled = true;
            comboBoxDanhMuc.Location = new Point(153, 77);
            comboBoxDanhMuc.Margin = new Padding(2);
            comboBoxDanhMuc.Name = "comboBoxDanhMuc";
            comboBoxDanhMuc.Size = new Size(146, 28);
            comboBoxDanhMuc.TabIndex = 6;
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(153, 32);
            txtTenSanPham.Margin = new Padding(2);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(146, 27);
            txtTenSanPham.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(22, 77);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(127, 23);
            label3.TabIndex = 4;
            label3.Text = "Tên danh mục :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(22, 32);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm :";
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button3.Location = new Point(174, 60);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(117, 27);
            button3.TabIndex = 11;
            button3.Text = "Cập nhật";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.Location = new Point(312, 61);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(116, 27);
            button2.TabIndex = 10;
            button2.Text = "Xóa ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(32, 60);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(117, 27);
            button1.TabIndex = 9;
            button1.Text = "Thêm ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // QuanLySanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 450);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2);
            Name = "QuanLySanPham";
            Text = "QuanLySanPham";
            Load += QuanLySanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button5;
        private TextBox textBox2;
        private Button button4;
        private GroupBox groupBox1;
        private TextBox txtMoTa;
        private Label label5;
        private TextBox txtGia;
        private Label label4;
        private ComboBox comboBoxDanhMuc;
        private TextBox txtTenSanPham;
        private Label label3;
        private Label label2;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}