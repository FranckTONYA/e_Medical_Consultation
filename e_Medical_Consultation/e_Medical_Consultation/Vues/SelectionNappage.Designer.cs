namespace Glacier
{
    partial class SelectionNappage
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
            this.groupNappage.Name = "groupNappage";
            this.groupNappage.Size = new System.Drawing.Size(240, 80);
            this.groupNappage.TabIndex = 0;
            // 
            // SelectionNappage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupNappage);
            this.MinimumSize = new System.Drawing.Size(240, 68);
            this.Name = "SelectionNappage";
            this.Size = new System.Drawing.Size(240, 80);
            this.ResumeLayout(false);

        }

        #endregion

        private PDSGBD.UI.RadioGroup groupNappage;
    }
}
