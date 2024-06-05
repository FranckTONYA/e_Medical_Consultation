namespace Glacier
{
    partial class Principal
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de id.
        /// </summary>
        private void InitializeComponent()
        {
            this.confection = new Glacier.Confection();
            this.SuspendLayout();
            // 
            // confection
            // 
            this.confection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confection.Location = new System.Drawing.Point(0, 0);
            this.confection.MinimumSize = new System.Drawing.Size(720, 320);
            this.confection.Name = "confection";
            this.confection.Size = new System.Drawing.Size(774, 351);
            this.confection.TabIndex = 0;
            this.confection.Titre = "Confection d\'une crème glacée";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 351);
            this.Controls.Add(this.confection);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 360);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Le Glacier - Confection d\'une crème glacée selon vos préférences";
            this.ResumeLayout(false);

        }

        #endregion

        private Confection confection;
    }
}

