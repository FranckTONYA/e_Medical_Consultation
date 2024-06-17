namespace ConsultationMedicale
{
    partial class Consultations
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
            this.groupNappage = new PDSGBD.UI.RadioGroup();
            this.consultation_listBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rapport_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.prescription_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.medecin_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdv_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.patient_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupNappage
            // 
            this.groupNappage.BackColor = System.Drawing.SystemColors.Control;
            this.groupNappage.CheckedIndex = -1;
            this.groupNappage.CheckedItem = null;
            this.groupNappage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNappage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNappage.Location = new System.Drawing.Point(0, 0);
            this.groupNappage.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupNappage.Name = "groupNappage";
            this.groupNappage.Size = new System.Drawing.Size(1239, 596);
            this.groupNappage.TabIndex = 0;
            // 
            // consultation_listBox
            // 
            this.consultation_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultation_listBox.FormattingEnabled = true;
            this.consultation_listBox.ItemHeight = 22;
            this.consultation_listBox.Location = new System.Drawing.Point(26, 156);
            this.consultation_listBox.Name = "consultation_listBox";
            this.consultation_listBox.Size = new System.Drawing.Size(357, 378);
            this.consultation_listBox.TabIndex = 1;
            this.consultation_listBox.Click += new System.EventHandler(this.AfficherConsultation);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(406, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 418);
            this.panel1.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.rapport_textBox);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(13, 307);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(313, 97);
            this.panel6.TabIndex = 4;
            // 
            // rapport_textBox
            // 
            this.rapport_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rapport_textBox.Location = new System.Drawing.Point(24, 47);
            this.rapport_textBox.Name = "rapport_textBox";
            this.rapport_textBox.Size = new System.Drawing.Size(263, 28);
            this.rapport_textBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Rapport";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.prescription_textBox);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(395, 171);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 97);
            this.panel5.TabIndex = 2;
            // 
            // prescription_textBox
            // 
            this.prescription_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prescription_textBox.Location = new System.Drawing.Point(24, 47);
            this.prescription_textBox.Name = "prescription_textBox";
            this.prescription_textBox.Size = new System.Drawing.Size(263, 28);
            this.prescription_textBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prescription";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.medecin_textBox);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(395, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 97);
            this.panel4.TabIndex = 3;
            // 
            // medecin_textBox
            // 
            this.medecin_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medecin_textBox.Location = new System.Drawing.Point(24, 47);
            this.medecin_textBox.Name = "medecin_textBox";
            this.medecin_textBox.Size = new System.Drawing.Size(263, 28);
            this.medecin_textBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Médecin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdv_textBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(13, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 97);
            this.panel3.TabIndex = 2;
            // 
            // rdv_textBox
            // 
            this.rdv_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdv_textBox.Location = new System.Drawing.Point(24, 47);
            this.rdv_textBox.Name = "rdv_textBox";
            this.rdv_textBox.Size = new System.Drawing.Size(263, 28);
            this.rdv_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rendez-vous";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.patient_textBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 97);
            this.panel2.TabIndex = 0;
            // 
            // patient_textBox
            // 
            this.patient_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patient_textBox.Location = new System.Drawing.Point(24, 47);
            this.patient_textBox.Name = "patient_textBox";
            this.patient_textBox.Size = new System.Drawing.Size(263, 28);
            this.patient_textBox.TabIndex = 1;
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
            // Consultations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.consultation_listBox);
            this.Controls.Add(this.groupNappage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(320, 84);
            this.Name = "Consultations";
            this.Size = new System.Drawing.Size(1239, 596);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PDSGBD.UI.RadioGroup groupNappage;
        private System.Windows.Forms.ListBox consultation_listBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox patient_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox rdv_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox rapport_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox prescription_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox medecin_textBox;
        private System.Windows.Forms.Label label3;
    }
}
