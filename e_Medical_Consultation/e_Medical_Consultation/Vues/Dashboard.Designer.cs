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
            this.consultationButton = new System.Windows.Forms.Button();
            this.rdvButton = new System.Windows.Forms.Button();
            this.dossierButton = new System.Windows.Forms.Button();
            this.utilisateurButton = new System.Windows.Forms.Button();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.deconnexionButton = new System.Windows.Forms.Button();
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
            // consultationButton
            // 
            this.consultationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.consultationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultationButton.ForeColor = System.Drawing.Color.White;
            this.consultationButton.Location = new System.Drawing.Point(321, 106);
            this.consultationButton.Name = "consultationButton";
            this.consultationButton.Size = new System.Drawing.Size(173, 39);
            this.consultationButton.TabIndex = 1;
            this.consultationButton.Text = "Consultations";
            this.consultationButton.UseVisualStyleBackColor = false;
            this.consultationButton.Click += new System.EventHandler(this.AfficherConsultations);
            // 
            // rdvButton
            // 
            this.rdvButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rdvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdvButton.ForeColor = System.Drawing.Color.White;
            this.rdvButton.Location = new System.Drawing.Point(552, 106);
            this.rdvButton.Name = "rdvButton";
            this.rdvButton.Size = new System.Drawing.Size(174, 39);
            this.rdvButton.TabIndex = 2;
            this.rdvButton.Text = "Rendez-vous";
            this.rdvButton.UseVisualStyleBackColor = false;
            this.rdvButton.Click += new System.EventHandler(this.AfficherLesRendezVous);
            // 
            // dossierButton
            // 
            this.dossierButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dossierButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dossierButton.ForeColor = System.Drawing.Color.White;
            this.dossierButton.Location = new System.Drawing.Point(781, 106);
            this.dossierButton.Name = "dossierButton";
            this.dossierButton.Size = new System.Drawing.Size(213, 39);
            this.dossierButton.TabIndex = 3;
            this.dossierButton.Text = "Dossiers patients";
            this.dossierButton.UseVisualStyleBackColor = false;
            this.dossierButton.Click += new System.EventHandler(this.AfficherDossiersPatients);
            // 
            // utilisateurButton
            // 
            this.utilisateurButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.utilisateurButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilisateurButton.ForeColor = System.Drawing.Color.White;
            this.utilisateurButton.Location = new System.Drawing.Point(1035, 106);
            this.utilisateurButton.Name = "utilisateurButton";
            this.utilisateurButton.Size = new System.Drawing.Size(176, 39);
            this.utilisateurButton.TabIndex = 4;
            this.utilisateurButton.Text = "Utilisateurs";
            this.utilisateurButton.UseVisualStyleBackColor = false;
            this.utilisateurButton.Click += new System.EventHandler(this.AfficherUtilisateurs);
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dashboardPanel.Location = new System.Drawing.Point(60, 158);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(1390, 765);
            this.dashboardPanel.TabIndex = 5;
            // 
            // deconnexionButton
            // 
            this.deconnexionButton.BackColor = System.Drawing.Color.OrangeRed;
            this.deconnexionButton.FlatAppearance.BorderSize = 0;
            this.deconnexionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deconnexionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deconnexionButton.ForeColor = System.Drawing.Color.White;
            this.deconnexionButton.Location = new System.Drawing.Point(1457, 24);
            this.deconnexionButton.Name = "deconnexionButton";
            this.deconnexionButton.Size = new System.Drawing.Size(162, 39);
            this.deconnexionButton.TabIndex = 6;
            this.deconnexionButton.Text = "Déconnexion";
            this.deconnexionButton.UseVisualStyleBackColor = false;
            this.deconnexionButton.Click += new System.EventHandler(this.Deconnexion);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deconnexionButton);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.utilisateurButton);
            this.Controls.Add(this.dossierButton);
            this.Controls.Add(this.rdvButton);
            this.Controls.Add(this.consultationButton);
            this.Controls.Add(this.titreLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1656, 944);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titreLabel;
        private System.Windows.Forms.Button consultationButton;
        private System.Windows.Forms.Button rdvButton;
        private System.Windows.Forms.Button dossierButton;
        private System.Windows.Forms.Button utilisateurButton;
        private System.Windows.Forms.Panel dashboardPanel;
        private System.Windows.Forms.Button deconnexionButton;
    }
}
