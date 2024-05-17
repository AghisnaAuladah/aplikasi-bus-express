using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_bus_express
{
    public partial class Form5 : Form
    {
        List<Penumpang> ListPenumpang = new List<Penumpang>();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // draw 33 kursi on sreen
            // call Draw33chair
            Draw30Kursi();
        }

        private void Draw30Kursi()
        {
            int Kursi = 1;
            for (int i = 0; i < pnKursi.RowCount; i++)
            {
                for (int j = 0; j < pnKursi.ColumnCount; j++)
                {
                    Label lblKursi = new Label();

                    lblKursi.Text = Kursi + "";
                    lblKursi.AutoSize = false;
                    lblKursi.Dock = DockStyle.Fill;
                    lblKursi.TextAlign = ContentAlignment.MiddleCenter;
                    lblKursi.BackColor = Color.Black;

                    pnKursi.Controls.Add(lblKursi, i, j);

                    Kursi++;

                    // 

                    lblKursi.Click += lblKursi_Click;
                }
            }
        }

        private void lblKursi_Click(object sender, EventArgs e)
        {
            Label lblKursi = sender as Label;
            // mengubah dari hitam ke cornflowerblue
            if(lblKursi.BackColor == Color.Black)
            {
                lblKursi.BackColor = Color.CornflowerBlue;
            }
            // cornflowerblue ke black
            else if(lblKursi.BackColor == Color.CornflowerBlue)
            {
                lblKursi.BackColor = Color.Black;
            }
            //
            else if(lblKursi.BackColor == Color.Lavender)
            {
                MessageBox.Show("Kursi ini " + lblKursi.Text + "sudah dipilih.");
            }
        }

        private void btnPesan_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Penumpang cus = new Penumpang();
                cus.NamaPenumpang = frm.txtNamaPenumpang.Text;
                cus.NoTelepon = frm.txtNoTelepon.Text;


                for (int i=0; i<pnKursi.Controls.Count; i++)
                {
                    Label lblKursi = pnKursi.Controls[i] as Label;
                    if (lblKursi.BackColor == Color.SkyBlue)
                    {
                        lblKursi.BackColor = Color.Lavender;
                        int Kursi = int.Parse(lblKursi.Text);
                        cus.Kursi.Add(Kursi);
                    }
                }
                lblHarga.Text =cus.Price + "ribu";
                ListPenumpang.Add(cus);

                //call display total money 
                DisplayTotalHarga();

                DisplayPenumpangOnListBox();
            }
        }
        private void DisplayTotalHarga()
        {
            double sum = 0;
            foreach (Penumpang cus in ListPenumpang)
            {
                sum += cus.Price;
                lblTotalHarga.Text = sum + "ribu";
            }
        }

        private void DisplayPenumpangOnListBox()
        {
            lstPenumpang.Items.Clear();
            foreach (Penumpang cus in ListPenumpang)
            {
                lstPenumpang.Items.Add(cus);
            }
        }

        private void lstPenumpang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPenumpang.SelectedIndex != -1)
            {
                Penumpang cus = lstPenumpang.SelectedItem as Penumpang;
                lblHarga.Text = cus.Price + "ribu";
            } 
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Penumpang cus = lstPenumpang.SelectedItem as Penumpang;
            if (lstPenumpang.SelectedIndex !=-1)
            {
                for (int i = 0; i < pnKursi.Controls.Count; i++)
                {
                    Label lblKursi = pnKursi.Controls[i] as Label;
                    int codeKursi = int.Parse(lblKursi.Text);
                    int flag = 0;
                    while (cus.Kursi.Count > 0 && flag < cus.Kursi.Count)
                    {
                        int orderedKursi = cus.Kursi[0];
                        if (codeKursi == orderedKursi)
                        {
                            lblKursi.BackColor = Color.Red;
                            cus.Kursi.Remove(orderedKursi);
                        }
                        flag++;
                    }
                }
                ListPenumpang.Remove(cus);
                DisplayPenumpangOnListBox();
                DisplayTotalHarga();

            }
            else
            {
                DialogResult ret = MessageBox.Show("Anda Harus Memilih Kursi.",
                    "Pertanyaan",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    lstPenumpang.Text = "";
                    pnKursi.Text = "";

                }

            }
        }

        private void pnKursi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show(
                "Apakah Kamu Yakin Ingin Menutup Program",
                "Pertanyaan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                Close();
            }
        }

        private void lblHarga_Click(object sender, EventArgs e)
        {
           
        }

        private void lblTotalHargaSys_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
