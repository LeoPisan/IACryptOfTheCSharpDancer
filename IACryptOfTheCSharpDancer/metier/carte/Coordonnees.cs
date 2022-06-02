using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    /// <summary>
    /// contient les coordonnées d'une case
    /// </summary>
    public class Coordonnees
    {
        #region attributes
        private int ligne;
        private int colonne;
        #endregion

        #region properties
        /// <summary>
        /// numéro de ligne de la coordonnée
        /// </summary>
        public int Ligne => ligne;
        /// <summary>
        /// numéro de colonne de la coordonnée
        /// </summary>
        public int Colonne => colonne;
        #endregion

        #region public methods
        /// <summary>
        /// créée une coordonnée
        /// </summary>
        /// <param name="nbligne">numéro de lignes de cette coordonnée</param>
        /// <param name="nbcolonne">numéro de colonne de cette coordonnée</param>
        public Coordonnees(int nbligne, int nbcolonne)
        {
            this.ligne = nbligne;
            this.colonne = nbcolonne;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordonnees coordonnees &&
                   ligne == coordonnees.ligne &&
                   colonne == coordonnees.colonne;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ligne, colonne);
        }

        /// <summary>
        /// renvoie les coordonnées d'un voisin
        /// </summary>
        /// <param name="mouvement">direction où se trouve le voisin</param>
        /// <returns>coordonnées du voisin</returns>
        public Coordonnees GetVoisin(TypeMouvement mouvement)
        {
            Coordonnees retour = null;
            switch(mouvement)
            {
                case TypeMouvement.HAUT:
                    retour = new Coordonnees(this.Ligne - 1, this.Colonne); break;
                case TypeMouvement.BAS:
                    retour = new Coordonnees(this.Ligne + 1, this.Colonne); break;
                case TypeMouvement.DROITE:
                    retour = new Coordonnees(this.Ligne, this.Colonne + 1); break;
                case TypeMouvement.GAUCHE:
                    retour = new Coordonnees(this.Ligne, this.Colonne - 1); break;
            }
            return retour;
        }

        /// <summary>
        /// renvoie la direction de déplacement à prendre pour aller vers une case voisine
        /// </summary>
        /// <param name="destination">case cible</param>
        /// <returns>direction à prendre</returns>
        public TypeMouvement GetMouvementPourAller(Coordonnees destination)
        {
            TypeMouvement retour;
            if (destination.Ligne == this.Ligne - 1)
                retour = TypeMouvement.HAUT;
            else if (destination.Ligne == this.Ligne + 1)
                retour = TypeMouvement.BAS;
            else if (destination.Colonne == this.Colonne - 1)
                retour = TypeMouvement.GAUCHE;
            else
                retour = TypeMouvement.DROITE;
            return retour;
        }
        #endregion
    }
}
