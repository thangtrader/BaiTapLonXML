namespace BAITAPLONXML
{
    partial class QuanLyban
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button4 = new Button();
            textBox2 = new TextBox();
            button5 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(68, 73);
            button1.Name = "button1";
            button1.Size = new Size(146, 34);
            button1.TabIndex = 0;
            button1.Text = "Thêm ";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.Location = new Point(418, 74);
            button2.Name = "button2";
            button2.Size = new Size(145, 34);
            button2.TabIndex = 1;
            button2.Text = "Xóa ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button3.Location = new Point(245, 73);
            button3.Name = "button3";
            button3.Size = new Size(146, 34);
            button3.TabIndex = 2;
            button3.Text = "Cập nhật";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(68, 162);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(565, 272);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Số bàn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(24, 76);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 1;
            label2.Text = "Tên bàn :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(24, 132);
            label3.Name = "label3";
            label3.Size = new Size(122, 28);
            label3.TabIndex = 4;
            label3.Text = "Mã khu vực :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 31);
            textBox1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(162, 132);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 6;
            // 
            // button4
            // 
            button4.BackColor = Color.Tomato;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button4.Location = new Point(68, 503);
            button4.Name = "button4";
            button4.Size = new Size(166, 34);
            button4.TabIndex = 4;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.Silver;
            textBox2.Location = new Point(687, 24);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 31);
            textBox2.TabIndex = 5;
            textBox2.Text = "Nhập thông tin cần tìm";
            // 
            // button5
            // 
            button5.BackColor = Color.Lime;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(990, 21);
            button5.Name = "button5";
            button5.Size = new Size(117, 34);
            button5.TabIndex = 6;
            button5.Text = "Tìm kiếm";
            button5.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(687, 83);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 7;
            label1.Text = "Danh sách bàn";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(687, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(562, 426);
            dataGridView1.TabIndex = 8;
            // 
            // QuanLyban
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 562);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "QuanLyban";
            Text = "QuanLyban";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button4;
        private TextBox textBox2;
        private Button button5;
        private Label label1;
        private DataGridView dataGridView1;
    }
}