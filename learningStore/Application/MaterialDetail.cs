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
    public partial class MaterialDetail : Form
    {
        private Material Material { get; set; }
        private ProvedlTable ProvedlTable = new ProvedlTable();
        private RevizeTable RevizeTable = new RevizeTable();

        public MaterialDetail(int id)
        {
            InitializeComponent();
            Material = new MaterialTable().SelectByIdMaterial(id);
            InitData();
        }

        private void InitData()
        {
            TypLabel.Text += Material.Typ;
            DokumentLabel.Text += Material.Dokument;
            DatumLabel.Text += Material.Datum.ToShortDateString();
            OkruhLabel.Text += Material.Okruh;
            NahralLabel.Text += string.Format("{0} {1} ({2})", Material.Uzivatel.Jmeno, Material.Uzivatel.Prijmeni, Material.Uzivatel.Login.ToUpper());


            int idRevize = RevizeTable.SelectByMaterial(Material.MId);

            Collection<Provedl> provedl = ProvedlTable.SelectByRevision(idRevize);

            foreach (var p in provedl)
            {
                string uzivatel = string.Format("{0} {1} ({2})", p.Uzivatel.Jmeno, p.Uzivatel.Prijmeni, p.Uzivatel.Login.ToUpper());
                string date = p.Datum.ToShortDateString();
                string url = p.Revize.Url;

                dataGridView1.Rows.Add(uzivatel, date, url);
            }
        }

        private void MaterialDetail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
