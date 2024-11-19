namespace BAITAPLONXML
{
    partial class ChonMon
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
            groupBox1 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            comboBoxProduct = new ComboBox();
            comboBoxDanhMuc = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBoxProduct);
            groupBox1.Controls.Add(comboBoxDanhMuc);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(2, 1);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(690, 503);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chọn món";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button6
            // 
            button6.Location = new Point(195, 124);
            button6.Name = "button6";
            button6.Size = new Size(25, 29);
            button6.TabIndex = 14;
            button6.Text = "-";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(277, 126);
            button5.Name = "button5";
            button5.Size = new Size(25, 29);
            button5.TabIndex = 13;
            button5.Text = "+";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(195, 159);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "Thêm";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(234, 126);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(27, 27);
            textBox2.TabIndex = 10;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 124);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 9;
            label3.Text = "Số lượng ";
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(195, 74);
            comboBoxProduct.Margin = new Padding(2);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(146, 28);
            comboBoxProduct.TabIndex = 8;
            // 
            // comboBoxDanhMuc
            // 
            comboBoxDanhMuc.FormattingEnabled = true;
            comboBoxDanhMuc.Location = new Point(195, 29);
            comboBoxDanhMuc.Margin = new Padding(2);
            comboBoxDanhMuc.Name = "comboBoxDanhMuc";
            comboBoxDanhMuc.Size = new Size(146, 28);
            comboBoxDanhMuc.TabIndex = 7;
            comboBoxDanhMuc.SelectedIndexChanged += comboBoxDanhMuc_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 77);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 6;
            label2.Text = "Món";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 32);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 4;
            label1.Text = "Danh mục";
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.ForeColor = Color.White;
            button2.Location = new Point(377, 439);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(226, 41);
            button2.TabIndex = 3;
            button2.Text = "Hủy chọn";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.White;
            button1.Location = new Point(76, 439);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(226, 41);
            button1.TabIndex = 2;
            button1.Text = "Chọn và đóng";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column5, Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(40, 193);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(616, 237);
            dataGridView1.TabIndex = 1;
            // 
            // Column5
            // 
            Column5.HeaderText = "STT";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 150;
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
            Column2.HeaderText = "Số lượng";
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
            // ChonMon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 505);
            Controls.Add(groupBox1);
            Margin = new Padding(2);
            Name = "ChonMon";
            Text = "ChonMon";
            Load += ChonMon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private TextBox textBox2;
        private Label label3;
        private ComboBox comboBoxProduct;
        private ComboBox comboBoxDanhMuc;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button4;
        private Button button6;
        private Button button5;
    }
}