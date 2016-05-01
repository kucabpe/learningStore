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

namespace Application
{
    public partial class UzivatelDetail : Form
    {
        private Uzivatel Uzivatel;
        private UzivatelTable UzivatelTable;
        private UpozorneniTable UpozorneniTable;
        private UzivateleGridForm UzivateleGridForum;
        private Icon treeIcon = new Icon(@"../../resource/icon/message.ico");

        public UzivatelDetail(int id, UzivateleGridForm UzivateleGridForm)
        {
            InitializeComponent();
            UzivatelTable = new UzivatelTable();
            UpozorneniTable = new UpozorneniTable();

            this.UzivateleGridForum = UzivateleGridForm;

            InitData(id);
        }

        private void InitData(int uID)
        {
            Uzivatel = UzivatelTable.SelectByID(uID);

            TitleLabel.Text += string.Format("{0} {1}", Uzivatel.Jmeno, Uzivatel.Prijmeni);
            JmenoLabel.Text += Uzivatel.Jmeno;
            PrijmeniLabel.Text += Uzivatel.Prijmeni;
            LoginLabel.Text += Uzivatel.Login;
            emailTextBox.Text = Uzivatel.Email;
            RoleLabel.Text += Uzivatel.Role;
            DatumRegLabel.Text += Uzivatel.Registrace.ToShortDateString();

            emailDataGrid.ColumnCount = 3;
            int i = 0;

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Image = treeIcon.ToBitmap();
            iconColumn.Width = 30;
            iconColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            emailDataGrid.Columns.Insert(i, iconColumn);
            i += 1;

            emailDataGrid.Columns[i].Width = 110;
            i += 1;

            emailDataGrid.Columns[i].Width = 126;
            i += 1;

            emailDataGrid.Columns[i].Width = 108;

            Collection<Upozorneni> Upozorneni = UpozorneniTable.SelectByAdresat(uID);

            foreach (var item in Upozorneni)
            {
                emailDataGrid.Rows.Add(null, item.Od.Email, item.Predmet, item.Datum);
            }

         }

        private void Potvrditzmenybut_Click(object sender, EventArgs e)
        {
            Uzivatel.Email = emailTextBox.Text;

            UzivatelTable.Update(Uzivatel);

            UzivateleGridForum.RefreshData();

            Dialog.ChangeSaved notify = new Dialog.ChangeSaved();
            notify.ShowDialog();
        }
    }
}
