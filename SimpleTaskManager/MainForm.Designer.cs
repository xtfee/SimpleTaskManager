namespace SimpleTaskManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnCzyscPola = new Button();
            btnDodajZapiszZadanie = new Button();
            chkCzyWykonane = new CheckBox();
            dtpTermin = new DateTimePicker();
            label3 = new Label();
            cmbKategorieZadania = new ComboBox();
            label2 = new Label();
            txtOpis = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnUsunWybranaKategorie = new Button();
            cmbKategorieDoUsuniecia = new ComboBox();
            label5 = new Label();
            btnDodajKategorie = new Button();
            txtNowaKategoria = new TextBox();
            label4 = new Label();
            lstZadania = new ListView();
            columnHeader1 = new ColumnHeader();
            Opis = new ColumnHeader();
            Termin = new ColumnHeader();
            Kategoria = new ColumnHeader();
            Data = new ColumnHeader();
            ID = new ColumnHeader();
            btnEdytujZadanie = new Button();
            btnOznaczWykonane = new Button();
            btnUsunZadanie = new Button();
            btnOdswiez = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCzyscPola);
            groupBox1.Controls.Add(btnDodajZapiszZadanie);
            groupBox1.Controls.Add(chkCzyWykonane);
            groupBox1.Controls.Add(dtpTermin);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbKategorieZadania);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtOpis);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 304);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Szczegóły zadania";
            // 
            // btnCzyscPola
            // 
            btnCzyscPola.Location = new Point(87, 216);
            btnCzyscPola.Name = "btnCzyscPola";
            btnCzyscPola.Size = new Size(75, 23);
            btnCzyscPola.TabIndex = 8;
            btnCzyscPola.Text = "Wyczyść";
            btnCzyscPola.UseVisualStyleBackColor = true;
            btnCzyscPola.Click += btnCzyscPola_Click;
            // 
            // btnDodajZapiszZadanie
            // 
            btnDodajZapiszZadanie.Location = new Point(6, 216);
            btnDodajZapiszZadanie.Name = "btnDodajZapiszZadanie";
            btnDodajZapiszZadanie.Size = new Size(75, 23);
            btnDodajZapiszZadanie.TabIndex = 7;
            btnDodajZapiszZadanie.Text = "Dodaj";
            btnDodajZapiszZadanie.UseVisualStyleBackColor = true;
            btnDodajZapiszZadanie.Click += btnDodajZapiszZadanie_Click;
            // 
            // chkCzyWykonane
            // 
            chkCzyWykonane.AutoSize = true;
            chkCzyWykonane.Location = new Point(6, 191);
            chkCzyWykonane.Name = "chkCzyWykonane";
            chkCzyWykonane.Size = new Size(82, 19);
            chkCzyWykonane.TabIndex = 6;
            chkCzyWykonane.Text = "Wykonane";
            chkCzyWykonane.UseVisualStyleBackColor = true;
            // 
            // dtpTermin
            // 
            dtpTermin.Checked = false;
            dtpTermin.Format = DateTimePickerFormat.Short;
            dtpTermin.Location = new Point(6, 162);
            dtpTermin.Name = "dtpTermin";
            dtpTermin.ShowCheckBox = true;
            dtpTermin.Size = new Size(200, 23);
            dtpTermin.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 144);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 4;
            label3.Text = "Termin (opcjonalnie):";
            // 
            // cmbKategorieZadania
            // 
            cmbKategorieZadania.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategorieZadania.FormattingEnabled = true;
            cmbKategorieZadania.Location = new Point(6, 118);
            cmbKategorieZadania.Name = "cmbKategorieZadania";
            cmbKategorieZadania.Size = new Size(200, 23);
            cmbKategorieZadania.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 100);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Kategoria:";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(6, 37);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.ScrollBars = ScrollBars.Vertical;
            txtOpis.Size = new Size(200, 60);
            txtOpis.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Opis:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnUsunWybranaKategorie);
            groupBox2.Controls.Add(cmbKategorieDoUsuniecia);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(btnDodajKategorie);
            groupBox2.Controls.Add(txtNowaKategoria);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(222, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(113, 304);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kategorie";
            // 
            // btnUsunWybranaKategorie
            // 
            btnUsunWybranaKategorie.Location = new Point(6, 121);
            btnUsunWybranaKategorie.Name = "btnUsunWybranaKategorie";
            btnUsunWybranaKategorie.Size = new Size(75, 23);
            btnUsunWybranaKategorie.TabIndex = 5;
            btnUsunWybranaKategorie.Text = "Usuń";
            btnUsunWybranaKategorie.UseVisualStyleBackColor = true;
            btnUsunWybranaKategorie.Click += btnUsunWybranaKategorie_Click;
            // 
            // cmbKategorieDoUsuniecia
            // 
            cmbKategorieDoUsuniecia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategorieDoUsuniecia.FormattingEnabled = true;
            cmbKategorieDoUsuniecia.Location = new Point(6, 92);
            cmbKategorieDoUsuniecia.Name = "cmbKategorieDoUsuniecia";
            cmbKategorieDoUsuniecia.Size = new Size(101, 23);
            cmbKategorieDoUsuniecia.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 74);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 3;
            label5.Text = "Usuń kategorie:";
            // 
            // btnDodajKategorie
            // 
            btnDodajKategorie.Location = new Point(6, 48);
            btnDodajKategorie.Name = "btnDodajKategorie";
            btnDodajKategorie.Size = new Size(101, 23);
            btnDodajKategorie.TabIndex = 2;
            btnDodajKategorie.Text = "Dodaj";
            btnDodajKategorie.UseVisualStyleBackColor = true;
            btnDodajKategorie.Click += btnDodajKategorie_Click;
            // 
            // txtNowaKategoria
            // 
            txtNowaKategoria.Location = new Point(6, 19);
            txtNowaKategoria.Name = "txtNowaKategoria";
            txtNowaKategoria.Size = new Size(100, 23);
            txtNowaKategoria.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 19);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 0;
            label4.Text = "Nowa kategoria:";
            // 
            // lstZadania
            // 
            lstZadania.Columns.AddRange(new ColumnHeader[] { columnHeader1, Opis, Termin, Kategoria, Data, ID });
            lstZadania.FullRowSelect = true;
            lstZadania.GridLines = true;
            lstZadania.Location = new Point(341, 12);
            lstZadania.MultiSelect = false;
            lstZadania.Name = "lstZadania";
            lstZadania.Size = new Size(674, 268);
            lstZadania.TabIndex = 2;
            lstZadania.UseCompatibleStateImageBehavior = false;
            lstZadania.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "✓";
            columnHeader1.Width = 30;
            // 
            // Opis
            // 
            Opis.Text = "Opis";
            Opis.Width = 300;
            // 
            // Termin
            // 
            Termin.Text = "Termin";
            Termin.Width = 100;
            // 
            // Kategoria
            // 
            Kategoria.Text = "Kategoria";
            Kategoria.Width = 120;
            // 
            // Data
            // 
            Data.Text = "Data utworzenia";
            Data.Width = 120;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 0;
            // 
            // btnEdytujZadanie
            // 
            btnEdytujZadanie.Location = new Point(341, 286);
            btnEdytujZadanie.Name = "btnEdytujZadanie";
            btnEdytujZadanie.Size = new Size(116, 23);
            btnEdytujZadanie.TabIndex = 3;
            btnEdytujZadanie.Text = "Edytuj zaznaczone";
            btnEdytujZadanie.UseVisualStyleBackColor = true;
            btnEdytujZadanie.Click += btnEdytujZadanie_Click;
            // 
            // btnOznaczWykonane
            // 
            btnOznaczWykonane.Location = new Point(463, 286);
            btnOznaczWykonane.Name = "btnOznaczWykonane";
            btnOznaczWykonane.Size = new Size(86, 23);
            btnOznaczWykonane.TabIndex = 4;
            btnOznaczWykonane.Text = "Zmień status";
            btnOznaczWykonane.UseVisualStyleBackColor = true;
            btnOznaczWykonane.Click += btnOznaczWykonane_Click;
            // 
            // btnUsunZadanie
            // 
            btnUsunZadanie.Location = new Point(555, 286);
            btnUsunZadanie.Name = "btnUsunZadanie";
            btnUsunZadanie.Size = new Size(107, 23);
            btnUsunZadanie.TabIndex = 5;
            btnUsunZadanie.Text = "Usuń zaznaczone";
            btnUsunZadanie.UseVisualStyleBackColor = true;
            btnUsunZadanie.Click += btnUsunZadanie_Click;
            // 
            // btnOdswiez
            // 
            btnOdswiez.Location = new Point(928, 286);
            btnOdswiez.Name = "btnOdswiez";
            btnOdswiez.Size = new Size(83, 23);
            btnOdswiez.TabIndex = 6;
            btnOdswiez.Text = "Odśwież listę";
            btnOdswiez.UseVisualStyleBackColor = true;
            btnOdswiez.Click += btnOdswiez_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 317);
            Controls.Add(btnOdswiez);
            Controls.Add(btnUsunZadanie);
            Controls.Add(btnOznaczWykonane);
            Controls.Add(btnEdytujZadanie);
            Controls.Add(lstZadania);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Task Manager";
            Click += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtOpis;
        private Label label1;
        private Button btnCzyscPola;
        private Button btnDodajZapiszZadanie;
        private CheckBox chkCzyWykonane;
        private DateTimePicker dtpTermin;
        private Label label3;
        private ComboBox cmbKategorieZadania;
        private Label label2;
        private GroupBox groupBox2;
        private Label label4;
        private Button btnDodajKategorie;
        private TextBox txtNowaKategoria;
        private ListView lstZadania;
        private ColumnHeader columnHeader1;
        private ColumnHeader Opis;
        private ColumnHeader Termin;
        private ColumnHeader Kategoria;
        private ColumnHeader Data;
        private ColumnHeader ID;
        private Button btnEdytujZadanie;
        private Button btnOznaczWykonane;
        private Button btnUsunZadanie;
        private Button btnOdswiez;
        private Button btnUsunWybranaKategorie;
        private ComboBox cmbKategorieDoUsuniecia;
        private Label label5;
    }
}
