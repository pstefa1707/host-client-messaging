﻿using System;
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
    public partial class jServerSettings : Form
    {
        public jServerSettings()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client client = new client(this.textBox1.Text, int.Parse(this.textBox2.Text), this.textBox3.Text);
            client.Show();
            this.Close();
        }
    }
}
