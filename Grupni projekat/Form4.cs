using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Grupni_projekat
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        String kID = Form1.IDkorisnika;
        String konekStr = Form1.konekcioniString;

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kreiranjeAzuriranjeKupcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void dodavanjeAzuriranjeArtikalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form3 fr3 = new Form3();
            fr3.Show();
        }

        private void prikazBrisanjeNarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form4 fr4 = new Form4();
            fr4.Show();
        }

        private void kreiranjeNarudzbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form5 fr5 = new Form5();
            fr5.Show();
        }

        private void prikazNarudzbiIStavkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form6 fr6 = new Form6();
            fr6.Show();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM stavka_narudzbenice WHERE narudzbenica_id=" + textBox1.Text + "; " +
                "DELETE FROM narudzbenica WHERE narudzbenica_id=" + textBox1.Text;

            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                    MessageBox.Show("Obrisana je narudzba sa ID:" + textBox1.Text);

                String query1 = "SELECT narudzbenica_id, datum_narudzbe, kupac.kupac_id, ime, prezime " +
                "FROM narudzbenica, kupac WHERE kupac.kupac_id=narudzbenica.kupac_id";

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query1, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                dataAdapter.Dispose();

                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            String query = "SELECT narudzbenica_id, datum_narudzbe, kupac.kupac_id, ime, prezime " +
                "FROM narudzbenica, kupac WHERE kupac.kupac_id=narudzbenica.kupac_id";

            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                dataAdapter.Dispose();
                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
