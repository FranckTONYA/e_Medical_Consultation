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
            this.components = new System.ComponentModel.Container();
            this.dossierListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.patientTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dossierPanel = new System.Windows.Forms.Panel();
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.enregistrerButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nbreConsultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.dossierPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
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
            this.dossierListBox.Size = new System.Drawing.Size(357, 400);
            this.dossierListBox.TabIndex = 5;
            this.dossierListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeIndexListBox);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.patientTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 97);
            this.panel2.TabIndex = 0;
            // 
            // patientTextBox
            // 
            this.patientTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientTextBox.Location = new System.Drawing.Point(24, 47);
            this.patientTextBox.Name = "patientTextBox";
            this.patientTextBox.Size = new System.Drawing.Size(716, 28);
            this.patientTextBox.TabIndex = 1;
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
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(24, 47);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(428, 28);
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
            this.panel7.Location = new System.Drawing.Point(13, 153);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(506, 97);
            this.panel7.TabIndex = 5;
            // 
            // dossierPanel
            // 
            this.dossierPanel.Controls.Add(this.panel1);
            this.dossierPanel.Controls.Add(this.enregistrerButton);
            this.dossierPanel.Controls.Add(this.panel7);
            this.dossierPanel.Controls.Add(this.panel2);
            this.dossierPanel.Location = new System.Drawing.Point(402, 136);
            this.dossierPanel.Name = "dossierPanel";
            this.dossierPanel.Size = new System.Drawing.Size(800, 418);
            this.dossierPanel.TabIndex = 6;
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // enregistrerButton
            // 
            this.enregistrerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enregistrerButton.Location = new System.Drawing.Point(625, 349);
            this.enregistrerButton.Name = "enregistrerButton";
            this.enregistrerButton.Size = new System.Drawing.Size(148, 34);
            this.enregistrerButton.TabIndex = 6;
            this.enregistrerButton.Text = "Enregistrer";
            this.enregistrerButton.UseVisualStyleBackColor = true;
            this.enregistrerButton.Click += new System.EventHandler(this.Enregistrer);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nbreConsultTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(539, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 97);
            this.panel1.TabIndex = 7;
            // 
            // nbreConsultTextBox
            // 
            this.nbreConsultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbreConsultTextBox.Location = new System.Drawing.Point(24, 47);
            this.nbreConsultTextBox.Name = "nbreConsultTextBox";
            this.nbreConsultTextBox.Size = new System.Drawing.Size(191, 28);
            this.nbreConsultTextBox.TabIndex = 1;
            this.nbreConsultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombres de consultations";
            // 
            // DossiersPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dossierListBox);
            this.Controls.Add(this.dossierPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(320, 84);
            this.Name = "DossiersPatients";
            this.Size = new System.Drawing.Size(1225, 691);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.dossierPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox dossierListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel dossierPanel;
        private System.Windows.Forms.TextBox patientTextBox;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.Button enregistrerButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nbreConsultTextBox;
        private System.Windows.Forms.Label label2;
    }
}
