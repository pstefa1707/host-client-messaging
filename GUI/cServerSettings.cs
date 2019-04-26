using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace messaging_app
{
    public partial class cServerSettings : Form
    {
        public cServerSettings()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            server newServer = new server(textBox1.Text, int.Parse(textBox2.Text));
            newServer.Show();
            this.Close();
        }
    }
}
