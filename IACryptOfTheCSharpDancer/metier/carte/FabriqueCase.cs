using IACryptOfTheCSharpDancer.metier.carte.objets;
using IACryptOfTheCSharpDancer.metier.carte.terrains;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    class FabriqueCase
    {
        /// <summary>
        /// créée une case
        /// </summary>
        /// <param name="caractere">caractère indiquant le type de terrain et la présence d'un objet</param>
        /// <param name="coordonnees">coordonnées de l'objet</param>
        /// <returns></returns>
        public static Case Creer(Char caractere, Coordonnees coordonnees)
        {
            Case resultat = new Case(coordonnees);
            resultat.Terrain = FabriqueTerrain.Creer(caractere);
            resultat.Objet = FabriqueObjet.Creer(caractere, resultat);
            return resultat;
        }
    }
}
