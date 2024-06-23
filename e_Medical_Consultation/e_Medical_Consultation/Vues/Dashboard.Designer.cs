namespace ConsultationMedicale
{
    partial class Dashboard
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
            this.titreLabel = new System.Windows.Forms.Label();
            this.consultation_button = new System.Windows.Forms.Button();
            this.rdv_button = new System.Windows.Forms.Button();
            this.dossier_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // titreLabel
            // 
            this.titreLabel.AutoSize = true;
            this.titreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreLabel.Location = new System.Drawing.Point(522, 24);
            this.titreLabel.Name = "titreLabel";
            this.titreLabel.Size = new System.Drawing.Size(132, 24);
            this.titreLabel.TabIndex = 0;
            this.titreLabel.Text = "Accueil - xxx";
            // 
            // consultation_button
            // 
            this.consultation_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultation_button.Location = new System.Drawing.Point(267, 83);
            this.consultation_button.Name = "consultation_button";
            this.consultation_button.Size = new System.Drawing.Size(136, 39);
            this.consultation_button.TabIndex = 1;
            this.consultation_button.Text = "Consultations";
            this.consultation_button.UseVisualStyleBackColor = true;
            this.consultation_button.Click += new System.EventHandler(this.AfficherConsultations);
            // 
            // rdv_button
            // 
            this.rdv_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdv_button.Location = new System.Drawing.Point(478, 83);
            this.rdv_button.Name = "rdv_button";
            this.rdv_button.Size = new System.Drawing.Size(136, 39);
            this.rdv_button.TabIndex = 2;
            this.rdv_button.Text = "Rendez-vous";
            this.rdv_button.UseVisualStyleBackColor = true;
            this.rdv_button.Click += new System.EventHandler(this.AfficherLesRendezVous);
            // 
            // dossier_button
            // 
            this.dossier_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dossier_button.Location = new System.Drawing.Point(682, 83);
            this.dossier_button.Name = "dossier_button";
            this.dossier_button.Size = new System.Drawing.Size(173, 39);
            this.dossier_button.TabIndex = 3;
            this.dossier_button.Text = "Dossiers patients";
            this.dossier_button.UseVisualStyleBackColor = true;
            this.dossier_button.Click += new System.EventHandler(this.AfficherDossiersPatients);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(905, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Utilisateurs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AfficherUtilisateurs);
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Location = new System.Drawing.Point(19, 158);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(1235, 765);
            this.dashboardPanel.TabIndex = 5;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dossier_button);
            this.Controls.Add(this.rdv_button);
            this.Controls.Add(this.consultation_button);
            this.Controls.Add(this.titreLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1288, 944);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.Button consultation_button;
        private System.Windows.Forms.Button rdv_button;
        private System.Windows.Forms.Button dossier_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel dashboardPanel;
    }
}
