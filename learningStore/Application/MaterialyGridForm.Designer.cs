namespace Application
{
    partial class MaterialyGridForm
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
            this.materialGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // materialGridView
            // 
            this.materialGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialGridView.Location = new System.Drawing.Point(0, 0);
            this.materialGridView.Name = "materialGridView";
            this.materialGridView.Size = new System.Drawing.Size(598, 389);
            this.materialGridView.TabIndex = 0;
            this.materialGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialGridView_CellContentClick);
            this.materialGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialGridView_CellDoubleClick);
            // 
            // MaterialyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 389);
            this.Controls.Add(this.materialGridView);
            this.Name = "MaterialyForm";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MaterialyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.materialGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView materialGridView;

    }
}