namespace ConsultationMedicale
{
    partial class Principal
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
            this.button_patient = new System.Windows.Forms.Button();
            this.button_medecin = new System.Windows.Forms.Button();
            this.button_admin = new System.Windows.Forms.Button();
            this.consultation_medicale = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.homePanel = new System.Windows.Forms.Panel();
            this.panelCentral.SuspendLayout();
            this.homePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_patient
            // 
            this.button_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_patient.Location = new System.Drawing.Point(716, 364);
            this.button_patient.Name = "button_patient";
            this.button_patient.Size = new System.Drawing.Size(178, 46);
            this.button_patient.TabIndex = 6;
            this.button_patient.Text = "Patient";
            this.button_patient.UseVisualStyleBackColor = true;
            this.button_patient.Click += new System.EventHandler(this.ConnexionPatient);
            // 
            // button_medecin
            // 
            this.button_medecin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_medecin.Location = new System.Drawing.Point(384, 364);
            this.button_medecin.Name = "button_medecin";
            this.button_medecin.Size = new System.Drawing.Size(179, 46);
            this.button_medecin.TabIndex = 5;
            this.button_medecin.Text = "Médecin";
            this.button_medecin.UseVisualStyleBackColor = true;
            this.button_medecin.Click += new System.EventHandler(this.ConnexionMedecin);
            // 
            // button_admin
            // 
            this.button_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_admin.Location = new System.Drawing.Point(59, 364);
            this.button_admin.Name = "button_admin";
            this.button_admin.Size = new System.Drawing.Size(183, 46);
            this.button_admin.TabIndex = 4;
            this.button_admin.Text = "Administrateur";
            this.button_admin.UseVisualStyleBackColor = true;
            this.button_admin.Click += new System.EventHandler(this.ConnexionAdmin);
            // 
            // consultation_medicale
            // 
            this.consultation_medicale.AutoSize = true;
            this.consultation_medicale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultation_medicale.Location = new System.Drawing.Point(237, 47);
            this.consultation_medicale.Name = "consultation_medicale";
            this.consultation_medicale.Size = new System.Drawing.Size(451, 25);
            this.consultation_medicale.TabIndex = 1;
            this.consultation_medicale.Text = "Bienvenue à la consultation médicale en ligne";
            this.consultation_medicale.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Veuillez sélectionner le profil associé";
            // 
            // panelCentral
            // 
            this.panelCentral.Controls.Add(this.homePanel);
            this.panelCentral.Location = new System.Drawing.Point(29, 24);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1868, 1003);
            this.panelCentral.TabIndex = 8;
            // 
            // homePanel
            // 
            this.homePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.homePanel.Controls.Add(this.consultation_medicale);
            this.homePanel.Controls.Add(this.button_admin);
            this.homePanel.Controls.Add(this.button_patient);
            this.homePanel.Controls.Add(this.label1);
            this.homePanel.Controls.Add(this.button_medecin);
            this.homePanel.Location = new System.Drawing.Point(429, 48);
            this.homePanel.Name = "homePanel";
            this.homePanel.Size = new System.Drawing.Size(968, 618);
            this.homePanel.TabIndex = 8;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panelCentral);
            this.Name = "Principal";
            this.Text = "Consultation médicale en ligne";
            this.panelCentral.ResumeLayout(false);
            this.homePanel.ResumeLayout(false);
            this.homePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_patient;
        private System.Windows.Forms.Button button_medecin;
        private System.Windows.Forms.Button button_admin;
        private System.Windows.Forms.Label consultation_medicale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Panel homePanel;
    }
}