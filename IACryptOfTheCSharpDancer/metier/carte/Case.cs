using IACryptOfTheCSharpDancer.metier.carte.objets;
using IACryptOfTheCSharpDancer.metier.carte.terrains;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    class Case
    {
        #region attributes
        private Coordonnees coordonnees;
        private Terrain terrain;
        private Objet objet;
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
        public bool EstAccessible
        #endregion

        #region public methods
        public Case(Coordonnees coordonnees)
        {
            this.coordonnees = coordonnees;
        }
        #endregion
    }
}
