using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;
using PDSGBD.MySql;
using static ConsultationMedicale.Modeles;

namespace ConsultationMedicale
{
    /*
    Exemples de requêtes GET :
	    http://localhost/api_glacier/?action=enumerer&sujet=support
		    OK
		    BP	Baquet en plastique	O	O
		    CO	Cornet	N	O
		    GA	Gaufrette	N	N
		    PB	Panier en biscuit	O	O
	    http://localhost/api_glacier/?action=enumerer&sujet=support&type=CO
		    OK
		    BA	Baby	1
		    NO	Normal	3
		    GR	Grand	4
		    DO	Double	4
		    TR	Triple	7
	    http://localhost/api_glacier/?action=enumerer&sujet=parfum
		    OK
		    CL	Classique
		    AM	Avec morceau
		    AF	Au fruit
		    EX	Exotique
		    SP	Spécial
	    http://localhost/api_glacier/?action=enumerer&sujet=parfum&categorie=AM
		    OK
		    PR	Praliné
		    NO	Nougat
		    EO	Eclats d'orange confite
		    PI	Pistache
	    http://localhost/api_glacier/?action=enumerer&sujet=nappage
		    OK
		    CA	Caramel
		    GM	Grand-marnier
		    CF	Coulis de fraise
		    VO	Vodka
		    RH	Rhum
	    http://localhost/api_glacier/?action=enumerer&sujet=saupoudrage
		    OK
		    BR	Brésilienne
		    PC	Pépittes de chocolat
	    http://localhost/api_glacier/?action=commander&type=CO&taille=GR&boules[]=CL_CN&boules[]=CL_VA&boules[]=AM_PI&boules[]=EX_PA&saupoudrage=BR&creme_fraiche
		    OK
	    http://localhost/api_glacier/?action=commander&type=BP&taille=PE&boules[]=CL_CN&boules[]=CL_VA&boules[]=AF_FM&saupoudrage=BR&nappage=GM
		    OK
	    http://localhost/api_glacier/?action=enumerer&sujet=commande
		    OK
		    2024-03-27 20:27:38	CO	GR	X	V	BR	CL	CN	CL	VA	AM	PI	EX	PA
		    2024-03-27 20:29:45	BP	PE	GM	X	BR	CL	CN	CL	VA	AF	FM
    */

    /// <summary>
    /// Définit l'API de l'application e-Medical Consultation (côté client)
    /// </summary>
    public class ApiConsultationMedicale
    {
        /// <summary>
        /// Indique si la dernière tentative d'interrogation réalisée a produit une erreur, ou non
        /// </summary>
        public bool ErreurRencontree => !string.IsNullOrEmpty(MessageErreur);

        /// <summary>
        /// Message d'erreur en relation avec la dernière tentative d'interrogation réalisée, sinon null
        /// </summary>
        public string MessageErreur { get; private set; }

        /// <summary>
        /// Connexion "principale" au serveur MySql
        /// </summary>
        private DB m_DB;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbSettings">Paramètres de connexion au serveur MySql</param>
        public ApiConsultationMedicale(DB.Settings dbSettings)
        {
            m_DB = new DB(dbSettings);
            MessageErreur = null;
        }

