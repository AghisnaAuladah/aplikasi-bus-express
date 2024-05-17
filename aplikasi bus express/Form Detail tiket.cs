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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNamaPenumpang.Text == "")
            {
                errorProvider1.SetError(txtNamaPenumpang, "Anda Harus Memasukkan Nama Penumpang.");
            }
            else
            {
                DialogResult = DialogResult.OK;

                
            }
            DialogResult ret = MessageBox.Show(
              "Tiket Anda Telah Terdaftar",
              "Informasi",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Information);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TglPemberangkatan_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNamaPenumpang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
