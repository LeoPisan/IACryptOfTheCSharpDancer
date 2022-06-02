using IACryptOfTheCSharpDancer.metier.carte.objets;
using IACryptOfTheCSharpDancer.metier.carte.terrains;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    public class Case
    {
        #region attributes
        private Coordonnees coordonnees;
        private Terrain terrain;
        private Objet objet;
        private List<Case> voisins;
        #endregion

        #region property
        /// <summary>
        /// coordonnées de la case
        /// </summary>
        public Coordonnees Coordonnees => coordonnees;
        /// <summary>
        /// terrain de la case
        /// </summary>
        public Terrain Terrain { get { return this.terrain; } set { this.terrain = value; } }
        /// <summary>
        /// objet contenu par la case
        /// </summary>
        public Objet Objet { get { return this.objet; } set { this.objet = value; } }
        /// <summary>
        /// indique si la case est accessible
        /// </summary>
        public bool EstAccessible => this.Terrain.EstAccessible;
        public List<Case> Voisins => this.voisins;
        #endregion

        #region public methods
        public Case(Coordonnees coordonnees)
        {
            this.coordonnees = coordonnees;
            this.voisins = new List<Case>();
        }

        /// <summary>
        /// ajoute un voisin
        /// </summary>
        /// <param name="voisin">voisin à ajouter</param>
        public void AjouterVoisin(Case voisin)
        {
            voisins.Add(voisin);
        }
        #endregion
    }
}
