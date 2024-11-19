
namespace BAITAPLONXML
{
    partial class Order
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
            button5 = new Button();
            textBox6 = new TextBox();
            label7 = new Label();
            dvgOrder = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            btnLuu = new Button();
            labelSelectedTable = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            btnThanhToan = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgOrder).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Location = new Point(317, 468);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(154, 27);
            button5.TabIndex = 20;
            button5.Text = "Hủy";
            button5.UseVisualStyleBackColor = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(161, 387);
            textBox6.Margin = new Padding(2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(262, 27);
            textBox6.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label7.Location = new Point(62, 392);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 13;
            label7.Text = "Tổng tiền :";
            // 
            // dvgOrder
            // 
            dvgOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgOrder.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dvgOrder.Location = new Point(62, 187);
            dvgOrder.Margin = new Padding(2);
            dvgOrder.Name = "dvgOrder";
            dvgOrder.RowHeadersWidth = 62;
            dvgOrder.Size = new Size(362, 180);
            dvgOrder.TabIndex = 10;
            // 
            // Column1
            // 
            Column1.HeaderText = "Tên món";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "STT";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Đơn giá";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Thành tiền";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Location = new Point(342, 129);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(90, 27);
            button3.TabIndex = 9;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.Location = new Point(236, 129);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(90, 27);
            button2.TabIndex = 8;
            button2.Text = "Chỉnh sửa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Location = new Point(62, 129);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(159, 27);
            button1.TabIndex = 7;
            button1.Text = "Chọn món";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 87);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 5;
            label4.Text = "Nhân viên";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(163, 42);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 27);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 42);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "Ngày vào";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(163, 84);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(260, 28);
            comboBox1.TabIndex = 21;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Cyan;
            btnLuu.Location = new Point(161, 468);
            btnLuu.Margin = new Padding(2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(152, 29);
            btnLuu.TabIndex = 22;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // labelSelectedTable
            // 
            labelSelectedTable.AutoSize = true;
            labelSelectedTable.Location = new Point(208, 9);
            labelSelectedTable.Name = "labelSelectedTable";
            labelSelectedTable.Size = new Size(134, 20);
            labelSelectedTable.TabIndex = 23;
            labelSelectedTable.Text = "labelSelectedTable";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 431);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 24;
            label1.Text = "Ghi chú";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(161, 428);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(262, 27);
            textBox2.TabIndex = 25;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.Cyan;
            btnThanhToan.Location = new Point(5, 468);
            btnThanhToan.Margin = new Padding(2);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(152, 29);
            btnThanhToan.TabIndex = 26;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 515);
            Controls.Add(btnThanhToan);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(labelSelectedTable);
            Controls.Add(btnLuu);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(dvgOrder);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Margin = new Padding(2);
            Name = "Order";
            Text = "Order";
            FormClosing += Order_FormClosing;
            Load += Order_Load;
            ((System.ComponentModel.ISupportInitialize)dvgOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Button button5;
        private TextBox textBox6;
        private Label label7;
        private DataGridView dvgOrder;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox1;
        private Button btnLuu;
        private Label labelSelectedTable;
        private Label label1;
        private TextBox textBox2;
        private Button btnThanhToan;
    }
}