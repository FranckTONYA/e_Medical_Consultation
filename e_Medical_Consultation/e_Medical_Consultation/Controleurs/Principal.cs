using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    public partial class Principal : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès au "support" des données actives de l'application</param>
        public Principal(ApiConsultationMedicale api)
        {
            InitializeComponent();
            this.Width = Math.Min(Screen.AllScreens.Min(s => s.WorkingArea.Width) * 2 / 3, this.Width * 3 / 2);
            this.Height = Math.Min(Screen.AllScreens.Max(s => s.WorkingArea.Height) * 2 / 3, this.Height * 3 / 2);
            /*confection.DefinirApi(api);*/
        }

        private void ConnexionAdmin(object sender, EventArgs e)
        {

        }

        private void ConnexionMedecin(object sender, EventArgs e)
        {

        }

        private void ConnexionPatient(object sender, EventArgs e)
        {

        }
    }
}