        /// <summary>
        /// Tente de récupérer les Utilisateurs
        /// </summary>
        /// <returns>Énumération des Utilisateurs de l'application</returns>
        public IEnumerable<Modeles.IUtilisateur> EnumererUtilisateurs()
        {
            ReinitialiserErreur();

            Modeles.IUtilisateur utilisateur = null;
            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        utilisateur.id AS utilisateur_id,
                        utilisateur.email AS utilisateur_email,
                        utilisateur.password AS utilisateur_motDePasse,
                        utilisateur.token AS utilisateur_token,
                        utilisateur.nom AS utilisateur_nom,
                        utilisateur.prenom AS utilisateur_prenom,
                        utilisateur.telephone AS utilisateur_telephone,
                        utilisateur.date_naissance AS utilisateur_dateNaissance,
                        utilisateur.adresse AS utilisateur_adresse,
                        role_utilisateur.id AS role_id,
                        role_utilisateur.nom AS role_nom,                        
                        role_utilisateur.description AS role_description
                    FROM
                        utilisateur LEFT JOIN role_utilisateur ON utilisateur.ref_role = role_utilisateur.id
                    ORDER BY
                        utilisateur.nom ASC,
                        role_utilisateur.nom ASC"))
            {
                var idUtilisateur = enreg.GetValue<int>("utilisateur_id");
                if ((utilisateur == null) || !idUtilisateur.Equals(utilisateur.Id))
                {
                    if (utilisateur != null) yield return utilisateur;
                    utilisateur = Modeles.CreerUtilisateur(idUtilisateur, enreg.GetValue<string>("utilisateur_email"), enreg.GetValue<string>("utilisateur_motDePasse"), enreg.GetValue<string>("utilisateur_token"), enreg.GetValue<string>("utilisateur_nom"), enreg.GetValue<string>("utilisateur_prenom"), enreg.GetValue<string>("utilisateur_telephone"), enreg.GetValue<DateTime>("utilisateur_dateNaissance"), enreg.GetValue<string>("utilisateur_adresse"));
                    if (!PasNullSinonErreur(utilisateur)) yield break;
                }
                utilisateur.DefinirRole(Modeles.CreerRoleUtilisateur(enreg.GetValue<int>("role_id"), enreg.GetValue<string>("role_nom"), enreg.GetValue<string>("role_description")));
            }
            if (utilisateur != null) yield return utilisateur;
        }


        /// <summary>
        /// Tente de récupérer les Rôles Utilisateurs
        /// </summary>
        /// <returns>Énumération des Rôles Utilisateurs de l'application</returns>
        public IEnumerable<Modeles.IRoleUtilisateur> EnumererRoles()
        {
            ReinitialiserErreur();

            Modeles.IRoleUtilisateur role = null;
            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        role_utilisateur.id AS role_id,
                        role_utilisateur.nom AS role_nom,
                        role_utilisateur.description AS role_description
                    FROM
                        role_utilisateur
                    ORDER BY
                        role_utilisateur.nom ASC"))
            {
                var idRole = enreg.GetValue<int>("role_id");
                if ((role == null) || !idRole.Equals(role.Id))
                {
                    if (role != null) yield return role;
                    role = Modeles.CreerRoleUtilisateur(idRole, enreg.GetValue<string>("role_nom"), enreg.GetValue<string>("role_description"));
                    if (!PasNullSinonErreur(role)) yield break;
                }
            }
            if (role != null) yield return role;
        }

