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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        String kID = Form1.IDkorisnika;
        String konekStr = Form1.konekcioniString;

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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Tabela1()
        {
            String query = "SELECT * FROM narudzbenica WHERE kupac_id=" + kID;

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

        private void Tabela2()
        {
            String query = "SELECT artikal.naziv_artikla, artikal.vrsta_artikla, artikal.cijena, stavka_narudzbenice.kolicina FROM artikal, stavka_narudzbenice, narudzbenica " +
                "WHERE artikal.artikal_id=stavka_narudzbenice.artikal_id AND stavka_narudzbenice.narudzbenica_id=narudzbenica.narudzbenica_id " +
                "AND narudzbenica.narudzbenica_id='" + textBox1.Text + "' AND narudzbenica.kupac_id=" + kID;

            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);
                dataGridView2.DataSource = tabela;
                dataAdapter.Dispose();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();

                int suma = 0;

                while (reader.Read())
                {
                    suma = suma + (Convert.ToInt32(reader[2]) * Convert.ToInt32(reader[3]));
                }

                konekcija.Close();

                textBox3.Text = suma.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tabela2();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Tabela1();
        }
    }
}
