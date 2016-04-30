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
    public partial class UzivateleGridForm : Form
    {
        private Collection<Uzivatel> Uzivatele;
        private UzivatelTable UzivatelTable;
        private Icon treeIcon = new Icon(@"../../detail.ico");

        public UzivateleGridForm()
        {
            InitializeComponent();
            UzivatelTable = new UzivatelTable();
        }

        public void RefreshData()
        {
            Uzivatele = UzivatelTable.Select();
            uzivateleGridView.Rows.Clear();
            ShowData();
        }

        private void ShowData()
        {
            uzivateleGridView.AllowUserToAddRows = false;
            uzivateleGridView.ReadOnly = true;

            uzivateleGridView.ColumnCount = 6;
            int i = 0;

            uzivateleGridView.Columns[i].Name = "id";
            uzivateleGridView.Columns[i].Visible = false;
            i += 1;

            uzivateleGridView.Columns[i].Name = "Login";
            uzivateleGridView.Columns[i].Width = 80;
            i += 1;

            uzivateleGridView.Columns[i].Name = "Jméno";
            uzivateleGridView.Columns[i].Width = 100;
            i += 1;

            uzivateleGridView.Columns[i].Name = "Přijmení";
            uzivateleGridView.Columns[i].Width = 100;
            i += 1;

            uzivateleGridView.Columns[i].Name = "Email";
            uzivateleGridView.Columns[i].Width = 150;
            i += 1;

            uzivateleGridView.Columns[i].Name = "Heslo";
            uzivateleGridView.Columns[i].Width = 80;
            i += 1;

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Image = treeIcon.ToBitmap();
            iconColumn.HeaderText = "Detail";
            iconColumn.Width = 60;
            iconColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            uzivateleGridView.Columns.Insert(i, iconColumn);

            foreach (var item in Uzivatele)
            {
                uzivateleGridView.Rows.Add(item.UzId, item.Login, item.Jmeno, item.Prijmeni, item.Email, "********");
            }
        }

    }
}