        /// <summary>
        /// Tente de récupérer un Utilisateur par son email
        /// </summary>
        /// <param name="email">email de l'utilisateur</param>
        /// <returns>Utilisateur retrouvé ou pas</returns>
        public IEnumerable<IUtilisateur> EnumererUtilisateurParEmail(string email)
        {
            ReinitialiserErreur();
            Modeles.IUtilisateur utilisateur = null;
            if (email == null)
            {
                MessageErreur = $"email défini lors de la tentative d'énumération de l'utilisateur !";
                yield return null;
            }

            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        utilisateur.id AS utilisateur_id,
                        utilisateur.email AS utilisateur_email,
                        utilisateur.password AS utilisateur_motDePasse,
                        utilisateur.token AS utilisateur_token,
                        utilisateur.nom AS utilisateur_nom,
                        utilisateur.prenom AS utilisateur_prenom,
                        utilisateur.telephone AS utilisateur_telephone,
                        utilisateur.date_naissance AS utilisateur_dateNaissance,
                        utilisateur.adresse AS utilisateur_adresse,
                        role_utilisateur.id AS role_id,
                        role_utilisateur.nom AS role_nom,                        
                        role_utilisateur.description AS role_description
                    FROM
                        utilisateur LEFT JOIN role_utilisateur ON utilisateur.ref_role = role_utilisateur.id
                     WHERE 
                        utilisateur.email = {0}
                    ORDER BY
                        utilisateur.nom ASC,
                        role_utilisateur.nom ASC", email))
            {
                var idUtilisateur = enreg.GetValue<int>("utilisateur_id");
                if ((utilisateur == null) || !idUtilisateur.Equals(utilisateur.Id))
                {
                    if (utilisateur != null) yield return utilisateur;
                    utilisateur = Modeles.CreerUtilisateur(idUtilisateur, enreg.GetValue<string>("utilisateur_email"), enreg.GetValue<string>("utilisateur_motDePasse"), enreg.GetValue<string>("utilisateur_token"), enreg.GetValue<string>("utilisateur_nom"), enreg.GetValue<string>("utilisateur_prenom"), enreg.GetValue<string>("utilisateur_telephone"), enreg.GetValue<DateTime>("utilisateur_dateNaissance"), enreg.GetValue<string>("utilisateur_adresse"));
                    if (!PasNullSinonErreur(utilisateur)) yield break;
                }
                int idRole = enreg.GetValue<int>("role_id");
                if(idRole != 0)
                    utilisateur.DefinirRole(Modeles.CreerRoleUtilisateur(idRole, enreg.GetValue<string>("role_nom"), enreg.GetValue<string>("role_description")));
            }
            if (utilisateur != null) yield return utilisateur;
            
        }

        public bool SauvegarderUtilisateur( IUtilisateur utilisateur, bool nouveau)
        {
            if (nouveau)
            {
                int  id = (int)m_DB.Execute(@"INSERT INTO utilisateur
                                            SET email = {0}, password = {1}, token = {2}, nom = {3}, prenom = {4}, 
                                            telephone = {5}, date_naissance = {6}, adresse = {7}, ref_role = {8}, ref_hopital = {9}", 
                                            utilisateur.Email, utilisateur.MotDePasse, utilisateur.Token, utilisateur.Nom, utilisateur.Prenom, utilisateur.Telephone,
                                            utilisateur.DateNaissance, utilisateur.Adresse, utilisateur.Role.Id, 1).LastInsertedId;
                if (id == 0) return false;

                // Si l'Utilisateur sauvegardé est un patient, créer automatiquement son Dossier Patient associé
                if (utilisateur.Role.Nom.Equals(ConsultationMedicale.Privilege.Patient.ToString()))
                {
                    int idDossier = (int)m_DB.Execute(@"INSERT INTO dossier_patient
                                            SET ref_utilisateur = {0}",
                                            id).LastInsertedId;
                    if (idDossier == 0) return false;
                }
                
                return true;
            }
            else
            {
                return m_DB.Execute(@"UPDATE utilisateur 
                                        SET 
                                            email = {1}, password = {2}, token = {3}, nom = {4}, prenom = {5}, 
                                            telephone = {6}, date_naissance = {7}, adresse = {8}, ref_role = {9}
                                        WHERE id = {0}", 
                                        utilisateur.Id, utilisateur.Email, utilisateur.MotDePasse, utilisateur.Token, utilisateur.Nom, utilisateur.Prenom, utilisateur.Telephone,
                                        utilisateur.DateNaissance, utilisateur.Adresse, utilisateur.Role.Id).Success;
            }
        }

        public bool SupprimerUtilisateur(IUtilisateur utilisateur)
        {
            return m_DB.Execute("DELETE FROM utilisateur WHERE id = {0}", utilisateur.Id).Success;
        }

