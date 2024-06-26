﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultationMedicale
{
    /// <summary>
    /// Contrôle permettant de gérer le tableau de bord des utilisateurs
    /// </summary>
    public partial class Dashboard : UserControl
    {
        /// <summary>
        /// Api de l'application
        /// </summary>
        public ApiConsultationMedicale Api { get; private set; }

        Consultations formulaireConsultation;
        RendezVous formulaireRdv;
        DossiersPatients formulaireDossier;
        Utilisateurs formulaireUtilisateur;

        /// <summary>
        /// Permet de définir "tardivement" la référence de l'Api des données actives de l'application
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        /// <returns>Vrai si cette initialisation "tardive" a pu se faire, sinon faux</returns>
        public bool DefinirApi(ApiConsultationMedicale api)
        {
            if ((Api != null) || (api == null)) return false;
            Api = api;
            return true;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="api">Référence de l'API donnant accès aux données actives de l'application</param>
        public Dashboard(ApiConsultationMedicale api = null)
        {
            InitializeComponent();
            Api = api;
            Load += new EventHandler(Dashboard_Load);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            AfficherTitre();
        }

        private void AfficherTitre()
        {
            if(ConsultationMedicale.Utilisateur != null)
            {
                titreLabel.Text = $"Accueil - {ConsultationMedicale.Utilisateur.Role.Nom} " +
                $"( {ConsultationMedicale.Utilisateur.Nom} )";
            }
            
        }
      
        private void AfficherConsultations(object sender, EventArgs e)
        {
            formulaireConsultation = new Consultations(Api);
            ConsultationMedicale.AfficherFormDansPanelParent(dashboardPanel, formulaireConsultation);
        }

        private void AfficherLesRendezVous(object sender, EventArgs e)
        {
            formulaireRdv = new RendezVous(Api);
            ConsultationMedicale.AfficherFormDansPanelParent(dashboardPanel, formulaireRdv);
        }

        private void AfficherDossiersPatients(object sender, EventArgs e)
        {
            formulaireDossier = new DossiersPatients(Api);
            ConsultationMedicale.AfficherFormDansPanelParent(dashboardPanel, formulaireDossier);
        }

        private void AfficherUtilisateurs(object sender, EventArgs e)
        {
            formulaireUtilisateur = new Utilisateurs(Api);
            ConsultationMedicale.AfficherFormDansPanelParent(dashboardPanel, formulaireUtilisateur);
        }

        private void Deconnexion(object sender, EventArgs e)
        {
            ConsultationMedicale.AfficherAccueil(this);
        }
    }
}
