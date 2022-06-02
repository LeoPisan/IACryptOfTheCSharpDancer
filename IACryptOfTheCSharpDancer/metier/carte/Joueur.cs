using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    public class Joueur
    {
        private Coordonnees coordonnees;

        public Coordonnees Coordonnees => coordonnees;

        public Joueur(Coordonnees coordonnees)
        {
            this.coordonnees = coordonnees;
        }

        public void Deplacer(TypeMouvement mouvement)
        {

        }
    }
}
