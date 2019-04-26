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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cServerSettings cServer = new cServerSettings();
            cServer.Show();
            cServer.Focus();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            jServerSettings jServer = new jServerSettings();
            jServer.Show();
            jServer.Focus();
        }

        private void CreateServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cServerSettings cServer = new cServerSettings();
            cServer.Show();
            cServer.Focus();
        }

        private void JoinServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jServerSettings jServer = new jServerSettings();
            jServer.Show();
            jServer.Focus();
        }
    }
}
