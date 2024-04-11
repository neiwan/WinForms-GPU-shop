using kis.Controllers;
using kis.DB_Classes;
using kis.Forms;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace kis
{
    public partial class Main_Form : Form
    {
        private UserController User_Controller;
        private GPUController GPU_Controller;
        private OrderController Order_Controller;
        private StatsController Stats_Controller;

        public Main_Form(int id, VidContext db)
        {
            User_Controller = new UserController(id, db);
            GPU_Controller = new GPUController(db, id);
            Order_Controller = new OrderController(db, id);
            Stats_Controller = new StatsController(db);
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Menu_Load();
            Show_Face();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
        }

        private void Menu_Load()
        {
            if (User_Controller.Get_Role() == "admin" || User_Controller.Get_Role() == "moder")
            {
                Orders_button.Hide();
            }
            else
            {
                Stats_button.Hide();
                Orders_button.Location = new Point(12, 107);
            }
        }

        private void Profile_Load()
        {
            RefreshUserValues(User_Controller.Get_Values());
            if (User_Controller.Get_Role() == "admin")
            {
                LoadUsers();
            }
        }
        private void GPU_Load()
        {
            if (User_Controller.Get_Role() == "admin")
            {
                LoadGPUs();
                Show_GPU_Add_buttons();
                Gpu_Table.Columns["CountColumn"].Visible = false;
            }
            else
            {
                GPU_Table_Load_User();
                order_button.Show();
                Gpu_Table.Columns["CountColumn"].Visible = true;
            }
            if (User_Controller.Get_Role() == "moder")
            {
                order_button.Hide();
                Gpu_Table.Columns["CountColumn"].Visible = false;
            }
        }
        private void GPU_Table_Load_User()
        {
            LoadGPUs();
            foreach (DataGridViewColumn column in Gpu_Table.Columns)
            {
                if (column.Name != "CountColumn")
                {
                    column.ReadOnly = true;
                }
            }
            Hide_GPU_Add_buttons();
        }
        private void Hide_GPU_Add_buttons()
        {
            Manufacturer_label.Hide();
            Type_label.Hide();
            Type_textbox.Hide();
            Type_button.Hide();
            Manufacturer_button.Hide();
            Manufacturer_textbox.Hide();
        }
        private void Show_GPU_Add_buttons()
        {
            order_button.Hide();
            Manufacturer_label.Show();
            Type_label.Show();
            Type_textbox.Show();
            Type_button.Show();
            Manufacturer_button.Show();
            Manufacturer_textbox.Show();
        }
        private void Face_Button_Click(object sender, EventArgs e)
        {
            Show_Face();
        }

        private void GPU_Button_Click(object sender, EventArgs e)
        {
            Show_GPU();
        }

        private void Stats_Button_Click(object sender, EventArgs e)
        {
            Show_Stats();
        }
        private void Orders_button_Click(object sender, EventArgs e)
        {
            Show_Orders();
        }
        private void Show_Face()
        {
            Profile_Load();
            Face_Group.Show();
            GPU_Group.Hide();
            Orders_Group.Hide();
            Stats_Group.Hide();
        }
        private void Show_GPU()
        {
            GPU_Load();
            GPU_Group.Show();
            Face_Group.Hide();
            Orders_Group.Hide();
            Stats_Group.Hide();
        }
        private void Show_Stats()
        {
            Load_Stats();
            Stats_Group.Show();
            Face_Group.Hide();
            GPU_Group.Hide();
            Orders_Group.Hide();
        }
        private void Show_Orders()
        {
            Load_Orders();
            Orders_Group.Show();
            Face_Group.Hide();
            GPU_Group.Hide();
            Stats_Group.Hide();
        }
        private void Values_Button_Click(object sender, EventArgs e)
        {
            string name = UserName_text.Text;
            string city = UserCity_text.Text;
            string adres = UserAdres_text.Text;
            string password = UserPassword_text.Text;
            string login = UserLogin_text.Text;

            User_Controller.UpdateValues([name], [city], [adres], [password], [login]);
            RefreshUserValues(User_Controller.Get_Values());
        }
        private void Load_Stats()
        {
            Stats_Table.Rows.Clear();
            Stats_Table.Columns.Clear();
            Stats_Table.Columns.Add("Id", "№");
            Stats_Table.Columns.Add("Stats", "Отчет");
            var buttonColumn = new DataGridViewButtonColumn
            {
                Name = "Generate",
                HeaderText = "Создать отчет",
                Text = "Generate",
            };
            Stats_Table.Columns.Add(buttonColumn);
            string[,] table = { { "1", "Список доступных видеокарт", "Generate" },
                                { "2", "Список доступных видеокарт в магазинах выбранного города", "Generate" },
                                { "3", "Список видеокарт в выбранном ценовом диапазоне.", "Generate" },
                                { "4", "Аналитический отчет по продажам видеокарт за определенный период", "Generate" },
                                { "5", "Список видеокарт по выбранному GPU", "Generate" },
                                { "6", "Список видеокарт по объему видеопамяти", "Generate" },
                                { "7", "Список видеокарт по производителю", "Generate" }
            };
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Stats_Table.Rows.Add(table[i, 0], table[i, 1], table[i, 2]);
            }
            Stats_Table.Columns["Stats"].ReadOnly = true;
            Stats_Table.AllowUserToAddRows = false;
            Stats_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Stats_Table.AutoResizeColumns();
        }
        private void Load_Orders()
        {
            Orders_Table.AutoGenerateColumns = false;
            Orders_Table.Rows.Clear();
            Orders_Table.Columns.Clear();
            Orders_Table.Columns.Add("OrderID", "OrderID");
            Orders_Table.Columns.Add("OrderDate", "OrderDate");
            Orders_Table.Columns.Add("OrderCard", "OrderCard");
            Orders_Table.Columns.Add("OrderCardNum", "OrderCardNum");
            Orders_Table.Columns.Add("OrderDateOfArrival", "OrderDateOfArrival");
            string[,] orders = Order_Controller.Get_Orders();
            for (int i = 0; i < orders.GetLength(0); i++)
            {
                Orders_Table.Rows.Add(orders[i, 0], orders[i, 1], orders[i, 2], orders[i, 3], orders[i, 4]);
            }
            Orders_Table.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in Orders_Table.Columns)
            {
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Orders_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Orders_Table.AutoResizeColumns();
        }
        private void LoadUsers()
        {
            var roleColumn = new DataGridViewComboBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataSource = new List<string> { "admin", "customer", "moder" },
                DataPropertyName = "Role"
            };
            Users_Table.AutoGenerateColumns = false;
            Users_Table.Rows.Clear();
            Users_Table.Columns.Clear();
            Users_Table.Columns.Add("UserID", "UserID");
            Users_Table.Columns.Add("Username", "Username");
            Users_Table.Columns.Add(roleColumn);
            string[,] users = User_Controller.Get_Users();
            for (int i = 0; i < users.GetLength(0); i++)
            {
                Users_Table.Rows.Add(users[i, 0], users[i, 1], users[i, 2]);
            }
            Users_Table.Columns["UserID"].ReadOnly = true;
            Users_Table.CellEndEdit += Users_Table_CellEndEdit;
            Users_Table.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in Users_Table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Users_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Users_Table.AutoResizeColumns();

        }
        private void LoadGPUs()
        {
            var manufacturerColumn = new DataGridViewComboBoxColumn
            {
                Name = "Manufacturer",
                HeaderText = "Manufacturer",
                DataSource = GPU_Controller.GetCategoryVariants(),
                DataPropertyName = "Manufacturer"
            };
            var typeColumn = new DataGridViewComboBoxColumn
            {
                Name = "Type",
                HeaderText = "Type",
                DataSource = GPU_Controller.GetTypeVariants(),
                DataPropertyName = "Type",
            };
            var countColumn = new DataGridViewColumn(new NumericUpDownCell())
            {
                HeaderText = "Order",
                Name = "CountColumn",
            };
            Gpu_Table.AutoGenerateColumns = false;
            Gpu_Table.Rows.Clear();
            Gpu_Table.Columns.Clear();
            Gpu_Table.Columns.Add("GPUID", "GPUID");
            Gpu_Table.Columns.Add(manufacturerColumn);
            Gpu_Table.Columns.Add(typeColumn);
            Gpu_Table.Columns.Add("GPU", "GPU");
            Gpu_Table.Columns.Add("GPUname", "GPUname");
            Gpu_Table.Columns.Add("RAM", "RAM");
            Gpu_Table.Columns.Add("CoolerNum", "CoolerNum");
            Gpu_Table.Columns.Add("CardPrice", "CardPrice");
            Gpu_Table.Columns.Add("CardNum", "CardNum");
            Gpu_Table.Columns.Add(countColumn);
            string[,] gpu = GPU_Controller.Get_GPUs();
            for (int i = 0; i < gpu.GetLength(0); i++)
            {
                Gpu_Table.Rows.Add(gpu[i, 0], gpu[i, 1], gpu[i, 2], gpu[i, 3], gpu[i, 4], gpu[i, 5], gpu[i, 6], gpu[i, 7], gpu[i, 8], gpu[i, 9]);
                if (decimal.TryParse(gpu[i, 8], out decimal decimalValue)) { }
                NumericUpDownCell value = (NumericUpDownCell)Gpu_Table.Rows[i].Cells["CountColumn"];
                value.Maximum(decimalValue);
            }
            Gpu_Table.CellEndEdit += GPU_Table_CellEndEdit;
            Gpu_Table.CellContentClick += GPU_Table_CellContentClick;
            Gpu_Table.Columns["GPUID"].ReadOnly = true;
            foreach (DataGridViewColumn column in Gpu_Table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Gpu_Table.AllowUserToAddRows = false;
            Gpu_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Gpu_Table.AutoResizeColumns();
        }

        private void GPU_Table_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (Gpu_Table.Columns[e.ColumnIndex].Name == "Order" && e.RowIndex >= 0)
            {
                MessageBox.Show("GPU " + (e.RowIndex + 1) + " has been ordered!");
            }
        }

        private void GPU_Table_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;
                var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int gpuId;
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["GPUID"].Value.ToString(), out gpuId)) { }
                if (columnName == "GPU")
                {
                    GPU_Controller.UpdateGPU(gpuId, [newValue]);
                }
                else if (columnName == "GPUname")
                {
                    try
                    {
                        int.Parse(newValue);       
                    }
                    catch (Exception) 
                    {
                        MessageBox.Show("хуевое значение");
                        
                    }
              
                }
                else if (columnName == "RAM")
                {
                    GPU_Controller.UpdateRAM(gpuId, [newValue]);
                }
                else if (columnName == "CoolerNum")
                {
                    GPU_Controller.UpdateCoolerNum(gpuId, [newValue]);
                }
                else if (columnName == "CardNum")
                {
                    GPU_Controller.UpdateCardNum(gpuId, [newValue]);
                }
                else if (columnName == "CardPrice")
                {
                    GPU_Controller.UpdateCardPrice(gpuId, [newValue]);
                }
                else if (columnName == "Manufacturer")
                {
                    GPU_Controller.SetManufacturer(gpuId, [newValue]);
                }
                else if (columnName == "Type")
                {
                    GPU_Controller.SetType(gpuId, [newValue]);
                }
            }
        }

        private void Users_Table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;
                var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int userId;
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["UserID"].Value.ToString(), out userId)) { }
                if (columnName == "Role")
                {
                    User_Controller.UpdateUserRole(userId, [newValue]);
                }
                else if (columnName == "Username")
                {
                    User_Controller.UpdateUsername(userId, [newValue]);
                }
            }
        }
        public void RefreshUserValues(string[] values)
        {
            UserName_text.Text = values[0];
            UserCity_text.Text = values[1];
            UserAdres_text.Text = values[2];
            UserPassword_text.Text = values[3];
            UserLogin_text.Text = values[4];
            UserName_label.Text = "Name - " + values[0];
            UserCity_label.Text = "City - " + values[1];
            UserAdres_label.Text = "Address - " + values[2];
            UserPassword_label.Text = "Password -  ***";
            UserLogin_label.Text = "Login - " + values[4];
        }
        public void test_table(string[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void test_list(List<string> list)
        {
            foreach (string item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        private void Manufacturer_button_Click(object sender, EventArgs e)
        {
            string manufacturer = Manufacturer_textbox.Text;
            if (manufacturer == "")
            {
                MessageBox.Show("manufacturer text box must not be empty!");
            }
            GPU_Controller.AddManufacturer([manufacturer]);
            GPU_Load();
        }
        private void Type_button_Click(object sender, EventArgs e)
        {
            string type = Type_textbox.Text;
            if (type == "")
            {
                MessageBox.Show("type text box must not be empty!");
            }
            GPU_Controller.AddType([type]);
            GPU_Load();
        }

        private void order_button_Click(object sender, EventArgs e)
        {
            int[] ids = new int[Gpu_Table.RowCount - 1];
            int[] number = new int[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                if (int.TryParse(Gpu_Table.Rows[i].Cells["GPUID"].Value.ToString(), out int gpuId) && int.TryParse(Gpu_Table.Rows[i].Cells["CountColumn"].Value.ToString(), out int gpuNum) && gpuNum > 0)
                {
                    ids[i] = gpuId;
                    number[i] = gpuNum;
                }
                else
                {
                    ids[i] = -1;
                    number[i] = 0;
                }
            }
            GPU_Controller.OrderGPUs(ids, number);
            Show_GPU();
            MessageBox.Show("GPUs were successfully bought");
        }

        private void Stats_Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;
                int Id;
                if (int.TryParse(dataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out Id)) { }
                if (columnName == "Generate")
                {
                    string path = "";
                    using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                    {
                        folderBrowserDialog.Description = "Выберите папку";
                        DialogResult resultx = folderBrowserDialog.ShowDialog();
                        if (resultx == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                        {
                            path = folderBrowserDialog.SelectedPath;
                            // Список доступных видеокарт
                            if (Id == 1)
                            {
                                Stats_Controller.Generate1(path, GPU_Controller.Get_GPUs());
                                MessageBox.Show("Отчет №" + Id + " сгенерирован");
                            }
                            // Список доступных видеокарт в магазинах выбранного города
                            if (Id == 2)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(2, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate2(path, form.ans2, GPU_Controller.Get_GPUs());
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                            }
                            // Список видеокарт в выбранном ценовом диапазоне
                            if (Id == 3)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(3, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate3(path, form.ans3_1, form.ans3_2, GPU_Controller.Get_GPUs());
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                                
                            }
                            // Аналитический отчет по продажам видеокарт за определенный период
                            if (Id == 4)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(4, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate4(path, form.ans4_1, form.ans4_2, Order_Controller.Get_All_Orders(form.ans4_1, form.ans4_2));
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                                
                            }
                            // Список видеокарт по выбранному GPU
                            if (Id == 5)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(5, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate5(path, form.ans5, GPU_Controller.Get_GPUs());
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                                
                            }
                            // Список видеокарт по объему видеопамяти
                            if (Id == 6)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(6, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate6(path, form.ans6, GPU_Controller.Get_GPUs());
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                                
                            }
                            // Список видеокарт по производителю
                            if (Id == 7)
                            {
                                Stats_Extra_Form form = new Stats_Extra_Form(7, GPU_Controller);
                                DialogResult result = form.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    Stats_Controller.Generate7(path, form.ans7, GPU_Controller.Get_GPUs());
                                    MessageBox.Show("Отчет №" + Id + " сгенерирован");
                                }
                                
                            }
                        }
                    }

                    
                }
            }
        }
    }
    public class NumericUpDownCell : DataGridViewTextBoxCell
    {
        public decimal MaximumValue { get; set; }
        public NumericUpDownCell() : base() { }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);

            NumericUpDownEditingControl ctl =
                DataGridView.EditingControl as NumericUpDownEditingControl;

            if (this.MaximumValue != 0) // Проверяем, было ли установлено максимальное значение
            {
                ctl.Maximum = this.MaximumValue; // Устанавливаем максимальное значение для элемента управления NumericUpDown
            }
        }
        public override System.Type EditType
        {
            get
            {
                // Возвращаем тип элемента управления для редактирования
                return typeof(NumericUpDownEditingControl);
            }
        }

        public override System.Type ValueType
        {
            get
            {
                // Возвращаем тип значения для элемента управления
                return typeof(int);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Устанавливаем значение по умолчанию для новой строки
                return 0;
            }
        }

        public void Maximum(decimal value)
        {
            MaximumValue = value;
        }
    }
    class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public NumericUpDownEditingControl()
        {
            this.DecimalPlaces = 0;
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToString();
            }
            set
            {
                string stringValue = value as string;
                if (stringValue != null)
                {
                    this.Value = Decimal.Parse(stringValue);
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Не реализовано
        }

        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}

