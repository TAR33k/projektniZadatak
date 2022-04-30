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
    public partial class Form5 : Form
    {
        public Form5()
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

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Tabela1()
        {
            String query = "SELECT artikal.artikal_id, naziv_artikla, vrsta_artikla, cijena, kolicina_stanje " +
                "FROM artikal, skladiste WHERE artikal.artikal_id = skladiste.artikal_id;";

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
            String query1 = "SELECT stavka_id, narudzbenica.narudzbenica_id, artikal.artikal_id, kolicina, naziv_artikla " +
                "FROM stavka_narudzbenice, artikal, narudzbenica WHERE narudzbenica.narudzbenica_id = stavka_narudzbenice.narudzbenica_id " +
                "AND artikal.artikal_id = stavka_narudzbenice.artikal_id AND narudzbenica.narudzbenica_id=(SELECT MAX(narudzbenica_id) FROM narudzbenica)";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query1, konekcija);
                DataTable tabela = new DataTable();

                dataAdapter.Fill(tabela);
                dataGridView2.DataSource = tabela;

                dataAdapter.Dispose();

                konekcija.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Total()
        {
            String total = "SELECT stavka_narudzbenice.artikal_id, kolicina, cijena FROM stavka_narudzbenice, artikal  WHERE stavka_narudzbenice.artikal_id=artikal.artikal_id AND narudzbenica_id=(SELECT MAX(narudzbenica_id) FROM narudzbenica)";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand totalcmd = new MySqlCommand(total, konekcija);
                MySqlDataReader reader3 = totalcmd.ExecuteReader();

                int suma = 0;

                while (reader3.Read())
                {
                    suma = suma + (Convert.ToInt32(reader3[1]) * Convert.ToInt32(reader3[2]));
                }

                konekcija.Close();
                textBox3.Text = suma.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Tabela1();
            Tabela2();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Tabela1();
            Tabela2();
            Total();
        }

        private void Korpa()
        {
            String query = "UPDATE skladiste, stavka_narudzbenice SET kolicina_stanje=kolicina_stanje-" + textBox2.Text +
                ", kolicina=kolicina+" + textBox2.Text + " WHERE skladiste.artikal_id = stavka_narudzbenice.artikal_id AND skladiste.artikal_id=" + textBox1.Text;

            String query1 = "INSERT INTO stavka_narudzbenice(narudzbenica_id, artikal_id, kolicina) " +
                "VALUES((SELECT MAX(narudzbenica_id) FROM narudzbenica), " + textBox1.Text + ", " + textBox2.Text + "); ";

            String query2 = "SELECT kolicina_stanje FROM skladiste WHERE artikal_id=" + textBox1.Text;

            String query21 = "SELECT kolicina FROM stavka_narudzbenice WHERE artikal_id=" + textBox1.Text;

            String query3 = "SELECT * FROM stavka_narudzbenice WHERE narudzbenica_id=(SELECT MAX(narudzbenica_id) FROM narudzbenica) AND artikal_id="+textBox1.Text;

            String query4 = "UPDATE skladiste, stavka_narudzbenice SET kolicina_stanje=kolicina_stanje-" + textBox2.Text +
                ", kolicina=" + textBox2.Text + " WHERE skladiste.artikal_id = stavka_narudzbenice.artikal_id AND skladiste.artikal_id=" + textBox1.Text;

            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query2, konekcija);
                MySqlCommand cmd11 = new MySqlCommand(query21, konekcija);
                MySqlDataReader reader;
                MySqlDataReader reader11;

                reader = cmd.ExecuteReader();
                reader.Read();
                int kolicina_stanje = Convert.ToInt32(reader[0]);
                reader.Close();

                int kolicina = 0;

                reader11 = cmd.ExecuteReader();
                reader11.Read();
                if (reader11.HasRows)
                {
                    kolicina = Convert.ToInt32(reader11[0]);
                }
                else
                {
                    kolicina = 0;
                }
                reader11.Close();

                int kol = Convert.ToInt32(textBox2.Text);

                if (kolicina_stanje < kol)
                {
                    MessageBox.Show("Nedovoljno artikla na stanju.");
                }

                else if (kolicina_stanje >= kol)
                {
                    MySqlCommand cmd1 = new MySqlCommand(query, konekcija);
                    MySqlCommand cmd2 = new MySqlCommand(query1, konekcija);
                    MySqlCommand cmd3 = new MySqlCommand(query3, konekcija);
                    MySqlCommand cmd4 = new MySqlCommand(query4, konekcija);

                    MySqlDataReader reader2;
                    reader2 = cmd3.ExecuteReader();

                    int i = 0;

                    while (reader2.Read())
                    {
                        if (reader2.HasRows)
                        {
                            i = 1;
                            break;
                        }

                        else
                        {
                            i = 0;
                        }
                    }
                    reader2.Close();

                    if (i == 1)
                    {
                        int a = cmd1.ExecuteNonQuery();
                        if (a == 1)
                            MessageBox.Show("Promijenjena kolicina artikla u korpi.");
                    }

                    else if (i == 0)
                    {
                        int b = cmd2.ExecuteNonQuery();
                        int c = cmd4.ExecuteNonQuery();

                        if (b == 1 && c == 1)
                            MessageBox.Show("Dodan novi artikal u korpu.");
                    }
                }

                konekcija.Close();

                Tabela1();
                Tabela2();
                Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Obrisi()
        {
            String query = "DELETE FROM stavka_narudzbenice WHERE artikal_id="+textBox1.Text;
            String query2 = "UPDATE stavka_narudzbenice, skladiste SET kolicina_stanje=kolicina_stanje+kolicina WHERE stavka_narudzbenice.artikal_id=skladiste.artikal_id AND narudzbenica_id=(SELECT MAX(narudzbenica_id) FROM narudzbenica) AND stavka_narudzbenice.artikal_id="+textBox1.Text;

            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();
                MySqlCommand cmd2 = new MySqlCommand(query2, konekcija);
                int a = cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                int b = cmd.ExecuteNonQuery();

                if (a == 1 && b == 1)
                {
                    MessageBox.Show("Obrisan je artikal ID:"+textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Tabela1();
            Tabela2();
            Total();
        }

        private void KreirajNarudzbu()
        {
            String query = "INSERT INTO narudzbenica(kupac_id, datum_narudzbe) VALUES(" + kID + ", '" + DateTime.Now.ToString("yyyy-MM-dd")+"')";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekStr);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                int a = cmd.ExecuteNonQuery();

                if (a == 1)
                {
                    MessageBox.Show("Kreirana nova narudzba.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Tabela1();
            Tabela2();
            Total();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Korpa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Obrisi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KreirajNarudzbu();
        }
    }
}
