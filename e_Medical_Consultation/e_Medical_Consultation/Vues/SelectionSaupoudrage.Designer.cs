namespace Glacier
{
    partial class SelectionSaupoudrage
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
            this.groupSaupoudrage = new PDSGBD.UI.RadioGroup();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.checkCremeFraiche = new System.Windows.Forms.CheckBox();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSaupoudrage
            // 
            this.groupSaupoudrage.BackColor = System.Drawing.SystemColors.Control;
            this.groupSaupoudrage.CheckedIndex = -1;
            this.groupSaupoudrage.CheckedItem = null;
            this.groupSaupoudrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSaupoudrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSaupoudrage.Location = new System.Drawing.Point(3, 31);
            this.groupSaupoudrage.Name = "groupSaupoudrage";
            this.groupSaupoudrage.Size = new System.Drawing.Size(234, 46);
            this.groupSaupoudrage.TabIndex = 1;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.groupSaupoudrage, 0, 1);
            this.tlpPrincipal.Controls.Add(this.checkCremeFraiche, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(240, 80);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // checkCremeFraiche
            // 
            this.checkCremeFraiche.AutoSize = true;
            this.checkCremeFraiche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkCremeFraiche.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCremeFraiche.Location = new System.Drawing.Point(3, 3);
            this.checkCremeFraiche.Name = "checkCremeFraiche";
            this.checkCremeFraiche.Size = new System.Drawing.Size(234, 22);
            this.checkCremeFraiche.TabIndex = 0;
            this.checkCremeFraiche.Text = "Crème fraîche";
            this.checkCremeFraiche.UseVisualStyleBackColor = true;
            // 
            // SelectionSaupoudrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(240, 68);
            this.Name = "SelectionSaupoudrage";
            this.Size = new System.Drawing.Size(240, 80);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PDSGBD.UI.RadioGroup groupSaupoudrage;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.CheckBox checkCremeFraiche;
    }
}
