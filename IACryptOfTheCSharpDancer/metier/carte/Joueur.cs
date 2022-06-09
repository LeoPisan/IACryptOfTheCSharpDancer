using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    public class Joueur
    {
        private Coordonnees coordonnees;

        public Coordonnees Coordonnees => coordonnees;
        public int Ligne => Coordonnees.Ligne;
        public int Colonne => Coordonnees.Colonne;

        public Joueur(Coordonnees coordonnees)
        {
            this.coordonnees = coordonnees;
        }

        public void Deplacer(TypeMouvement mouvement)
        {
            switch (mouvement)
            {
                case TypeMouvement.HAUT:
                    coordonnees = new Coordonnees(Ligne - 1, Colonne);
                    break;
                case TypeMouvement.BAS:
                    coordonnees = new Coordonnees(Ligne + 1, Colonne);
                    break;
                case TypeMouvement.GAUCHE:
                    coordonnees = new Coordonnees(Ligne, Colonne - 1);
                    break;
                case TypeMouvement.DROITE:
                    coordonnees = new Coordonnees(Ligne, Colonne + 1);
                    break;
            }
        }
    }
}
