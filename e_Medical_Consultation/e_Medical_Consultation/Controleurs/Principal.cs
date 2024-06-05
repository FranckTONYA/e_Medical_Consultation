﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glacier
{
    /// <summary>
    /// Formulaire principal
    /// <para>Servant également ici de conteneur au id de contrôleur dans une architecture logicielle de type MVC</para>
    /// </summary>
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
            confection.DefinirApi(api);
        }
    }
}
