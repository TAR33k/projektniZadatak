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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        String kID = Form1.IDkorisnika;
        String konekStr = Form1.konekcioniString;

        private void Form2_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM kupac";
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

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM kupac";
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                query += " WHERE ime LIKE '" + textBox1.Text + "%' and prezime LIKE '" + textBox2.Text + "%' ";
            }

            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                query += " WHERE ime LIKE '" + textBox1.Text + "%' ";
            }

            else if (textBox2.Text != "" && textBox1.Text == "")
            {
                query += " WHERE prezime LIKE '" + textBox2.Text + "%' ";
            }
            query += " ORDER BY kupac_id ASC;";

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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "INSERT INTO kupac(ime, prezime, grad, adresa, telefon, user, pass)" +
                    "VALUES('" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox10.Text + "', '" + textBox9.Text + "', '" + textBox8.Text + "')";

                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                MessageBox.Show("Dodan novi kupac!");

                String query1 = "SELECT * FROM kupac";

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "UPDATE kupac" +
                    " SET ime ='"+ textBox3.Text + "', "+
                    "prezime ='"+ textBox4.Text + "', "+
                    "grad ='"+ textBox5.Text + "', "+
                    "adresa ='"+ textBox6.Text + "', "+
                    "telefon ='"+ textBox10.Text + "', "+
                    "user ='"+ textBox9.Text + "', "+
                    "pass ='"+ textBox8.Text + "'"+
                    " WHERE kupac_id='"+textBox7.Text+"'";

                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);

                int b = cmd.ExecuteNonQuery();

                if (b > 0)
                MessageBox.Show("Azuriran kupac sa ID:" + textBox7.Text);

                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
