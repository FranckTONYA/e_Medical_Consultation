namespace ConsultationMedicale
{
    partial class DossiersPatients
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de id.
        /// </summary>
        private void InitializeComponent()
        {
            this.dossierListBox = new System.Windows.Forms.ListBox();
            this.patientTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.matriculeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dossierListBox
            // 
            this.dossierListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dossierListBox.FormattingEnabled = true;
            this.dossierListBox.ItemHeight = 22;
            this.dossierListBox.Location = new System.Drawing.Point(22, 141);
            this.dossierListBox.Name = "dossierListBox";
            this.dossierListBox.Size = new System.Drawing.Size(357, 378);
            this.dossierListBox.TabIndex = 5;
            // 
            // patientTextBox
            // 
            this.patientTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientTextBox.Location = new System.Drawing.Point(24, 47);
            this.patientTextBox.Name = "patientTextBox";
            this.patientTextBox.Size = new System.Drawing.Size(263, 28);
            this.patientTextBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.patientTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 97);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient";
            // 
            // matriculeTextBox
            // 
            this.matriculeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matriculeTextBox.Location = new System.Drawing.Point(24, 47);
            this.matriculeTextBox.Name = "matriculeTextBox";
            this.matriculeTextBox.Size = new System.Drawing.Size(263, 28);
            this.matriculeTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Matricule";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.matriculeTextBox);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(395, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 97);
            this.panel4.TabIndex = 3;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(24, 47);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(263, 28);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Description";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.descriptionTextBox);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(13, 149);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(313, 97);
            this.panel7.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(402, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 418);
            this.panel1.TabIndex = 6;
            // 
            // DossiersPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dossierListBox);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(320, 84);
            this.Name = "DossiersPatients";
            this.Size = new System.Drawing.Size(1225, 691);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox dossierListBox;
        private System.Windows.Forms.TextBox patientTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox matriculeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
    }
}
