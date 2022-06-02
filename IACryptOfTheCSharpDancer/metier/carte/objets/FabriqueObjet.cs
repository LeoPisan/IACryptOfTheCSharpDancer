using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.objets
{
    /// <summary>
    /// sert à créer des objets automatiquement
    /// </summary>
    class FabriqueObjet
    {
        /// <summary>
        /// créée un objet selon le caractère envoyé en paramètre, renvoie null si le caractère ne correspond à aucun objet
        /// </summary>
        /// <param name="caractere">caractère selon lequel on crééera l'objet</param>
        /// <param name="position">position où créer l'objet</param>
        /// <returns>objet créé (ou null)</returns>
        public static Objet Creer(char caractere, Case position)
        {
            Objet retour = null;
            switch (caractere)
            {
                case 'D': retour = new ObjetDiamant(position); break;
            }
            return retour;
        }
    }
}