        /// <summary>
        /// Tente de récupérer les Dossiers patients
        /// </summary>
        /// <returns>Énumération des Dossiers Patients de l'application</returns>
        public IEnumerable<Modeles.IDossierPatient> EnumererDossiersPatients()
        {
            ReinitialiserErreur();

            Modeles.IDossierPatient dossierPatient = null;
            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        dossier_patient.id AS dossier_id,
                        dossier_patient.description AS dossier_description,
                        utilisateur.id AS patient_id,
                        utilisateur.email AS patient_email,
                        utilisateur.password AS patient_motDePasse,
                        utilisateur.token AS patient_token,
                        utilisateur.nom AS patient_nom,
                        utilisateur.prenom AS patient_prenom,
                        utilisateur.telephone AS patient_telephone,
                        utilisateur.date_naissance AS patient_dateNaissance,
                        utilisateur.adresse AS patient_adresse,
                        consultation.id AS consultation_id,
                        consultation.motif AS consultation_motif,
                        consultation.rapport AS consultation_rapport,
                        consultation.prescription AS consultation_prescription
                    FROM
                        dossier_patient 
                            LEFT JOIN utilisateur ON dossier_patient.ref_utilisateur = utilisateur.id                            
                            LEFT JOIN consultation ON consultation.ref_dossier = dossier_patient.id
                    ORDER BY
                        utilisateur.nom ASC"))
            {
                var idDossier = enreg.GetValue<int>("dossier_id");
                if ((dossierPatient == null) || !idDossier.Equals(dossierPatient.Id))
                {
                    if (dossierPatient != null) yield return dossierPatient;
                    dossierPatient = Modeles.CreerDossierPatient(idDossier, enreg.GetValue<string>("dossier_description"), enreg.GetValue<string>("patient_nom"));
                    if (!PasNullSinonErreur(dossierPatient)) yield break;
                }
                int idPatient = enreg.GetValue<int>("patient_id");
                if(idPatient != 0)
                    dossierPatient.DefinirPatient(Modeles.CreerUtilisateur(idPatient, enreg.GetValue<string>("patient_email"), enreg.GetValue<string>("patient_motDePasse"), enreg.GetValue<string>("patient_token"), enreg.GetValue<string>("patient_nom"), enreg.GetValue<string>("patient_prenom"), enreg.GetValue<string>("patient_telephone"), enreg.GetValue<DateTime>("patient_dateNaissance"), enreg.GetValue<string>("patient_adresse")));

                int idConsultation = enreg.GetValue<int>("consultation_id");
                if (idConsultation != 0)
                    dossierPatient.AjouterConsultation(Modeles.CreerConsultation(idConsultation, enreg.GetValue<string>("consultation_motif"), enreg.GetValue<string>("consultation_rapport"), enreg.GetValue<string>("consultation_prescription")));
            }
            if (dossierPatient != null) yield return dossierPatient;
        }


        public bool SauvegarderDossier(IDossierPatient dossier)
        {
            return m_DB.Execute(@"UPDATE dossier_patient 
                                        SET description = {1}
                                        WHERE id = {0}",
                                        dossier.Id, dossier.Description).Success;
        }


