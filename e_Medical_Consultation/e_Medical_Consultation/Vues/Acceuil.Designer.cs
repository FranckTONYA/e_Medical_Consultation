namespace ConsultationMedicale
{
    partial class Accueil
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
            this.connexion_admin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_patient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connexion_admin
            // 
            this.connexion_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connexion_admin.Location = new System.Drawing.Point(95, 203);
            this.connexion_admin.Name = "connexion_admin";
            this.connexion_admin.Size = new System.Drawing.Size(146, 46);
            this.connexion_admin.TabIndex = 2;
            this.connexion_admin.Text = "Administrateur";
            this.connexion_admin.UseVisualStyleBackColor = true;
            this.connexion_admin.Click += new System.EventHandler(this.AfficherConnexionAdmin);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(405, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Médecin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AfficherConnexionMedecin);
            // 
            // button_patient
            // 
            this.button_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_patient.Location = new System.Drawing.Point(735, 203);
            this.button_patient.Name = "button_patient";
            this.button_patient.Size = new System.Drawing.Size(141, 46);
            this.button_patient.TabIndex = 4;
            this.button_patient.Text = "Patient";
            this.button_patient.UseVisualStyleBackColor = true;
            this.button_patient.Click += new System.EventHandler(this.AfficherConnexionPatient);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Veuillez selectionner le profil associé";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_patient);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.connexion_admin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(960, 394);
            this.Name = "Accueil";
            this.Size = new System.Drawing.Size(960, 394);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connexion_admin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_patient;
        private System.Windows.Forms.Label label1;
    }
}
