using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.objets
{
    /// <summary>
    /// diamant nécessaire pour gagner le jeu
    /// </summary>
    class ObjetDiamant : Objet
    {
        /// <summary>
        /// créée un nouveau diamant à la position indiquée
        /// </summary>
        /// <param name="position">position où créer le diamant</param>
        public ObjetDiamant(Case position) : base(position)
        {
        }

        public override TypeObjet Type => TypeObjet.DIAMANT;
    }
}
