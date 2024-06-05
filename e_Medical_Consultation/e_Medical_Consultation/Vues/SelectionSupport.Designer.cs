namespace Glacier
{
    partial class SelectionSupport
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
            this.labelType = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.labelTaille = new System.Windows.Forms.Label();
            this.comboTaille = new System.Windows.Forms.ComboBox();
            this.tlpPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPrincipal.Controls.Add(this.labelType, 0, 1);
            this.tlpPrincipal.Controls.Add(this.comboType, 1, 1);
            this.tlpPrincipal.Controls.Add(this.labelTaille, 0, 2);
            this.tlpPrincipal.Controls.Add(this.comboTaille, 1, 2);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 4;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.Size = new System.Drawing.Size(240, 80);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.Location = new System.Drawing.Point(3, 11);
            this.labelType.Margin = new System.Windows.Forms.Padding(3);
            this.labelType.Name = "labelType";
            this.labelType.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelType.Size = new System.Drawing.Size(50, 26);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "&Type :";
            // 
            // comboType
            // 
            this.comboType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboType.FormattingEnabled = true;
            this.comboType.Location = new System.Drawing.Point(59, 11);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(158, 26);
            this.comboType.TabIndex = 1;
            // 
            // labelTaille
            // 
            this.labelTaille.AutoSize = true;
            this.labelTaille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTaille.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaille.Location = new System.Drawing.Point(3, 43);
            this.labelTaille.Margin = new System.Windows.Forms.Padding(3);
            this.labelTaille.Name = "labelTaille";
            this.labelTaille.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelTaille.Size = new System.Drawing.Size(50, 26);
            this.labelTaille.TabIndex = 2;
            this.labelTaille.Text = "T&aille :";
            // 
            // comboTaille
            // 
            this.comboTaille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboTaille.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTaille.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTaille.FormattingEnabled = true;
            this.comboTaille.Location = new System.Drawing.Point(59, 43);
            this.comboTaille.Name = "comboTaille";
            this.comboTaille.Size = new System.Drawing.Size(158, 26);
            this.comboTaille.TabIndex = 3;
            // 
            // SelectionSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(240, 68);
            this.Name = "SelectionSupport";
            this.Size = new System.Drawing.Size(240, 80);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label labelTaille;
        private System.Windows.Forms.ComboBox comboTaille;
    }
}
