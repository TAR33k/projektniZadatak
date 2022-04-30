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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        String kID = Form1.IDkorisnika;
        String konekStr = Form1.konekcioniString;

        private void Form3_Load(object sender, EventArgs e)
        {
            String query = "SELECT artikal.artikal_id, naziv_artikla, vrsta_artikla, cijena, kolicina_stanje FROM artikal, skladiste WHERE artikal.artikal_id=skladiste.artikal_id";
            try
            {

                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                dataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
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
            String query = "SELECT artikal.artikal_id, naziv_artikla, vrsta_artikla, cijena, kolicina_stanje FROM artikal, skladiste WHERE artikal.artikal_id=skladiste.artikal_id";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                query += " and artikal.artikal_id LIKE '" + textBox1.Text + "%' and naziv_artikla LIKE '" + textBox2.Text + "%' ";
            }

            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                query += " and artikal.artikal_id LIKE '" + textBox1.Text + "%' ";
            }

            else if (textBox2.Text != "" && textBox1.Text == "")
            {
                query += " and naziv_artikla LIKE '" + textBox2.Text + "%' ";
            }
            query += " ORDER BY artikal.artikal_id ASC;";

            try
            {

                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                dataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                String query = "INSERT INTO artikal(naziv_artikla, vrsta_artikla, cijena)" +
                    " VALUES('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);

                String query2 = "INSERT INTO skladiste(artikal_id, kolicina_stanje)" +
                    " VALUES((SELECT COUNT(artikal_id) FROM artikal), '" + textBox6.Text + "')";
                MySqlCommand cmd2 = new MySqlCommand(query2, konekcija);

                int a = cmd.ExecuteNonQuery();
                int b = cmd2.ExecuteNonQuery();

                if (a > 0 && b > 0)
                    MessageBox.Show("Dodan novi artikal!");

                String query1 = "SELECT artikal.artikal_id, naziv_artikla, vrsta_artikla, cijena, kolicina_stanje FROM artikal, skladiste WHERE artikal.artikal_id=skladiste.artikal_id";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query1, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView1.DataSource = tabela;

                dataAdapter.Dispose();

                konekcija.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "UPDATE artikal, skladiste" +
                " SET naziv_artikla='" + textBox3.Text + "', " +
                "vrsta_artikla='" + textBox4.Text + "', " +
                "cijena='" + textBox5.Text + "', " +
                "kolicina_stanje=kolicina_stanje+" + numericUpDown1.Value +
                " WHERE artikal.artikal_id=skladiste.artikal_id and artikal.artikal_id=" + textBox7.Text;
            
            MySqlConnection konekcija = new MySqlConnection(konekStr);
            konekcija.Open();

            MySqlCommand cmd = new MySqlCommand(query, konekcija);

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
                MessageBox.Show("Azuriran je artikal!");

            String query1 = "SELECT artikal.artikal_id, naziv_artikla, vrsta_artikla, cijena, kolicina_stanje FROM artikal, skladiste WHERE artikal.artikal_id=skladiste.artikal_id";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query1, konekcija);
            DataTable tabela = new DataTable();

            dataAdapter.Fill(tabela);
            dataGridView1.DataSource = tabela;

            dataAdapter.Dispose();

            konekcija.Close();
        }
    }
}
