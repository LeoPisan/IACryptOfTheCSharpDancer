using IACryptOfTheCSharpDancer.metier.algorithme;
using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Ce module est en charge de prendre les décisions pour l'IA (que doit je faire ?)</summary>
    public class ModulePriseDeDecisions : Module
    {
        private Random random = new Random();
        private List<string> moveMessages = new List<string>() { "MOVE LEFT", "MOVE RIGHT", "MOVE DOWN", "MOVE UP" };
        private List<TypeMouvement> mouvements;

        public Carte Carte => IA.Carte;

        /// <summary>
        /// liste des messages de déplacement
        /// </summary>
        public List<string> MoveMessages { get => moveMessages; }

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">Ia dont dépend le module</param>
        public ModulePriseDeDecisions(IA ia) : base(ia)
        {
            mouvements = new List<TypeMouvement>();
        }

        /// <summary>Méthode déterminant la prochaine action à réaliser</summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public string DeterminerNouvelleAction(string messageRecuDuServeur)
        {
            string reponse = "END";
            if (!this.IA.ModuleMemoire.HasCarte()) 
                reponse = "MAP";
            else
            {
                reponse = GenerateNewMessage(reponse);
            }
            if (reponse == "END")
            {
                this.IA.ArreterLaCommunication();
            }
            return reponse;
        }

        private string GenerateNewMessage(string reponse)
        {
            if (this.IA.ModuleMemoire.Diamants.Count > 0 && this.mouvements.Count == 0)
            {
                AlgorithmeCalculDistance parcours = new ParcoursLargeur(this.IA.ModuleMemoire.Carte);
                Case depart = Carte.GetCaseAt(IA.ModuleMemoire.Joueur.Coordonnees);
                parcours.CalculerDistancesDepuis(depart);
                this.mouvements = parcours.GetChemin(this.IA.ModuleMemoire.Diamants[0].Position);
            }

            if (this.mouvements.Count > 0)
            {
                reponse = MovementToString(reponse);
                this.mouvements.RemoveAt(0);
            }

            return reponse;
        }

        private string MovementToString(string reponse)
        {
            switch (this.mouvements[0])
            {
                case TypeMouvement.HAUT: reponse = "MOVE UP"; break;
                case TypeMouvement.GAUCHE: reponse = "MOVE LEFT"; break;
                case TypeMouvement.DROITE: reponse = "MOVE RIGHT "; break;
                case TypeMouvement.BAS: reponse = "MOVE DOWN"; break;
            }

            return reponse;
        }

        private string ActionBlindDrunken()
        {
            return moveMessages[random.Next(moveMessages.Count)];

        }
    }
}
