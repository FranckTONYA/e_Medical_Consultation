namespace Glacier
{
    partial class SelectionBoules
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
            this.comboCategorieParfum = new System.Windows.Forms.ComboBox();
            this.listParfum = new System.Windows.Forms.ListBox();
            this.buttonAjouterBoule = new System.Windows.Forms.Button();
            this.buttonRetirerBoule = new System.Windows.Forms.Button();
            this.lvwBoules = new System.Windows.Forms.ListView();
            this.columnQuantite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnParfum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategorie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelCompteurBoules = new System.Windows.Forms.Label();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.Controls.Add(this.comboCategorieParfum, 0, 0);
            this.tlpPrincipal.Controls.Add(this.listParfum, 0, 1);
            this.tlpPrincipal.Controls.Add(this.buttonAjouterBoule, 1, 2);
            this.tlpPrincipal.Controls.Add(this.buttonRetirerBoule, 1, 3);
            this.tlpPrincipal.Controls.Add(this.lvwBoules, 2, 0);
            this.tlpPrincipal.Controls.Add(this.labelCompteurBoules, 1, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 5;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(741, 292);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // comboCategorieParfum
            // 
            this.comboCategorieParfum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCategorieParfum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategorieParfum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategorieParfum.FormattingEnabled = true;
            this.comboCategorieParfum.Location = new System.Drawing.Point(3, 3);
            this.comboCategorieParfum.Name = "comboCategorieParfum";
            this.comboCategorieParfum.Size = new System.Drawing.Size(333, 26);
            this.comboCategorieParfum.TabIndex = 0;
            // 
            // listParfum
            // 
            this.listParfum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listParfum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listParfum.FormattingEnabled = true;
            this.listParfum.ItemHeight = 18;
            this.listParfum.Location = new System.Drawing.Point(3, 30);
            this.listParfum.Name = "listParfum";
            this.tlpPrincipal.SetRowSpan(this.listParfum, 4);
            this.listParfum.Size = new System.Drawing.Size(333, 259);
            this.listParfum.TabIndex = 1;
            // 
            // buttonAjouterBoule
            // 
            this.buttonAjouterBoule.AutoSize = true;
            this.buttonAjouterBoule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAjouterBoule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAjouterBoule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterBoule.Location = new System.Drawing.Point(342, 110);
            this.buttonAjouterBoule.Margin = new System.Windows.Forms.Padding(3, 3, 3, 21);
            this.buttonAjouterBoule.Name = "buttonAjouterBoule";
            this.buttonAjouterBoule.Size = new System.Drawing.Size(57, 28);
            this.buttonAjouterBoule.TabIndex = 2;
            this.buttonAjouterBoule.Text = "+1 >>";
            this.buttonAjouterBoule.UseVisualStyleBackColor = true;
            // 
            // buttonRetirerBoule
            // 
            this.buttonRetirerBoule.AutoSize = true;
            this.buttonRetirerBoule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRetirerBoule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRetirerBoule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRetirerBoule.Location = new System.Drawing.Point(342, 180);
            this.buttonRetirerBoule.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.buttonRetirerBoule.Name = "buttonRetirerBoule";
            this.buttonRetirerBoule.Size = new System.Drawing.Size(57, 28);
            this.buttonRetirerBoule.TabIndex = 4;
            this.buttonRetirerBoule.Text = "<< -1";
            this.buttonRetirerBoule.UseVisualStyleBackColor = true;
            // 
            // lvwBoules
            // 
            this.lvwBoules.AutoArrange = false;
            this.lvwBoules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnQuantite,
            this.columnParfum,
            this.columnCategorie});
            this.lvwBoules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBoules.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBoules.FullRowSelect = true;
            this.lvwBoules.GridLines = true;
            this.lvwBoules.HideSelection = false;
            this.lvwBoules.Location = new System.Drawing.Point(405, 3);
            this.lvwBoules.MultiSelect = false;
            this.lvwBoules.Name = "lvwBoules";
            this.tlpPrincipal.SetRowSpan(this.lvwBoules, 5);
            this.lvwBoules.Size = new System.Drawing.Size(333, 286);
            this.lvwBoules.TabIndex = 3;
            this.lvwBoules.UseCompatibleStateImageBehavior = false;
            this.lvwBoules.View = System.Windows.Forms.View.Details;
            // 
            // columnQuantite
            // 
            this.columnQuantite.Text = "Qt.";
            // 
            // columnParfum
            // 
            this.columnParfum.Text = "Parfum";
            // 
            // columnCategorie
            // 
            this.columnCategorie.Text = "Catégorie du parfum";
            // 
            // labelCompteurBoules
            // 
            this.labelCompteurBoules.AutoSize = true;
            this.labelCompteurBoules.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCompteurBoules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCompteurBoules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompteurBoules.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompteurBoules.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCompteurBoules.Location = new System.Drawing.Point(342, 3);
            this.labelCompteurBoules.Margin = new System.Windows.Forms.Padding(3);
            this.labelCompteurBoules.Name = "labelCompteurBoules";
            this.labelCompteurBoules.Size = new System.Drawing.Size(57, 21);
            this.labelCompteurBoules.TabIndex = 5;
            this.labelCompteurBoules.Text = "9 / 9";
            this.labelCompteurBoules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectionBoules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "SelectionBoules";
            this.Size = new System.Drawing.Size(741, 292);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.ComboBox comboCategorieParfum;
        private System.Windows.Forms.ListBox listParfum;
        private System.Windows.Forms.Button buttonAjouterBoule;
        private System.Windows.Forms.Button buttonRetirerBoule;
        private System.Windows.Forms.ListView lvwBoules;
        private System.Windows.Forms.ColumnHeader columnQuantite;
        private System.Windows.Forms.ColumnHeader columnParfum;
        private System.Windows.Forms.ColumnHeader columnCategorie;
        private System.Windows.Forms.Label labelCompteurBoules;
    }
}
