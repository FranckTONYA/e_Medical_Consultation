namespace ConsultationMedicale
{
    partial class Utilisateurs
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.utilisateurListBox = new System.Windows.Forms.ListBox();
            this.nouveauButton = new System.Windows.Forms.Button();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.adresseTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.userPanel = new System.Windows.Forms.Panel();
            this.motDePassePanel = new System.Windows.Forms.Panel();
            this.motDePasseTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SupprimerButton = new System.Windows.Forms.Button();
            this.enregistrerButton = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nomErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.prenomErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.telErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.emailErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.adresseErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.mdpErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.userPanel.SuspendLayout();
            this.motDePassePanel.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prenomErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.telErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdpErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.panel1, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Size = new System.Drawing.Size(1357, 611);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.utilisateurListBox);
            this.panel1.Controls.Add(this.nouveauButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 587);
            this.panel1.TabIndex = 10;
            // 
            // utilisateurListBox
            // 
            this.utilisateurListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilisateurListBox.FormattingEnabled = true;
            this.utilisateurListBox.ItemHeight = 22;
            this.utilisateurListBox.Location = new System.Drawing.Point(42, 34);
            this.utilisateurListBox.Name = "utilisateurListBox";
            this.utilisateurListBox.Size = new System.Drawing.Size(357, 466);
            this.utilisateurListBox.TabIndex = 5;
            this.utilisateurListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeIndexListBox);
            // 
            // nouveauButton
            // 
            this.nouveauButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nouveauButton.Location = new System.Drawing.Point(285, 533);
            this.nouveauButton.Name = "nouveauButton";
            this.nouveauButton.Size = new System.Drawing.Size(114, 34);
            this.nouveauButton.TabIndex = 9;
            this.nouveauButton.Text = "Nouveau";
            this.nouveauButton.UseVisualStyleBackColor = true;
            this.nouveauButton.Click += new System.EventHandler(this.ReinitialiserFormulaire);
            // 
            // nomTextBox
            // 
            this.nomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomTextBox.Location = new System.Drawing.Point(24, 46);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(342, 28);
            this.nomTextBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nomTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 97);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date de naissance";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(13, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(398, 97);
            this.panel3.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(24, 46);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(342, 28);
            this.dateTimePicker.TabIndex = 1;
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prenomTextBox.Location = new System.Drawing.Point(24, 46);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(336, 28);
            this.prenomTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prénom";
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneTextBox.Location = new System.Drawing.Point(24, 46);
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(336, 28);
            this.telephoneTextBox.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.prenomTextBox);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(433, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 97);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Téléphone";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.telephoneTextBox);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(433, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(393, 97);
            this.panel5.TabIndex = 2;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(24, 46);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(342, 28);
            this.emailTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.emailTextBox);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(13, 249);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(398, 97);
            this.panel6.TabIndex = 4;
            // 
            // adresseTextBox
            // 
            this.adresseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adresseTextBox.Location = new System.Drawing.Point(24, 46);
            this.adresseTextBox.Name = "adresseTextBox";
            this.adresseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.adresseTextBox.Size = new System.Drawing.Size(336, 28);
            this.adresseTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Adresse";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.adresseTextBox);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(433, 249);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(393, 97);
            this.panel7.TabIndex = 5;
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.motDePassePanel);
            this.userPanel.Controls.Add(this.SupprimerButton);
            this.userPanel.Controls.Add(this.enregistrerButton);
            this.userPanel.Controls.Add(this.panel8);
            this.userPanel.Controls.Add(this.panel7);
            this.userPanel.Controls.Add(this.panel6);
            this.userPanel.Controls.Add(this.panel5);
            this.userPanel.Controls.Add(this.panel4);
            this.userPanel.Controls.Add(this.panel3);
            this.userPanel.Controls.Add(this.panel2);
            this.userPanel.Location = new System.Drawing.Point(437, 37);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(861, 553);
            this.userPanel.TabIndex = 6;
            // 
            // motDePassePanel
            // 
            this.motDePassePanel.Controls.Add(this.motDePasseTextBox);
            this.motDePassePanel.Controls.Add(this.label8);
            this.motDePassePanel.Location = new System.Drawing.Point(436, 364);
            this.motDePassePanel.Name = "motDePassePanel";
            this.motDePassePanel.Size = new System.Drawing.Size(390, 97);
            this.motDePassePanel.TabIndex = 9;
            // 
            // motDePasseTextBox
            // 
            this.motDePasseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motDePasseTextBox.Location = new System.Drawing.Point(24, 46);
            this.motDePasseTextBox.Name = "motDePasseTextBox";
            this.motDePasseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.motDePasseTextBox.Size = new System.Drawing.Size(336, 28);
            this.motDePasseTextBox.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mot de passe";
            // 
            // SupprimerButton
            // 
            this.SupprimerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupprimerButton.Location = new System.Drawing.Point(705, 499);
            this.SupprimerButton.Name = "SupprimerButton";
            this.SupprimerButton.Size = new System.Drawing.Size(138, 34);
            this.SupprimerButton.TabIndex = 8;
            this.SupprimerButton.Text = "Supprimer";
            this.SupprimerButton.UseVisualStyleBackColor = true;
            this.SupprimerButton.Click += new System.EventHandler(this.Supprimer);
            // 
            // enregistrerButton
            // 
            this.enregistrerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enregistrerButton.Location = new System.Drawing.Point(555, 499);
            this.enregistrerButton.Name = "enregistrerButton";
            this.enregistrerButton.Size = new System.Drawing.Size(138, 34);
            this.enregistrerButton.TabIndex = 7;
            this.enregistrerButton.Text = "Enregistrer";
            this.enregistrerButton.UseVisualStyleBackColor = true;
            this.enregistrerButton.Click += new System.EventHandler(this.Enregistrer);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.roleComboBox);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(13, 364);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(398, 97);
            this.panel8.TabIndex = 6;
            // 
            // roleComboBox
            // 
            this.roleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(24, 44);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(342, 30);
            this.roleComboBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rôle";
            // 
            // nomErrorProvider
            // 
            this.nomErrorProvider.ContainerControl = this;
            // 
            // prenomErrorProvider
            // 
            this.prenomErrorProvider.ContainerControl = this;
            // 
            // telErrorProvider
            // 
            this.telErrorProvider.ContainerControl = this;
            // 
            // emailErrorProvider
            // 
            this.emailErrorProvider.ContainerControl = this;
            // 
            // adresseErrorProvider
            // 
            this.adresseErrorProvider.ContainerControl = this;
            // 
            // mdpErrorProvider
            // 
            this.mdpErrorProvider.ContainerControl = this;
            // 
            // Utilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.tlpPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(320, 84);
            this.Name = "Utilisateurs";
            this.Size = new System.Drawing.Size(1357, 611);
            this.tlpPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.userPanel.ResumeLayout(false);
            this.motDePassePanel.ResumeLayout(false);
            this.motDePassePanel.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prenomErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.telErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adresseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdpErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.ListBox utilisateurListBox;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox adresseTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button enregistrerButton;
        private System.Windows.Forms.Button SupprimerButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nouveauButton;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel motDePassePanel;
        private System.Windows.Forms.TextBox motDePasseTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider nomErrorProvider;
        private System.Windows.Forms.ErrorProvider prenomErrorProvider;
        private System.Windows.Forms.ErrorProvider telErrorProvider;
        private System.Windows.Forms.ErrorProvider emailErrorProvider;
        private System.Windows.Forms.ErrorProvider adresseErrorProvider;
        private System.Windows.Forms.ErrorProvider mdpErrorProvider;
    }
}
