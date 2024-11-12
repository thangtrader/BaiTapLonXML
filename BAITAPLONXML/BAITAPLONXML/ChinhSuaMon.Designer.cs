namespace BAITAPLONXML
{
    partial class ChinhSuaMon
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.FromArgb(0, 192, 192);
            label1.Location = new Point(266, 2);
            label1.Name = "label1";
            label1.Size = new Size(274, 48);
            label1.TabIndex = 0;
            label1.Text = "Chỉnh sửa món";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.FromArgb(0, 192, 192);
            label2.Location = new Point(73, 82);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 1;
            label2.Text = "Tên món :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(200, 82);
            label3.Name = "label3";
            label3.Size = new Size(79, 32);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label4.Location = new Point(73, 146);
            label4.Name = "label4";
            label4.Size = new Size(125, 32);
            label4.TabIndex = 3;
            label4.Text = "Số lượng :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 149);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.FromArgb(0, 192, 192);
            label5.Location = new Point(73, 213);
            label5.Name = "label5";
            label5.Size = new Size(110, 32);
            label5.TabIndex = 5;
            label5.Text = "Ghi chú :";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(200, 216);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(571, 150);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 192, 0);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.ForeColor = Color.White;
            button1.Location = new Point(73, 387);
            button1.Name = "button1";
            button1.Size = new Size(186, 51);
            button1.TabIndex = 7;
            button1.Text = "Lưu và đóng";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Tomato;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button2.ForeColor = Color.White;
            button2.Location = new Point(571, 387);
            button2.Name = "button2";
            button2.Size = new Size(186, 51);
            button2.TabIndex = 8;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = false;
            // 
            // ChinhSuaMon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(0, 192, 192);
            Name = "ChinhSuaMon";
            Text = "ChinhSuaMon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
    }
}