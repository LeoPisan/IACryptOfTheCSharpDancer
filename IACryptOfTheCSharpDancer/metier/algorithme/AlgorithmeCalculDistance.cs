using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.algorithme
{
    public abstract class AlgorithmeCalculDistance
    {
        #region attributes
        private Dictionary<Case, int> distances;
        private Carte carte;
        #endregion

        public Carte Carte => carte;

        /// <summary>
        /// calcul des distances
        /// </summary>
        /// <param name="depart">case de départ</param>
        public abstract void CalculerDistancesDepuis(Case depart);
        /// <summary>
        /// détermine le chemin à suivre pour aller jusqu'à une case spécifique
        /// </summary>
        /// <param name="arrivee">case d'arrivée</param>
        /// <returns>chemin à suivre</returns>
        public abstract List<TypeMouvement> GetChemin(Case arrivee);

        #region public methods
        /// <summary>
        /// initialise une nouvelle instance d'un algorithme de calcul de distances
        /// </summary>
        /// <param name="carte">carte à utiliser pour calculer les distances</param>
        public AlgorithmeCalculDistance(Carte carte)
        {
            this.carte = carte;
            this.distances = new Dictionary<Case, int>();
        }

        /// <summary>
        /// renvoie la distance entre cette case et une autre
        /// </summary>
        /// <param name="position">case cible</param>
        /// <returns></returns>
        public int GetDistance(Case position)
        {
            int retour = -1;
            if (distances.ContainsKey(position))
                retour = distances[position];
            return retour;
        }
        #endregion

        #region protected methods
        /// <summary>
        /// ajoute en mémoire la distance entre cette case et une autre
        /// </summary>
        /// <param name="position">case cible</param>
        /// <param name="valeur">distance à ajouter en mémoire</param>
        protected void SetDistance(Case position, int valeur)
        {
            if (!distances.ContainsKey(position))
                distances.Add(position, valeur);
        }

        /// <summary>
        /// réinitialise le dictionnaire
        /// </summary>
        protected void ReinitialisationDistance()
        {
            distances.Clear();
        }
        #endregion
    }
}
