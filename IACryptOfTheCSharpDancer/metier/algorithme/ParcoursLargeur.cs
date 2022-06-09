using IACryptOfTheCSharpDancer.metier.carte;
using IACryptOfTheCSharpDancer.metier.carte.terrains;
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

        public override List<TypeMouvement> GetChemin(Case arrivee)
        {
            //initialisation
            List<TypeMouvement> resultat = new List<TypeMouvement>();
            Case caseEnCours = arrivee;

            //calcul
            if (GetDistance(caseEnCours) != -1)
            {
                caseEnCours = GenerateWay(resultat, caseEnCours);
            }

            return resultat;
        }

        private Case GenerateWay(List<TypeMouvement> resultat, Case caseEnCours)
        {
            /*
            * On sait qu'on sortira forcément de la boucle puisque 
            * on peut considérer la distance jusqu'à caseEnCours 
            * comme une suite arithmétique de raison r = -1
            * cette distance deviendra donc forcément inférieure à 0
            */

            while (GetDistance(caseEnCours) > 0)
            {
                caseEnCours = AddPreviousCase(resultat, caseEnCours);
            }
            resultat.Reverse();
            return caseEnCours;
        }

        private Case AddPreviousCase(List<TypeMouvement> resultat, Case caseEnCours)
        {
            Case previous = FindPreviousCase(caseEnCours);
            TypeMouvement move = previous.GetMouvementPourAller(caseEnCours);

            //on ajoute le nombre de déplacements nécessaires selon le poids de l'arète
            for (int i = 0; i < previous.MoveCost; i++)
            {
                resultat.Add(move);
            }

            caseEnCours = previous;
            return caseEnCours;
        }

        private Case FindPreviousCase(Case caseEnCours)
        {
            Case returnValue = null;
            foreach (Case c in caseEnCours.Voisins)
                returnValue = CheckIsPreviousCase(caseEnCours, returnValue, c);
            return returnValue;
        }

        private Case CheckIsPreviousCase(Case caseEnCours, Case returnValue, Case c)
        {
            if (GetDistance(c) == GetDistance(caseEnCours) - 1)
                returnValue = c;
            return returnValue;
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
