namespace Application
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seznamMateriáluToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatMateriálToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uživateleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seznamUživatelůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailToolStripMenuItem,
            this.uživateleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seznamMateriáluToolStripMenuItem,
            this.přidatMateriálToolStripMenuItem});
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.detailToolStripMenuItem.Text = "Materiály";
            // 
            // seznamMateriáluToolStripMenuItem
            // 
            this.seznamMateriáluToolStripMenuItem.Name = "seznamMateriáluToolStripMenuItem";
            this.seznamMateriáluToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.seznamMateriáluToolStripMenuItem.Text = "Seznam Materiálů";
            this.seznamMateriáluToolStripMenuItem.Click += new System.EventHandler(this.seznamMaterialuToolStripMenuItem_Click);
            // 
            // přidatMateriálToolStripMenuItem
            // 
            this.přidatMateriálToolStripMenuItem.Name = "přidatMateriálToolStripMenuItem";
            this.přidatMateriálToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.přidatMateriálToolStripMenuItem.Text = "Přidat Materiál";
            this.přidatMateriálToolStripMenuItem.Click += new System.EventHandler(this.pridatMaterialToolStripMenuItem_Click);
            // 
            // uživateleToolStripMenuItem
            // 
            this.uživateleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seznamUživatelůToolStripMenuItem});
            this.uživateleToolStripMenuItem.Name = "uživateleToolStripMenuItem";
            this.uživateleToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.uživateleToolStripMenuItem.Text = "Uživatelé";
            // 
            // seznamUživatelůToolStripMenuItem
            // 
            this.seznamUživatelůToolStripMenuItem.Name = "seznamUživatelůToolStripMenuItem";
            this.seznamUživatelůToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.seznamUživatelůToolStripMenuItem.Text = "Seznam uživatelů";
            this.seznamUživatelůToolStripMenuItem.Click += new System.EventHandler(this.seznamUzivateluToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 515);
            this.progressBar1.MarqueeAnimationSpeed = 5;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(784, 24);
            this.progressBar1.Step = 15;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadingLabel.Location = new System.Drawing.Point(331, 0);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(122, 21);
            this.loadingLabel.TabIndex = 5;
            this.loadingLabel.Text = "Loading data...";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel1.Controls.Add(this.splitter1);
            this.flowLayoutPanel1.Controls.Add(this.loadingLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 490);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 25);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(322, 15);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Učební sklad";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seznamMateriáluToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem přidatMateriálToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem uživateleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seznamUživatelůToolStripMenuItem;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Splitter splitter1;
    }
}