        /// <summary>
        /// Tente de récupérer toutes les Consultations
        /// </summary>
        /// <returns>Énumération des Consultations de l'application</returns>
        public IEnumerable<Modeles.IConsultation> EnumererConsultations()
        {
            ReinitialiserErreur();

            Modeles.IConsultation consultation = null;
            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        consultation.id AS consultation_id,
                        consultation.motif AS consultation_motif,
                        consultation.rapport AS consultation_rapport,
                        consultation.prescription AS consultation_prescription,
                        dossier_patient.id AS dossier_id,
                        dossier_patient.description AS dossier_description,
                        utilisateur.id AS medecin_id,
                        utilisateur.email AS medecin_email,
                        utilisateur.password AS medecin_motDePasse,
                        utilisateur.token AS medecin_token,
                        utilisateur.nom AS medecin_nom,
                        utilisateur.prenom AS medecin_prenom,
                        utilisateur.telephone AS medecin_telephone,
                        utilisateur.date_naissance AS medecin_dateNaissance,
                        utilisateur.adresse AS medecin_adresse
                    FROM
                        consultation 
                            LEFT JOIN utilisateur ON consultation.ref_medecin = utilisateur.id                            
                            LEFT JOIN dossier_patient ON consultation.ref_dossier = dossier_patient.id
                    ORDER BY
                        utilisateur.nom ASC"))
            {
                var idConsultation = enreg.GetValue<int>("consultation_id");
                if ((consultation == null) || !idConsultation.Equals(consultation.Id))
                {
                    if (consultation != null) yield return consultation;
                    consultation = Modeles.CreerConsultation(idConsultation, enreg.GetValue<string>("consultation_motif"), enreg.GetValue<string>("consultation_rapport"), enreg.GetValue<string>("consultation_prescription"));
                    if (!PasNullSinonErreur(consultation)) yield break;
                }
                consultation.DefinirMedecinExecutant(Modeles.CreerUtilisateur(enreg.GetValue<int>("medecin_id"), enreg.GetValue<string>("medecin_email"), enreg.GetValue<string>("medecin_motDePasse"), enreg.GetValue<string>("medecin_token"), enreg.GetValue<string>("medecin_nom"), enreg.GetValue<string>("medecin_prenom"), enreg.GetValue<string>("medecin_telephone"), enreg.GetValue<DateTime>("medecin_dateNaissance"), enreg.GetValue<string>("medecin_adresse")));
                consultation.DefinirDossierPatient(Modeles.CreerDossierPatient(enreg.GetValue<int>("dossier_id"), enreg.GetValue<string>("dossier_description")));
            }
            if (consultation != null) yield return consultation;
        }


        /// <summary>
        /// Tente de récupérer tous les Rendez-vous
        /// </summary>
        /// <returns>Énumération des Rendez-vous de l'application</returns>
        public IEnumerable<Modeles.IRendezVous> EnumererLesRendezVous()
        {
            ReinitialiserErreur();

            Modeles.IRendezVous rendezVous = null;
            foreach (var enreg in m_DB.GetRows(@"
                    SELECT
                        rendez_vous.id AS rdv_id,
                        rendez_vous.description AS rdv_description,
                        rendez_vous.date AS rdv_date,
                        rendez_vous.duree AS rdv_duree
                        consultation.id AS consultation_id,
                        consultation.prescription AS consultation_prescription,
                        consultation.rapport AS consultation_rapport,
                        statut_rendezvous.id AS statut_id,
                        statut_rendezvous.nom AS statut_nom,
                        statut_rendezvous.description AS statut_description
                    FROM
                        rendez_vous 
                            LEFT JOIN consultation ON rendez_vous.ref_consultation = consultation.id                            
                            LEFT JOIN statut ON rendez_vous.ref_statut = statut_rendezvous.id
                    "))
            {
                var idRdv = enreg.GetValue<int>("rdv_id");
                if ((rendezVous == null) || !idRdv.Equals(rendezVous.Id))
                {
                    if (rendezVous != null) yield return rendezVous;
                    rendezVous = Modeles.CreerRendezVous(idRdv, enreg.GetValue<string>("rdv_description"), enreg.GetValue<DateTime >("rdv_date"), enreg.GetValue<int>("rdv_duree"));
                    if (!PasNullSinonErreur(rendezVous)) yield break;
                }
                rendezVous.DefinirConsultation(Modeles.CreerConsultation(enreg.GetValue<int>("consultation_id"), enreg.GetValue<string>("consultation_motif"), enreg.GetValue<string>("consultation_rapport"), enreg.GetValue<string>("consultation_prescription")));
                rendezVous.DefinirStatut(Modeles.CreerStatutRendezVous(enreg.GetValue<int>("statut_id"), enreg.GetValue<string>("statut_nom"), enreg.GetValue<string>("statut_description")));
            }
            if (rendezVous != null) yield return rendezVous;
        }

        private void ReinitialiserErreur()
        {
            MessageErreur = null;
        }

        private bool PasNullSinonErreur<T>(T entite, string messageErreur = "Création de l'entité impossible !")
            where T : class
        {
            if (entite != null) return true;
            MessageErreur = messageErreur;
            return false;
        }
    }
}
