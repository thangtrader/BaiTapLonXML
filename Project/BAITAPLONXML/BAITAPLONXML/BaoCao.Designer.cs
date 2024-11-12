namespace BAITAPLONXML
{
    partial class BaoCao
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            textBox3 = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 67);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(228, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(232, 31);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(645, 67);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(232, 31);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(533, 70);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 192, 255);
            button1.Location = new Point(975, 65);
            button1.Name = "button1";
            button1.Size = new Size(158, 34);
            button1.TabIndex = 4;
            button1.Text = "Xem báo cáo";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1146, 421);
            dataGridView1.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(226, 577);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(232, 31);
            textBox3.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 580);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 6;
            label3.Text = "Tổng cộng";
            // 
            // BaoCao
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1227, 623);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "BaoCao";
            Text = "BaoCao";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private DataGridView dataGridView1;
        private TextBox textBox3;
        private Label label3;
    }
}