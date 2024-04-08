namespace kis
{
    partial class Main_Form
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
            Profile_button = new Button();
            GPU_button = new Button();
            Stats_button = new Button();
            UserName_label = new Label();
            Values_button = new Button();
            UserName_text = new TextBox();
            Users_Table = new DataGridView();
            UserCity_text = new TextBox();
            UserAdres_text = new TextBox();
            UserCity_label = new Label();
            UserAdres_label = new Label();
            UserPassword_text = new TextBox();
            UserLogin_text = new TextBox();
            UserPassword_label = new Label();
            UserLogin_label = new Label();
            Face_Group = new GroupBox();
            GPU_Group = new GroupBox();
            order_button = new Button();
            Type_button = new Button();
            Manufacturer_button = new Button();
            Type_textbox = new TextBox();
            Manufacturer_textbox = new TextBox();
            Type_label = new Label();
            Manufacturer_label = new Label();
            Gpu_Table = new DataGridView();
            Orders_Group = new GroupBox();
            Orders_Table = new DataGridView();
            Orders_button = new Button();
            Stats_Group = new GroupBox();
            Stats_Table = new DataGridView();
            Label = new DataGridViewTextBoxColumn();
            Button = new DataGridViewTextBoxColumn();
            Stats_Label7 = new Label();
            Stats_Label6 = new Label();
            Stats_Label5 = new Label();
            Stats_Label4 = new Label();
            Stats_Label3 = new Label();
            Stats_Label2 = new Label();
            Stats_Label1 = new Label();
            Stats_Button7 = new Button();
            Stats_Button6 = new Button();
            Stats_Button5 = new Button();
            Stats_Button4 = new Button();
            Stats_Button3 = new Button();
            Stats_Button2 = new Button();
            Stats_Button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)Users_Table).BeginInit();
            Face_Group.SuspendLayout();
            GPU_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Gpu_Table).BeginInit();
            Orders_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Orders_Table).BeginInit();
            Stats_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Stats_Table).BeginInit();
            SuspendLayout();
            // 
            // Profile_button
            // 
            Profile_button.Location = new Point(12, 12);
            Profile_button.Name = "Profile_button";
            Profile_button.Size = new Size(75, 23);
            Profile_button.TabIndex = 1;
            Profile_button.Text = "profile";
            Profile_button.UseVisualStyleBackColor = true;
            Profile_button.Click += Face_Button_Click;
            // 
            // GPU_button
            // 
            GPU_button.Location = new Point(12, 58);
            GPU_button.Name = "GPU_button";
            GPU_button.Size = new Size(75, 23);
            GPU_button.TabIndex = 2;
            GPU_button.Text = "gpu";
            GPU_button.UseVisualStyleBackColor = true;
            GPU_button.Click += GPU_Button_Click;
            // 
            // Stats_button
            // 
            Stats_button.Location = new Point(12, 107);
            Stats_button.Name = "Stats_button";
            Stats_button.Size = new Size(75, 23);
            Stats_button.TabIndex = 3;
            Stats_button.Text = "stats";
            Stats_button.UseVisualStyleBackColor = true;
            Stats_button.Click += Stats_Button_Click;
            // 
            // UserName_label
            // 
            UserName_label.AutoSize = true;
            UserName_label.Location = new Point(42, 26);
            UserName_label.Name = "UserName_label";
            UserName_label.Size = new Size(60, 15);
            UserName_label.TabIndex = 5;
            UserName_label.Text = "Username";
            UserName_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Values_button
            // 
            Values_button.Location = new Point(53, 350);
            Values_button.Name = "Values_button";
            Values_button.Size = new Size(75, 23);
            Values_button.TabIndex = 6;
            Values_button.Text = "confirm";
            Values_button.UseVisualStyleBackColor = true;
            Values_button.Click += Values_Button_Click;
            // 
            // UserName_text
            // 
            UserName_text.ForeColor = SystemColors.WindowFrame;
            UserName_text.Location = new Point(42, 47);
            UserName_text.Name = "UserName_text";
            UserName_text.Size = new Size(100, 23);
            UserName_text.TabIndex = 8;
            // 
            // Users_Table
            // 
            Users_Table.BackgroundColor = SystemColors.Control;
            Users_Table.BorderStyle = BorderStyle.None;
            Users_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Users_Table.GridColor = SystemColors.MenuText;
            Users_Table.Location = new Point(249, 47);
            Users_Table.Name = "Users_Table";
            Users_Table.Size = new Size(343, 306);
            Users_Table.TabIndex = 10;
            // 
            // UserCity_text
            // 
            UserCity_text.ForeColor = SystemColors.WindowFrame;
            UserCity_text.Location = new Point(42, 105);
            UserCity_text.Name = "UserCity_text";
            UserCity_text.Size = new Size(100, 23);
            UserCity_text.TabIndex = 14;
            // 
            // UserAdres_text
            // 
            UserAdres_text.ForeColor = SystemColors.WindowFrame;
            UserAdres_text.Location = new Point(42, 160);
            UserAdres_text.Name = "UserAdres_text";
            UserAdres_text.Size = new Size(100, 23);
            UserAdres_text.TabIndex = 13;
            // 
            // UserCity_label
            // 
            UserCity_label.AutoSize = true;
            UserCity_label.Location = new Point(42, 84);
            UserCity_label.Name = "UserCity_label";
            UserCity_label.Size = new Size(52, 15);
            UserCity_label.TabIndex = 12;
            UserCity_label.Text = "User city";
            UserCity_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserAdres_label
            // 
            UserAdres_label.AutoSize = true;
            UserAdres_label.Location = new Point(42, 142);
            UserAdres_label.Name = "UserAdres_label";
            UserAdres_label.Size = new Size(61, 15);
            UserAdres_label.TabIndex = 11;
            UserAdres_label.Text = "User adres";
            // 
            // UserPassword_text
            // 
            UserPassword_text.ForeColor = SystemColors.WindowFrame;
            UserPassword_text.Location = new Point(42, 220);
            UserPassword_text.Name = "UserPassword_text";
            UserPassword_text.PasswordChar = '*';
            UserPassword_text.Size = new Size(100, 23);
            UserPassword_text.TabIndex = 18;
            // 
            // UserLogin_text
            // 
            UserLogin_text.ForeColor = SystemColors.WindowFrame;
            UserLogin_text.Location = new Point(42, 280);
            UserLogin_text.Name = "UserLogin_text";
            UserLogin_text.Size = new Size(100, 23);
            UserLogin_text.TabIndex = 17;
            // 
            // UserPassword_label
            // 
            UserPassword_label.AutoSize = true;
            UserPassword_label.Location = new Point(42, 202);
            UserPassword_label.Name = "UserPassword_label";
            UserPassword_label.Size = new Size(57, 15);
            UserPassword_label.TabIndex = 16;
            UserPassword_label.Text = "Password";
            UserPassword_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserLogin_label
            // 
            UserLogin_label.AutoSize = true;
            UserLogin_label.Location = new Point(42, 259);
            UserLogin_label.Name = "UserLogin_label";
            UserLogin_label.Size = new Size(60, 15);
            UserLogin_label.TabIndex = 15;
            UserLogin_label.Text = "User login";
            // 
            // Face_Group
            // 
            Face_Group.Controls.Add(Users_Table);
            Face_Group.Controls.Add(UserPassword_text);
            Face_Group.Controls.Add(UserLogin_text);
            Face_Group.Controls.Add(UserName_label);
            Face_Group.Controls.Add(UserPassword_label);
            Face_Group.Controls.Add(Values_button);
            Face_Group.Controls.Add(UserLogin_label);
            Face_Group.Controls.Add(UserName_text);
            Face_Group.Controls.Add(UserCity_text);
            Face_Group.Controls.Add(UserAdres_label);
            Face_Group.Controls.Add(UserAdres_text);
            Face_Group.Controls.Add(UserCity_label);
            Face_Group.Location = new Point(106, 1);
            Face_Group.Name = "Face_Group";
            Face_Group.Size = new Size(1200, 431);
            Face_Group.TabIndex = 19;
            Face_Group.TabStop = false;
            // 
            // GPU_Group
            // 
            GPU_Group.Controls.Add(order_button);
            GPU_Group.Controls.Add(Type_button);
            GPU_Group.Controls.Add(Manufacturer_button);
            GPU_Group.Controls.Add(Type_textbox);
            GPU_Group.Controls.Add(Manufacturer_textbox);
            GPU_Group.Controls.Add(Type_label);
            GPU_Group.Controls.Add(Manufacturer_label);
            GPU_Group.Controls.Add(Gpu_Table);
            GPU_Group.Location = new Point(106, 1);
            GPU_Group.Name = "GPU_Group";
            GPU_Group.Size = new Size(1200, 431);
            GPU_Group.TabIndex = 20;
            GPU_Group.TabStop = false;
            // 
            // order_button
            // 
            order_button.Location = new Point(1078, 356);
            order_button.Name = "order_button";
            order_button.Size = new Size(75, 23);
            order_button.TabIndex = 17;
            order_button.Text = "order";
            order_button.TextAlign = ContentAlignment.TopCenter;
            order_button.UseVisualStyleBackColor = true;
            order_button.Click += order_button_Click;
            // 
            // Type_button
            // 
            Type_button.Location = new Point(242, 385);
            Type_button.Name = "Type_button";
            Type_button.Size = new Size(75, 23);
            Type_button.TabIndex = 16;
            Type_button.Text = "confirm";
            Type_button.UseVisualStyleBackColor = true;
            Type_button.Click += Type_button_Click;
            // 
            // Manufacturer_button
            // 
            Manufacturer_button.Location = new Point(102, 385);
            Manufacturer_button.Name = "Manufacturer_button";
            Manufacturer_button.Size = new Size(75, 23);
            Manufacturer_button.TabIndex = 15;
            Manufacturer_button.Text = "confirm";
            Manufacturer_button.UseVisualStyleBackColor = true;
            Manufacturer_button.Click += Manufacturer_button_Click;
            // 
            // Type_textbox
            // 
            Type_textbox.Location = new Point(230, 356);
            Type_textbox.Name = "Type_textbox";
            Type_textbox.Size = new Size(100, 23);
            Type_textbox.TabIndex = 14;
            // 
            // Manufacturer_textbox
            // 
            Manufacturer_textbox.Location = new Point(92, 356);
            Manufacturer_textbox.Name = "Manufacturer_textbox";
            Manufacturer_textbox.Size = new Size(100, 23);
            Manufacturer_textbox.TabIndex = 13;
            // 
            // Type_label
            // 
            Type_label.AutoSize = true;
            Type_label.Location = new Point(251, 338);
            Type_label.Name = "Type_label";
            Type_label.Size = new Size(55, 15);
            Type_label.TabIndex = 12;
            Type_label.Text = "NewType";
            // 
            // Manufacturer_label
            // 
            Manufacturer_label.AutoSize = true;
            Manufacturer_label.Location = new Point(86, 338);
            Manufacturer_label.Name = "Manufacturer_label";
            Manufacturer_label.Size = new Size(106, 15);
            Manufacturer_label.TabIndex = 11;
            Manufacturer_label.Text = "New Manufacturer";
            // 
            // Gpu_Table
            // 
            Gpu_Table.BackgroundColor = SystemColors.Control;
            Gpu_Table.BorderStyle = BorderStyle.None;
            Gpu_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Gpu_Table.GridColor = SystemColors.MenuText;
            Gpu_Table.Location = new Point(25, 26);
            Gpu_Table.Name = "Gpu_Table";
            Gpu_Table.Size = new Size(1145, 298);
            Gpu_Table.TabIndex = 10;
            // 
            // Orders_Group
            // 
            Orders_Group.Controls.Add(Orders_Table);
            Orders_Group.Location = new Point(106, 1);
            Orders_Group.Name = "Orders_Group";
            Orders_Group.Size = new Size(1200, 431);
            Orders_Group.TabIndex = 21;
            Orders_Group.TabStop = false;
            Orders_Group.Text = "3";
            // 
            // Orders_Table
            // 
            Orders_Table.BackgroundColor = SystemColors.Control;
            Orders_Table.BorderStyle = BorderStyle.None;
            Orders_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Orders_Table.GridColor = SystemColors.MenuText;
            Orders_Table.Location = new Point(42, 11);
            Orders_Table.Name = "Orders_Table";
            Orders_Table.Size = new Size(1145, 374);
            Orders_Table.TabIndex = 10;
            // 
            // Orders_button
            // 
            Orders_button.Location = new Point(12, 160);
            Orders_button.Name = "Orders_button";
            Orders_button.Size = new Size(75, 23);
            Orders_button.TabIndex = 21;
            Orders_button.Text = "orders";
            Orders_button.TextAlign = ContentAlignment.TopCenter;
            Orders_button.UseVisualStyleBackColor = true;
            Orders_button.Click += Orders_button_Click;
            // 
            // Stats_Group
            // 
            Stats_Group.Controls.Add(Stats_Table);
            Stats_Group.Controls.Add(Stats_Label7);
            Stats_Group.Controls.Add(Stats_Label6);
            Stats_Group.Controls.Add(Stats_Label5);
            Stats_Group.Controls.Add(Stats_Label4);
            Stats_Group.Controls.Add(Stats_Label3);
            Stats_Group.Controls.Add(Stats_Label2);
            Stats_Group.Controls.Add(Stats_Label1);
            Stats_Group.Controls.Add(Stats_Button7);
            Stats_Group.Controls.Add(Stats_Button6);
            Stats_Group.Controls.Add(Stats_Button5);
            Stats_Group.Controls.Add(Stats_Button4);
            Stats_Group.Controls.Add(Stats_Button3);
            Stats_Group.Controls.Add(Stats_Button2);
            Stats_Group.Controls.Add(Stats_Button1);
            Stats_Group.Location = new Point(93, 12);
            Stats_Group.Name = "Stats_Group";
            Stats_Group.Size = new Size(1207, 426);
            Stats_Group.TabIndex = 22;
            Stats_Group.TabStop = false;
            // 
            // Stats_Table
            // 
            Stats_Table.AllowUserToDeleteRows = false;
            Stats_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Stats_Table.Columns.AddRange(new DataGridViewColumn[] { Label, Button });
            Stats_Table.Dock = DockStyle.Fill;
            Stats_Table.Location = new Point(3, 19);
            Stats_Table.Name = "Stats_Table";
            Stats_Table.Size = new Size(1201, 404);
            Stats_Table.TabIndex = 14;
            Stats_Table.CellContentClick += Stats_Table_CellContentClick;
            // 
            // Label
            // 
            Label.HeaderText = "Название Отчета";
            Label.Name = "Label";
            Label.ReadOnly = true;
            // 
            // Button
            // 
            Button.HeaderText = "Создать отчет";
            Button.Name = "Button";
            // 
            // Stats_Label7
            // 
            Stats_Label7.AutoSize = true;
            Stats_Label7.Location = new Point(38, 290);
            Stats_Label7.Name = "Stats_Label7";
            Stats_Label7.Size = new Size(214, 15);
            Stats_Label7.TabIndex = 13;
            Stats_Label7.Text = "Список видеокарт по производителю";
            // 
            // Stats_Label6
            // 
            Stats_Label6.AutoSize = true;
            Stats_Label6.Location = new Point(38, 248);
            Stats_Label6.Name = "Stats_Label6";
            Stats_Label6.Size = new Size(244, 15);
            Stats_Label6.TabIndex = 12;
            Stats_Label6.Text = "Список видеокарт по объему видеопамяти";
            // 
            // Stats_Label5
            // 
            Stats_Label5.AutoSize = true;
            Stats_Label5.Location = new Point(38, 208);
            Stats_Label5.Name = "Stats_Label5";
            Stats_Label5.Size = new Size(224, 15);
            Stats_Label5.TabIndex = 11;
            Stats_Label5.Text = "Список видеокарт по выбранному GPU";
            // 
            // Stats_Label4
            // 
            Stats_Label4.AutoSize = true;
            Stats_Label4.Location = new Point(38, 165);
            Stats_Label4.Name = "Stats_Label4";
            Stats_Label4.Size = new Size(404, 15);
            Stats_Label4.TabIndex = 10;
            Stats_Label4.Text = "Аналитический отчет по продажам видеокарт за определенный период";
            // 
            // Stats_Label3
            // 
            Stats_Label3.AutoSize = true;
            Stats_Label3.Location = new Point(38, 120);
            Stats_Label3.Name = "Stats_Label3";
            Stats_Label3.Size = new Size(299, 15);
            Stats_Label3.TabIndex = 9;
            Stats_Label3.Text = "Список видеокарт в выбранном ценовом диапазоне.";
            // 
            // Stats_Label2
            // 
            Stats_Label2.AutoSize = true;
            Stats_Label2.Location = new Point(38, 73);
            Stats_Label2.Name = "Stats_Label2";
            Stats_Label2.Size = new Size(350, 15);
            Stats_Label2.TabIndex = 8;
            Stats_Label2.Text = "Список доступных видеокарт в магазинах выбранного города";
            // 
            // Stats_Label1
            // 
            Stats_Label1.AutoSize = true;
            Stats_Label1.FlatStyle = FlatStyle.System;
            Stats_Label1.Location = new Point(38, 36);
            Stats_Label1.Name = "Stats_Label1";
            Stats_Label1.Size = new Size(169, 15);
            Stats_Label1.TabIndex = 7;
            Stats_Label1.Text = "Список доступных видеокарт";
            // 
            // Stats_Button7
            // 
            Stats_Button7.Location = new Point(476, 286);
            Stats_Button7.Name = "Stats_Button7";
            Stats_Button7.Size = new Size(75, 23);
            Stats_Button7.TabIndex = 6;
            Stats_Button7.Text = "Generate";
            Stats_Button7.UseVisualStyleBackColor = true;
            // 
            // Stats_Button6
            // 
            Stats_Button6.Location = new Point(476, 244);
            Stats_Button6.Name = "Stats_Button6";
            Stats_Button6.Size = new Size(75, 23);
            Stats_Button6.TabIndex = 5;
            Stats_Button6.Text = "Generate";
            Stats_Button6.UseVisualStyleBackColor = true;
            // 
            // Stats_Button5
            // 
            Stats_Button5.Location = new Point(476, 204);
            Stats_Button5.Name = "Stats_Button5";
            Stats_Button5.Size = new Size(75, 23);
            Stats_Button5.TabIndex = 4;
            Stats_Button5.Text = "Generate";
            Stats_Button5.UseVisualStyleBackColor = true;
            // 
            // Stats_Button4
            // 
            Stats_Button4.Location = new Point(476, 161);
            Stats_Button4.Name = "Stats_Button4";
            Stats_Button4.Size = new Size(75, 23);
            Stats_Button4.TabIndex = 3;
            Stats_Button4.Text = "Generate";
            Stats_Button4.UseVisualStyleBackColor = true;
            // 
            // Stats_Button3
            // 
            Stats_Button3.Location = new Point(476, 116);
            Stats_Button3.Name = "Stats_Button3";
            Stats_Button3.Size = new Size(75, 23);
            Stats_Button3.TabIndex = 2;
            Stats_Button3.Text = "Generate";
            Stats_Button3.UseVisualStyleBackColor = true;
            // 
            // Stats_Button2
            // 
            Stats_Button2.Location = new Point(476, 69);
            Stats_Button2.Name = "Stats_Button2";
            Stats_Button2.Size = new Size(75, 23);
            Stats_Button2.TabIndex = 1;
            Stats_Button2.Text = "Generate";
            Stats_Button2.UseVisualStyleBackColor = true;
            // 
            // Stats_Button1
            // 
            Stats_Button1.Location = new Point(476, 32);
            Stats_Button1.Name = "Stats_Button1";
            Stats_Button1.Size = new Size(75, 23);
            Stats_Button1.TabIndex = 0;
            Stats_Button1.Text = "Generate";
            Stats_Button1.UseVisualStyleBackColor = true;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 469);
            Controls.Add(Stats_Group);
            Controls.Add(Orders_button);
            Controls.Add(GPU_Group);
            Controls.Add(Stats_button);
            Controls.Add(GPU_button);
            Controls.Add(Profile_button);
            Controls.Add(Face_Group);
            Controls.Add(Orders_Group);
            Name = "Main_Form";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)Users_Table).EndInit();
            Face_Group.ResumeLayout(false);
            Face_Group.PerformLayout();
            GPU_Group.ResumeLayout(false);
            GPU_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Gpu_Table).EndInit();
            Orders_Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Orders_Table).EndInit();
            Stats_Group.ResumeLayout(false);
            Stats_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Stats_Table).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button Profile_button;
        private Button GPU_button;
        private Button Stats_button;
        private Label UserName_label;
        private Button Values_button;
        private TextBox UserName_text;
        private DataGridView Users_Table;
        private TextBox UserCity_text;
        private TextBox UserAdres_text;
        private Label UserCity_label;
        private Label UserAdres_label;
        private TextBox UserPassword_text;
        private TextBox UserLogin_text;
        private Label UserPassword_label;
        private Label UserLogin_label;
        private GroupBox Face_Group;
        private GroupBox GPU_Group;
        private DataGridView Gpu_Table;
        private Label Type_label;
        private Label Manufacturer_label;
        private TextBox Manufacturer_textbox;
        private TextBox Type_textbox;
        private Button Manufacturer_button;
        private Button Type_button;
        private Button order_button;
        private Button Orders_button;
        private GroupBox Orders_Group;
        private DataGridView Orders_Table;
        private GroupBox Stats_Group;
        private Label Stats_Label7;
        private Label Stats_Label6;
        private Label Stats_Label5;
        private Label Stats_Label4;
        private Label Stats_Label3;
        private Label Stats_Label2;
        private Label Stats_Label1;
        private Button Stats_Button7;
        private Button Stats_Button6;
        private Button Stats_Button5;
        private Button Stats_Button4;
        private Button Stats_Button3;
        private Button Stats_Button2;
        private Button Stats_Button1;
        private DataGridView Stats_Table;
        private DataGridViewTextBoxColumn Label;
        private DataGridViewTextBoxColumn Button;
    }
}