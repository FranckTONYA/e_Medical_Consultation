namespace Glacier
{
    partial class Recapitulatif
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
            this.buttonCommander = new System.Windows.Forms.Button();
            this.tvwConfection = new System.Windows.Forms.TreeView();
            this.tooltipInfoBulle = new System.Windows.Forms.ToolTip(this.components);
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.Controls.Add(this.buttonCommander, 1, 1);
            this.tlpPrincipal.Controls.Add(this.tvwConfection, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.Size = new System.Drawing.Size(240, 255);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // buttonCommander
            // 
            this.buttonCommander.AutoSize = true;
            this.buttonCommander.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCommander.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCommander.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCommander.Location = new System.Drawing.Point(40, 218);
            this.buttonCommander.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.buttonCommander.Name = "buttonCommander";
            this.buttonCommander.Size = new System.Drawing.Size(159, 28);
            this.buttonCommander.TabIndex = 1;
            this.buttonCommander.Text = "Passer commande";
            this.tooltipInfoBulle.SetToolTip(this.buttonCommander, "Passer commande de la crème glacée correspondant à cette confection");
            this.buttonCommander.UseVisualStyleBackColor = true;
            // 
            // tvwConfection
            // 
            this.tvwConfection.BackColor = System.Drawing.SystemColors.Control;
            this.tlpPrincipal.SetColumnSpan(this.tvwConfection, 3);
            this.tvwConfection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwConfection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvwConfection.FullRowSelect = true;
            this.tvwConfection.Location = new System.Drawing.Point(3, 3);
            this.tvwConfection.Name = "tvwConfection";
            this.tvwConfection.Size = new System.Drawing.Size(234, 203);
            this.tvwConfection.TabIndex = 0;
            this.tooltipInfoBulle.SetToolTip(this.tvwConfection, "Récapitulatif de cette confection de crème glacée");
            // 
            // Recapitulatif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(240, 68);
            this.Name = "Recapitulatif";
            this.Size = new System.Drawing.Size(240, 255);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TreeView tvwConfection;
        private System.Windows.Forms.Button buttonCommander;
        private System.Windows.Forms.ToolTip tooltipInfoBulle;
    }
}
