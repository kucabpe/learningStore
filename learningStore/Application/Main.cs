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

        private MaterialyGridForm getMaterialyGridForm()
        {
            MaterialyGridForm form = new MaterialyGridForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;

            Thread thread = new Thread(new ThreadStart(form.RefreshData));

            thread.Start();

            flowLayoutPanel1.Visible = true;
            progressBar1.Visible = true;

            while (thread.IsAlive) Refresh();

            thread.Join();

            flowLayoutPanel1.Visible = false;
            progressBar1.Visible = false;

            return form;
        }

        private UzivateleGridForm getUzivateleGridForm()
        {
            UzivateleGridForm form = new UzivateleGridForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;

            Thread thread = new Thread(new ThreadStart(form.RefreshData));

            thread.Start();

            flowLayoutPanel1.Visible = true;
            progressBar1.Visible = true;

            while (thread.IsAlive) Refresh();

            thread.Join();

            flowLayoutPanel1.Visible = false;
            progressBar1.Visible = false;

            return form;
        }

        private void seznamMaterialuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialyGridForm form = getMaterialyGridForm();
            form.Show();
        }

        private void pridatMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MaterialForm form = new MaterialForm(-1);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
                        
        }

        private void seznamUzivateluToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UzivateleGridForm form = getUzivateleGridForm();
            form.Show();
        }

    }
}
