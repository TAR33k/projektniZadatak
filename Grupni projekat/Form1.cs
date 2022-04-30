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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String IDkorisnika;

        public static String konekcioniString = "Server=localhost; Port=3306; " +
            "Database=baza-grupni; Uid=root; Pwd=root";

        private void button1_Click(object sender, EventArgs e)
        {
            String korisnickoIme = textBox1.Text;
            String sifra = textBox2.Text;

            String query = "SELECT pass, CONCAT(ime, ' ', prezime), " +
                " kupac_id FROM kupac WHERE user ='" + korisnickoIme + "' ";
            try
            {
                MySqlConnection konekcija = new MySqlConnection(konekcioniString);
                konekcija.Open();

                MySqlCommand cmd = new MySqlCommand(query, konekcija);
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Read();

                if (!reader.HasRows)
                {
                    MessageBox.Show("Pogrešno korisničko ime!");
                }
                else
                {
                    String pass = reader[0].ToString();
                    String imePrez = reader[1].ToString();
                    IDkorisnika = reader[2].ToString();

                    if ((sifra == pass) && (IDkorisnika == "1"))
                    {
                        MessageBox.Show("Uspješno ste logovani " + imePrez);
                        Form2 fr2 = new Form2();
                        this.Hide();
                        fr2.Show();
                    }

                    else if (sifra == pass)
                    {
                        MessageBox.Show("Uspješno ste logovani " + imePrez);
                        Form5 fr5 = new Form5();
                        this.Hide();
                        fr5.Show();
                    }

                    else
                    {
                        MessageBox.Show("Pogrešna šifra!");
                    }
                }
                reader.Close();
                konekcija.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
