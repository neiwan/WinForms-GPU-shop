using System.Runtime.InteropServices;
using kis.Controllers;


namespace kis
{
    public partial class Login_Form : Form
    {
        private string[] user_credentials = new string[2];
        private LoginController LoginController = new LoginController();
        public Login_Form()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user_credentials[0] = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            user_credentials[1] = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user_credentials[0] != null && user_credentials[1] != null && user_credentials[0] != "" && user_credentials[1] != "")
            {
                if (LoginController.Login(user_credentials[0], user_credentials[1]))
                {
                    this.Hide();
                    Main_Form form2 = new Main_Form(LoginController.GetID(), LoginController.GetDB());
                    form2.Show();
                }
                else
                {
                    label4.Text = "Error\nuser not found";
                }
            }
            else
            {
                label4.Text = "Error\nlogin/password checkbox\nshould not be empty";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
