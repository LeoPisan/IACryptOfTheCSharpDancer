using IACryptOfTheCSharpDancer.metier.algorithme;
using IACryptOfTheCSharpDancer.metier.carte;
using IACryptOfTheCSharpDancer.metier.carte.objets;
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
        public List<Objet> Diamonds => IA.Diamonds;

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
                FindPathToDiamondWithParcoursLargeur();
            }
            else if (this.mouvements.Count == 0)
            {
                FindPathToExitWithParcoursLargeur();
            }

            if (this.mouvements.Count > 0)
            {
                reponse = DiamondIsReached(reponse);
            }

            return reponse;
        }

        private string DiamondIsReached(string reponse)
        {
            reponse = MovementToString(reponse);
            this.mouvements.RemoveAt(0);
            return reponse;
        }

        private void FindPathToDiamondWithDijkstra()
        {
            Dijkstra dijkstra = new Dijkstra(Carte);
            Case start = Carte.GetCaseAt(IA.ModuleMemoire.Joueur.Coordonnees);
            dijkstra.CalculerDistancesDepuis(start);

            int distanceMin = -1;
            ObjetDiamant closestDiamond = null;

            foreach (Objet o in Diamonds)
            {
                FindClosestDiamond(dijkstra, ref distanceMin, ref closestDiamond, o);
            }
            mouvements = dijkstra.GetChemin(closestDiamond.Position);
        }

        private void FindPathToDiamondWithParcoursLargeur()
        {
            AlgorithmeCalculDistance parcours = new ParcoursLargeur(this.IA.ModuleMemoire.Carte);
            Case depart = Carte.GetCaseAt(IA.ModuleMemoire.Joueur.Coordonnees);
            parcours.CalculerDistancesDepuis(depart);
            /*
            this.mouvements = parcours.GetChemin(this.IA.ModuleMemoire.Diamants[0].Position);
            */

            int distanceMin = -1;
            ObjetDiamant closestDiamond = null;

            foreach (Objet o in Diamonds)
            {
                FindClosestDiamond(parcours, ref distanceMin, ref closestDiamond, o);
            }
            mouvements = parcours.GetChemin(closestDiamond.Position);
        }

        private static void FindClosestDiamond(AlgorithmeCalculDistance parcours, ref int distanceMin, ref ObjetDiamant closestDiamond, Objet o)
        {
            int distanceO = parcours.GetDistance(o.Position);
            if (distanceMin == -1 || distanceO < distanceMin)
            {
                distanceMin = distanceO;
                closestDiamond = (ObjetDiamant)o;
            }
        }

        private void FindPathToExitWithDijkstra()
        {
            Dijkstra dijkstra = new Dijkstra(this.IA.ModuleMemoire.Carte);
            Case start = IA.ModuleMemoire.Carte.GetCaseAt(IA.ModuleMemoire.Joueur.Coordonnees);
            Case exit = IA.ModuleMemoire.Carte.GetCaseAt(IA.ModuleMemoire.Carte.CoordonneesSortie);
            dijkstra.CalculerDistancesDepuis(start);
            mouvements = dijkstra.GetChemin(exit);
        }

        private void FindPathToExitWithParcoursLargeur()
        {
            AlgorithmeCalculDistance parcours = new ParcoursLargeur(this.IA.ModuleMemoire.Carte);
            Case depart = this.IA.ModuleMemoire.Carte.GetCaseAt(this.IA.ModuleMemoire.Joueur.Coordonnees);
            Case sortie = this.IA.ModuleMemoire.Carte.GetCaseAt(this.IA.ModuleMemoire.Carte.CoordonneesSortie);
            parcours.CalculerDistancesDepuis(depart);
            this.mouvements = parcours.GetChemin(sortie);
        }

        private string MovementToString(string reponse)
        {
            switch (this.mouvements[0])
            {
                case TypeMouvement.HAUT: reponse = "MOVE UP"; break;
                case TypeMouvement.GAUCHE: reponse = "MOVE LEFT"; break;
                case TypeMouvement.DROITE: reponse = "MOVE RIGHT"; break;
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
