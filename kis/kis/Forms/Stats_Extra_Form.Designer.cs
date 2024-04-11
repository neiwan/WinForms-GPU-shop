namespace kis
{
    partial class Stats_Extra_Form
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
            comboBox7 = new ComboBox();
            button = new Button();
            comboBox6 = new ComboBox();
            comboBox5 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            comboBox2 = new ComboBox();
            textBox3_1 = new TextBox();
            textBox3_2 = new TextBox();
            SuspendLayout();
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(78, 66);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(121, 23);
            comboBox7.TabIndex = 0;
            // 
            // button
            // 
            button.Location = new Point(88, 134);
            button.Name = "button";
            button.Size = new Size(75, 23);
            button.TabIndex = 1;
            button.Text = "confirm";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(78, 66);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(121, 23);
            comboBox6.TabIndex = 2;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(78, 66);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(37, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(37, 76);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(78, 66);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 6;
            // 
            // textBox3_1
            // 
            textBox3_1.Location = new Point(12, 22);
            textBox3_1.Name = "textBox3_1";
            textBox3_1.Size = new Size(100, 23);
            textBox3_1.TabIndex = 7;
            // 
            // textBox3_2
            // 
            textBox3_2.Location = new Point(148, 22);
            textBox3_2.Name = "textBox3_2";
            textBox3_2.Size = new Size(100, 23);
            textBox3_2.TabIndex = 8;
            // 
            // Stats_Extra_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 184);
            Controls.Add(textBox3_2);
            Controls.Add(textBox3_1);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox5);
            Controls.Add(comboBox6);
            Controls.Add(button);
            Controls.Add(comboBox7);
            Name = "Stats_Extra_Form";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private ComboBox comboBox7;
        private Button button;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private ComboBox comboBox2;
        private TextBox textBox3_1;
        private TextBox textBox3_2;
    }
}