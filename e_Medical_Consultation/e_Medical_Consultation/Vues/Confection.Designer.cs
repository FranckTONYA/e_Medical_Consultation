namespace Glacier
{
    partial class Confection
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonPrecedent = new System.Windows.Forms.Button();
            this.buttonSuivant = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 7;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpPrincipal.Controls.Add(this.labelTitre, 1, 0);
            this.tlpPrincipal.Controls.Add(this.buttonPrecedent, 1, 2);
            this.tlpPrincipal.Controls.Add(this.buttonSuivant, 5, 2);
            this.tlpPrincipal.Controls.Add(this.buttonResume, 3, 2);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.Size = new System.Drawing.Size(720, 320);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.tlpPrincipal.SetColumnSpan(this.labelTitre, 5);
            this.labelTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.Location = new System.Drawing.Point(73, 0);
            this.labelTitre.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Padding = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.labelTitre.Size = new System.Drawing.Size(572, 42);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Xxxxxx - Yyyyyyy";
            this.labelTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPrecedent
            // 
            this.buttonPrecedent.AutoSize = true;
            this.buttonPrecedent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPrecedent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrecedent.Location = new System.Drawing.Point(76, 294);
            this.buttonPrecedent.Name = "buttonPrecedent";
            this.buttonPrecedent.Size = new System.Drawing.Size(163, 23);
            this.buttonPrecedent.TabIndex = 1;
            this.buttonPrecedent.Text = "Revenir sur le choix du support";
            this.buttonPrecedent.UseVisualStyleBackColor = true;
            // 
            // buttonSuivant
            // 
            this.buttonSuivant.AutoSize = true;
            this.buttonSuivant.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSuivant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSuivant.Location = new System.Drawing.Point(474, 294);
            this.buttonSuivant.Name = "buttonSuivant";
            this.buttonSuivant.Size = new System.Drawing.Size(168, 23);
            this.buttonSuivant.TabIndex = 3;
            this.buttonSuivant.Text = "Passer à la sélection des boules";
            this.buttonSuivant.UseVisualStyleBackColor = true;
            // 
            // buttonResume
            // 
            this.buttonResume.AutoSize = true;
            this.buttonResume.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResume.Location = new System.Drawing.Point(281, 294);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(151, 23);
            this.buttonResume.TabIndex = 2;
            this.buttonResume.Text = "Résumé de votre confection";
            this.buttonResume.UseVisualStyleBackColor = true;
            // 
            // Confection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(720, 320);
            this.Name = "Confection";
            this.Size = new System.Drawing.Size(720, 320);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Button buttonPrecedent;
        private System.Windows.Forms.Button buttonSuivant;
        private System.Windows.Forms.Button buttonResume;
    }
}
