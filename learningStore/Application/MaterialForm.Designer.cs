namespace Application
{
    partial class MaterialForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TypBox = new System.Windows.Forms.TextBox();
            this.DokumentBox = new System.Windows.Forms.TextBox();
            this.DatumBox = new System.Windows.Forms.TextBox();
            this.OkruhBox = new System.Windows.Forms.TextBox();
            this.PredmetBox = new System.Windows.Forms.TextBox();
            this.UzivatelBox = new System.Windows.Forms.TextBox();
            this.ulozit = new System.Windows.Forms.Button();
            this.storno = new System.Windows.Forms.Button();
            this.smazat = new System.Windows.Forms.Button();
            this.predmetComboBox = new System.Windows.Forms.ComboBox();
            this.uzivatelComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Typ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(39, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dokument:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(39, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(39, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Okruh:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(402, 350);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1;
            this.lineShape1.X2 = 401;
            this.lineShape1.Y1 = 200;
            this.lineShape1.Y2 = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(39, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Předmět:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(39, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nahrál uživatel:";
            // 
            // TypBox
            // 
            this.TypBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypBox.Location = new System.Drawing.Point(177, 25);
            this.TypBox.Name = "TypBox";
            this.TypBox.Size = new System.Drawing.Size(79, 26);
            this.TypBox.TabIndex = 1;
            // 
            // DokumentBox
            // 
            this.DokumentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DokumentBox.Location = new System.Drawing.Point(177, 69);
            this.DokumentBox.Name = "DokumentBox";
            this.DokumentBox.Size = new System.Drawing.Size(157, 26);
            this.DokumentBox.TabIndex = 2;
            // 
            // DatumBox
            // 
            this.DatumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatumBox.Location = new System.Drawing.Point(177, 110);
            this.DatumBox.Name = "DatumBox";
            this.DatumBox.Size = new System.Drawing.Size(118, 26);
            this.DatumBox.TabIndex = 3;
            // 
            // OkruhBox
            // 
            this.OkruhBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OkruhBox.Location = new System.Drawing.Point(177, 149);
            this.OkruhBox.Name = "OkruhBox";
            this.OkruhBox.Size = new System.Drawing.Size(79, 26);
            this.OkruhBox.TabIndex = 4;
            // 
            // PredmetBox
            // 
            this.PredmetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PredmetBox.Location = new System.Drawing.Point(196, 217);
            this.PredmetBox.Name = "PredmetBox";
            this.PredmetBox.ReadOnly = true;
            this.PredmetBox.Size = new System.Drawing.Size(167, 26);
            this.PredmetBox.TabIndex = 9;
            // 
            // UzivatelBox
            // 
            this.UzivatelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UzivatelBox.Location = new System.Drawing.Point(196, 262);
            this.UzivatelBox.Name = "UzivatelBox";
            this.UzivatelBox.ReadOnly = true;
            this.UzivatelBox.Size = new System.Drawing.Size(118, 26);
            this.UzivatelBox.TabIndex = 10;
            // 
            // ulozit
            // 
            this.ulozit.Location = new System.Drawing.Point(44, 309);
            this.ulozit.Name = "ulozit";
            this.ulozit.Size = new System.Drawing.Size(102, 33);
            this.ulozit.TabIndex = 7;
            this.ulozit.Text = "Uložit";
            this.ulozit.UseVisualStyleBackColor = true;
            this.ulozit.Click += new System.EventHandler(this.ulozit_Click);
            // 
            // storno
            // 
            this.storno.Location = new System.Drawing.Point(291, 309);
            this.storno.Name = "storno";
            this.storno.Size = new System.Drawing.Size(89, 33);
            this.storno.TabIndex = 9;
            this.storno.Text = "Stornovat";
            this.storno.UseVisualStyleBackColor = true;
            this.storno.Click += new System.EventHandler(this.storno_Click);
            // 
            // smazat
            // 
            this.smazat.Location = new System.Drawing.Point(165, 309);
            this.smazat.Name = "smazat";
            this.smazat.Size = new System.Drawing.Size(103, 33);
            this.smazat.TabIndex = 8;
            this.smazat.Text = "Smazat";
            this.smazat.UseVisualStyleBackColor = true;
            this.smazat.Click += new System.EventHandler(this.smazat_Click);
            // 
            // predmetComboBox
            // 
            this.predmetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predmetComboBox.FormattingEnabled = true;
            this.predmetComboBox.Location = new System.Drawing.Point(196, 217);
            this.predmetComboBox.Name = "predmetComboBox";
            this.predmetComboBox.Size = new System.Drawing.Size(184, 28);
            this.predmetComboBox.TabIndex = 5;
            // 
            // uzivatelComboBox
            // 
            this.uzivatelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uzivatelComboBox.FormattingEnabled = true;
            this.uzivatelComboBox.Location = new System.Drawing.Point(196, 262);
            this.uzivatelComboBox.Name = "uzivatelComboBox";
            this.uzivatelComboBox.Size = new System.Drawing.Size(121, 28);
            this.uzivatelComboBox.TabIndex = 6;
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 350);
            this.Controls.Add(this.uzivatelComboBox);
            this.Controls.Add(this.predmetComboBox);
            this.Controls.Add(this.smazat);
            this.Controls.Add(this.storno);
            this.Controls.Add(this.ulozit);
            this.Controls.Add(this.UzivatelBox);
            this.Controls.Add(this.PredmetBox);
            this.Controls.Add(this.OkruhBox);
            this.Controls.Add(this.DatumBox);
            this.Controls.Add(this.DokumentBox);
            this.Controls.Add(this.TypBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "MaterialForm";
            this.Text = "Formulář";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TypBox;
        private System.Windows.Forms.TextBox DokumentBox;
        private System.Windows.Forms.TextBox DatumBox;
        private System.Windows.Forms.TextBox OkruhBox;
        private System.Windows.Forms.TextBox PredmetBox;
        private System.Windows.Forms.TextBox UzivatelBox;
        private System.Windows.Forms.Button ulozit;
        private System.Windows.Forms.Button storno;
        private System.Windows.Forms.Button smazat;
        private System.Windows.Forms.ComboBox predmetComboBox;
        private System.Windows.Forms.ComboBox uzivatelComboBox;

    }
}