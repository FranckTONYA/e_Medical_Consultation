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
            this.SuspendLayout();
            // 
            // button_patient
            // 
            this.button_patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_patient.Location = new System.Drawing.Point(858, 234);
            this.button_patient.Name = "button_patient";
            this.button_patient.Size = new System.Drawing.Size(141, 46);
            this.button_patient.TabIndex = 6;
            this.button_patient.Text = "Patient";
            this.button_patient.UseVisualStyleBackColor = true;
            this.button_patient.Click += new System.EventHandler(this.ConnexionPatient);
            // 
            // button_medecin
            // 
            this.button_medecin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_medecin.Location = new System.Drawing.Point(443, 234);
            this.button_medecin.Name = "button_medecin";
            this.button_medecin.Size = new System.Drawing.Size(142, 46);
            this.button_medecin.TabIndex = 5;
            this.button_medecin.Text = "Médecin";
            this.button_medecin.UseVisualStyleBackColor = true;
            this.button_medecin.Click += new System.EventHandler(this.ConnexionMedecin);
            // 
            // button_admin
            // 
            this.button_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_admin.Location = new System.Drawing.Point(61, 234);
            this.button_admin.Name = "button_admin";
            this.button_admin.Size = new System.Drawing.Size(146, 46);
            this.button_admin.TabIndex = 4;
            this.button_admin.Text = "Administrateur";
            this.button_admin.UseVisualStyleBackColor = true;
            this.button_admin.Click += new System.EventHandler(this.ConnexionAdmin);
            // 
            // consultation_medicale
            // 
            this.consultation_medicale.AutoSize = true;
            this.consultation_medicale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultation_medicale.Location = new System.Drawing.Point(353, 36);
            this.consultation_medicale.Name = "consultation_medicale";
            this.consultation_medicale.Size = new System.Drawing.Size(390, 29);
            this.consultation_medicale.TabIndex = 1;
            this.consultation_medicale.Text = "Consultation médicale en ligne";
            this.consultation_medicale.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 514);
            this.Controls.Add(this.button_patient);
            this.Controls.Add(this.button_medecin);
            this.Controls.Add(this.button_admin);
            this.Controls.Add(this.consultation_medicale);
            this.Name = "Principal";
            this.Text = "Consultation médicale en ligne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_patient;
        private System.Windows.Forms.Button button_medecin;
        private System.Windows.Forms.Button button_admin;
        private System.Windows.Forms.Label consultation_medicale;
    }
}