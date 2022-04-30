namespace Grupni_projekat
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.meniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazBrisanjeNarudzbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreiranjeNarudzbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazNarudzbiIStavkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 298);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prikaz / Brisanje narudžbe";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Brisanje narudžbe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 246);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(50, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID narudžbe: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(608, 181);
            this.dataGridView1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // meniToolStripMenuItem
            // 
            this.meniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem,
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem,
            this.prikazBrisanjeNarudzbeToolStripMenuItem,
            this.kreiranjeNarudzbeToolStripMenuItem,
            this.prikazNarudzbiIStavkiToolStripMenuItem,
            this.izlazToolStripMenuItem});
            this.meniToolStripMenuItem.Name = "meniToolStripMenuItem";
            this.meniToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.meniToolStripMenuItem.Text = "Meni";
            // 
            // kreiranjeAzuriranjeKupcaToolStripMenuItem
            // 
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Name = "kreiranjeAzuriranjeKupcaToolStripMenuItem";
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Text = "Kreiranje / azuriranje kupca";
            this.kreiranjeAzuriranjeKupcaToolStripMenuItem.Click += new System.EventHandler(this.kreiranjeAzuriranjeKupcaToolStripMenuItem_Click);
            // 
            // dodavanjeAzuriranjeArtikalaToolStripMenuItem
            // 
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Name = "dodavanjeAzuriranjeArtikalaToolStripMenuItem";
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Text = "Dodavanje / azuriranje artikala";
            this.dodavanjeAzuriranjeArtikalaToolStripMenuItem.Click += new System.EventHandler(this.dodavanjeAzuriranjeArtikalaToolStripMenuItem_Click);
            // 
            // prikazBrisanjeNarudzbeToolStripMenuItem
            // 
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Name = "prikazBrisanjeNarudzbeToolStripMenuItem";
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Text = "Prikaz / brisanje narudzbe";
            this.prikazBrisanjeNarudzbeToolStripMenuItem.Click += new System.EventHandler(this.prikazBrisanjeNarudzbeToolStripMenuItem_Click);
            // 
            // kreiranjeNarudzbeToolStripMenuItem
            // 
            this.kreiranjeNarudzbeToolStripMenuItem.Name = "kreiranjeNarudzbeToolStripMenuItem";
            this.kreiranjeNarudzbeToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.kreiranjeNarudzbeToolStripMenuItem.Text = "Kreiranje narudzbe";
            this.kreiranjeNarudzbeToolStripMenuItem.Click += new System.EventHandler(this.kreiranjeNarudzbeToolStripMenuItem_Click);
            // 
            // prikazNarudzbiIStavkiToolStripMenuItem
            // 
            this.prikazNarudzbiIStavkiToolStripMenuItem.Name = "prikazNarudzbiIStavkiToolStripMenuItem";
            this.prikazNarudzbiIStavkiToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.prikazNarudzbiIStavkiToolStripMenuItem.Text = "Prikaz narudzbi i stavki";
            this.prikazNarudzbiIStavkiToolStripMenuItem.Click += new System.EventHandler(this.prikazNarudzbiIStavkiToolStripMenuItem_Click);
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(648, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form4";
            this.Text = "Prikaz/Brisanje narudžbe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem meniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreiranjeAzuriranjeKupcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodavanjeAzuriranjeArtikalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazBrisanjeNarudzbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreiranjeNarudzbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazNarudzbiIStavkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
    }
}