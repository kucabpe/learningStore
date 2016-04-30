namespace Application
{
    partial class UzivateleGridForm
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
            this.uzivateleGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uzivateleGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uzivateleGridView
            // 
            this.uzivateleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uzivateleGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uzivateleGridView.Location = new System.Drawing.Point(0, 0);
            this.uzivateleGridView.Name = "uzivateleGridView";
            this.uzivateleGridView.Size = new System.Drawing.Size(563, 438);
            this.uzivateleGridView.TabIndex = 0;
            this.uzivateleGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uzivateleGridView_CellContentClick);
            this.uzivateleGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uzivateleGridView_CellContentDoubleClick);
            // 
            // UzivateleGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 438);
            this.Controls.Add(this.uzivateleGridView);
            this.Name = "UzivateleGridForm";
            this.Text = "Seznam uživatelů";
            ((System.ComponentModel.ISupportInitialize)(this.uzivateleGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView uzivateleGridView;
    }
}