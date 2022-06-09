using IACryptOfTheCSharpDancer.metier.carte;
using System.Collections.Generic;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Module en charge de gérer les réactions de l'IA à une réponse du serveur</summary>
    public class ModuleReaction : Module
    {
        public Joueur Joueur => IA.Joueur;
        public List<string> MoveMessages => IA.MoveMessages;
        public Carte Carte => IA.Carte;
        public ModuleCommunication ModuleCommunication => IA.ModuleCommunication;


        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleReaction(IA ia) : base(ia){}

        /// <summary>Méthode réagissant à la réponse du serveur</summary>
        /// <param name="messageEnvoye">Dernier message envoyé au serveur par l'IA</param>
        /// <param name="messageRecu">Réponse du serveur à ce message</param>
        public void ReagirAuMessageRecu(string messageEnvoye, string messageRecu)
        {
            if (messageEnvoye == "MAP")
                IA.ModuleMemoire.GenererCarte(messageRecu);
            else if (messageEnvoye.StartsWith("MOVE"))
            {
                switch (messageEnvoye)
                {
                    case "MOVE LEFT": ReactionMouvement(TypeMouvement.GAUCHE); break;
                    case "MOVE RIGHT": ReactionMouvement(TypeMouvement.DROITE); break;
                    case "MOVE UP": ReactionMouvement(TypeMouvement.HAUT); break;
                    case "MOVE DOWN": ReactionMouvement(TypeMouvement.BAS); break;
                }
            }
            else if (messageRecu == "END")
                ModuleCommunication.FermerConnexion();
        }

        private void ReactionMouvement(TypeMouvement mouvement)
        {
            Coordonnees destination = this.IA.ModuleMemoire.Joueur.Coordonnees.GetVoisin(mouvement);
            if (this.IA.ModuleMemoire.Carte.GetCaseAt(destination).MoveCost > 1)
                CreuserMur(destination);
            else
                GenericMovement(mouvement);
        }

        private void GenericMovement(TypeMouvement mouvement)
        {
            this.IA.ModuleMemoire.Joueur.Deplacer(mouvement);
            this.IA.ModuleMemoire.Carte.RamasserDiamant(this.IA.ModuleMemoire.Joueur.Coordonnees);
        }

        private void CreuserMur(Coordonnees destination)
        {
            this.IA.ModuleMemoire.Carte.GetCaseAt(destination).Creuser();
        }

        private void RamasserDiamant(Coordonnees coordonnees)
        {
            Carte.RamasserDiamant(coordonnees);
        }
    }
}
