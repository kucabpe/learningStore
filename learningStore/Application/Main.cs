using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();           
        }

        private MaterialyGridForm getMaterialyForm()
        {
            MaterialyGridForm form = new MaterialyGridForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;

            Thread thread = new Thread(new ThreadStart(form.RefreshData));

            thread.Start();

            loadingLabel.Visible = true;
            progressBar1.Visible = true;

            while (thread.IsAlive) Refresh();

            thread.Join();

            loadingLabel.Visible = false;
            progressBar1.Visible = false;

            return form;
        }

        private void seznamMaterialuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MaterialyGridForm form = getMaterialyForm();
            form.Show();
        }

        private void detailToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pridatMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MaterialForm form = new MaterialForm(-1);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
                        
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uzivateleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void seznamUzivateluToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
