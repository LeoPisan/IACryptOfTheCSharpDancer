using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class FabriqueTerrain
    {
        /// <summary>
        /// fabrique et renvoie un terrain selon le caractère envoyé en paramètre
        /// </summary>
        /// <param name="caractere">caractère représentant un terrain</param>
        /// <returns></returns>
        public static Terrain Creer(char caractere)
        {
            Terrain retour = null;
            switch (caractere)
            {
                case 'M': retour = new TerrainMur(); break;
                case 'B': retour = new TerrainBord(); break;
                case 'P': retour = new TerrainMurPierre(); break;
                case 'S': retour = new TerrainSortie(); break;
                default: retour = new TerrainVide(); break;
            }
            return retour;
        }
    }
}
