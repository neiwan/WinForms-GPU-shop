using kis.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kis
{
    public partial class Stats_Extra_Form : Form
    {
        public string ans7 = "";
        public string ans6 = "";
        public string ans5 = "";
        public DateTime ans4_1;
        public DateTime ans4_2;
        public string ans3_1 = "";
        public string ans3_2 = "";
        public string ans2 = "";
        private GPUController GPU_Controller;
        public Stats_Extra_Form(int id, GPUController gPUController)
        {
            GPU_Controller = gPUController;
            InitializeComponent();
            Hide_Boxes();
            switch (id)
            {
                case 2:
                    this.Text = "Выберите город";
                    comboBox2.Show();
                    comboBox2.DataSource = GPU_Controller.GetShopVariants();
                    break;
                case 3:
                    this.Text = "Выберите ценовой диапазон";
                    textBox3_1.Show();
                    textBox3_2.Show();
                    break;
                case 4:
                    this.Text = "Выберите даты";
                    dateTimePicker1.Show();
                    dateTimePicker2.Show();
                    break;
                case 5:
                    this.Text = "Выберите GPU";
                    comboBox5.Show();
                    comboBox5.DataSource = GPU_Controller.GetGpuVariants();
                    break;
                case 6:
                    this.Text = "Выберите объем";
                    comboBox6.Show();
                    comboBox6.DataSource = GPU_Controller.GetRamVariants();
                    break;
                case 7:
                    this.Text = "Выберите производителя";
                    comboBox7.Show();
                    comboBox7.DataSource = GPU_Controller.GetCategoryVariants();
                    break;
                default:
                    break;
            }
        }
        private void Hide_Boxes()
        {
            this.textBox3_1.Hide();
            this.textBox3_2.Hide();
            this.dateTimePicker1.Hide();
            this.dateTimePicker2.Hide();
            this.comboBox2.Hide();
            this.comboBox5.Hide();
            this.comboBox6.Hide();
            this.comboBox7.Hide();
        }
        private void button_Click(object sender, EventArgs e)
        {
            ans2 = comboBox2.Text;
            ans3_1 = textBox3_1.Text;
            ans3_2 = textBox3_2.Text;
            ans4_1 = dateTimePicker1.Value;
            ans4_2 = dateTimePicker2.Value;
            ans5 = comboBox5.Text;
            ans6 = comboBox6.Text;
            ans7 = comboBox7.Text;
            this.Close();
        }
    }
}
