using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using learningStore;
using learningStore.tables;
using Microsoft.VisualBasic;

namespace Application
{
    public partial class MaterialForm : Form
    {
        private Material Material {get; set;}
        private MaterialTable MaterialTable; 

        public MaterialForm(int idMaterial)
        {
            InitializeComponent();
            MaterialTable = new MaterialTable();

            if (idMaterial != -1)
            {
                Material = MaterialTable.SelectByIdMaterial(idMaterial);
                BindData();
                predmetComboBox.Hide();
                uzivatelComboBox.Hide();
            }
            else
            {
                smazat.Hide();
                PredmetBox.Hide();
                UzivatelBox.Hide();
                FillComboBox();
                Material = new Material { MId = -1, Predmet = null, Uzivatel = null };
            }
        }

        private int getNextID()
        {
            return MaterialTable.SelectLastId();
        }

        private void FillComboBox()
        {
            PredmetTable PredmetTable = new learningStore.tables.PredmetTable();
            Collection<Predmet> predmety = PredmetTable.Select();
            predmetComboBox.DataSource = predmety;
            predmetComboBox.DisplayMember = "Nazev";
            predmetComboBox.ValueMember = "PId";

            UzivatelTable UzivatelTable = new UzivatelTable();
            Collection<Uzivatel> uzivatele = UzivatelTable.SelectStudents();
            uzivatelComboBox.DataSource = uzivatele;
            uzivatelComboBox.DisplayMember = "Login";
            uzivatelComboBox.ValueMember = "UzId";
        }

        private void BindData()
        {
            TypBox.Text = Material.Typ;
            DokumentBox.Text = Material.Dokument;
            DatumBox.Text = Material.Datum.ToShortDateString();
            OkruhBox.Text = Material.Okruh;
            PredmetBox.Text = Material.Predmet.Nazev;
            UzivatelBox.Text = Material.Uzivatel.Login;
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BindBack()
        {
            Material m = new Material();

            bool IsInsert = Material.MId == -1 ? true : false;

            m.MId = Material.MId != -1 ? Material.MId : getNextID();
            m.Predmet = Material.Predmet != null ? Material.Predmet : new PredmetTable().SelectByID((int)predmetComboBox.SelectedValue);
            m.Uzivatel = Material.Uzivatel != null ? Material.Uzivatel : new UzivatelTable().SelectByID((int)uzivatelComboBox.SelectedValue);

            m.Typ = TypBox.Text;

            if (m.Typ != "skripta" && m.Typ != "test" && m.Typ != "projekt" && m.Typ != "ostatní")
            {
                Dialog.InvalidInput notify = new Dialog.InvalidInput();
                notify.ShowDialog();
                return;
            }

            m.Dokument = DokumentBox.Text; ;

            try
            {
                m.Datum = DateTime.Parse(DatumBox.Text);
            }
            catch (Exception)
            {
                Dialog.BadDateNotify notify = new Dialog.BadDateNotify();
                notify.ShowDialog();
                return;
            }

            m.Okruh = OkruhBox.Text;

            if (m.Okruh != "zap." && m.Okruh != "klzap." && m.Okruh != "zk.")
	        {
                Dialog.InvalidInput notify = new Dialog.InvalidInput();
                notify.ShowDialog();
                return;
	        }

            if (IsInsert)
            {
                MaterialTable.Insert(m);
            }
            else
            {
                MaterialTable.Update(m);
            }
        }

        private void Save()
        {
            BindBack();
            Close();
        }

        private void storno_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void smazat_Click(object sender, EventArgs e)
        {
            MaterialTable.Delete(Material);
            Close();
        }
    }
}
