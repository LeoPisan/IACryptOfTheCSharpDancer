using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.algorithme
{
    public class ParcoursLargeur : AlgorithmeCalculDistance
    {
        public ParcoursLargeur(Carte carte)
            : base (carte)
        {
        }

        public override void CalculerDistancesDepuis(Case depart)
        {
            //remise à zéro
            List<Case> aTraiter = new List<Case>();
            this.ReinitialisationDistance();

            //initialisation
            aTraiter.Add(depart);
            this.SetDistance(depart, 0);

            //calcul
            while (aTraiter.Count > 0)
            {
                Case caseEnCours = aTraiter[0];
                aTraiter.RemoveAt(0);
                Traiter(aTraiter, caseEnCours);
            }
        }

        private void Traiter(List<Case> aTraiter, Case caseEnCours)
        {
            foreach (Case v in caseEnCours.Voisins)
            {
                TraiterCase(aTraiter, caseEnCours, v);
            }
        }

        private void TraiterCase(List<Case> aTraiter, Case caseEnCours, Case v)
        {
            if (GetDistance(v) == -1 && v.EstAccessible)
            {
                SetDistance(v, GetDistance(caseEnCours) + 1);
                aTraiter.Add(v);
            }
        }
    }
}
