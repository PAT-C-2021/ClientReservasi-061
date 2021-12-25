using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReservasi_061
{
    public partial class Login : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();


        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string usename = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            string kategori = service.Login(usename, password);

            if (kategori == "Admin")
            {
                Register register = new Register();
                this.Hide();
                register.Show();
            }
            else if (kategori == "Resepsionis")
            {
                Form1 reservasi = new Form1();
                this.Hide();
                reservasi.Show();
            }
            else
            {
                MessageBox.Show("Username dan Password Invalid, silahkan menghubungin Admin");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
            }
        }
    }
}
