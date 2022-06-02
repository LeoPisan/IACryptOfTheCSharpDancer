using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.objets
{
    /// <summary>
    /// objet collectable dans le jeu
    /// </summary>
    abstract class Objet
    {
        private Case position;

        #region properties
        /// <summary>
        /// position de l'objet
        /// </summary>
        public Case Position => position;
        /// <summary>
        /// type de l'objet
        /// </summary>
        public abstract TypeObjet Type { get; }
        #endregion

        /// <summary>
        /// créée un objet à une position donnée
        /// </summary>
        /// <param name="position">position où l'objet doit être créé</param>
        public Objet(Case position)
        {
            this.position = position;
        }
    }
}
