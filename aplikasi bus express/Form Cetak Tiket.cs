using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_bus_express
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Anda Harus Memasukkan Nama Penumpang.");
            }
            else
            {
                DialogResult = DialogResult.OK;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show(
                "Tiket Anda Telah Di Cetak",
                "Informasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
