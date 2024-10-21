using AutoUpload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.IsCheckBoxChecked)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Show(this);
        }
    }
}
