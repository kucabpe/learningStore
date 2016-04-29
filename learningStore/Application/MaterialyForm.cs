﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using learningStore;
using learningStore.database.mssql;
using learningStore.tables;

namespace Application
{
    public partial class MaterialyForm : Form
    {
        private MaterialTable MaterialTable;
        private Collection<Material> Materials { get; set; }

        public MaterialyForm()
        {
            InitializeComponent();
            MaterialTable = new MaterialTable();
        }

        private void MaterialyForm_Load(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void ShowData()
        {
            materialGridView.AllowUserToAddRows = false;
            materialGridView.ReadOnly = true;

            materialGridView.ColumnCount = 7;
            int i = 0;

            materialGridView.Columns[i].Name = "id";
            materialGridView.Columns[i].Visible = false;
            i += 1;

            materialGridView.Columns[i].Name = "Typ";
            materialGridView.Columns[i].Width = 70;
            i += 1;

            materialGridView.Columns[i].Name = "Dokument";
            materialGridView.Columns[i].Width = 140;
            i += 1;

            materialGridView.Columns[i].Name = "Okruh";
            materialGridView.Columns[i].Width = 70;
            i += 1;

            materialGridView.Columns[i].Name = "Předmět";
            materialGridView.Columns[i].Width = 130;
            i += 1;

            materialGridView.Columns[i].Name = "Nahrál uživatel";
            materialGridView.Columns[i].Width = 110;
            materialGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            i += 1;

            materialGridView.Columns[i].Name = "Datum nahrání";
            materialGridView.Columns[i].Width = 120;
            materialGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var item in Materials)
            {
                materialGridView.Rows.Add(item.MId, item.Typ, item.Dokument, item.Okruh, item.Predmet.Nazev, item.Uzivatel.Login, item.Datum.ToShortDateString());
            }
        }

        public void RefreshData()
        {
            
            Materials = MaterialTable.Select();
            BindingList<Material> source = new BindingList<Material>(Materials);

            materialGridView.Rows.Clear();

            ShowData();

        }

        private void MaterialyForm_Shown(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void materialGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)materialGridView.Rows[e.RowIndex].Cells["id"].Value;
                MaterialDetail formMaterialDetail = new MaterialDetail(id);
                formMaterialDetail.ShowDialog();
                RefreshData();
            }
        }
    }
}