using IACryptOfTheCSharpDancer.metier.carte;
using System.Collections.Generic;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Module en charge de gérer les réactions de l'IA à une réponse du serveur</summary>
    public class ModuleReaction : Module
    {
        public Joueur Joueur => IA.Joueur;
        public List<string> MoveMessages => IA.MoveMessages;

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
        }

        private void ReactionMouvement(TypeMouvement mouvement)
        {
            Joueur.Deplacer(mouvement);
        }
    }
}
