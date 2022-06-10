using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.algorithme
{
    class Dijkstra : AlgorithmeCalculDistance
    {
        private Dictionary<Case, bool> isVisited;
        private Dictionary<Case, Case> previous;

        public Dijkstra(Carte carte)
            :base(carte)
        {
            isVisited = new Dictionary<Case, bool>();
            previous = new Dictionary<Case, Case>();
        }

        public override void CalculerDistancesDepuis(Case depart)
        {
            Initialisation(depart);
            while (isVisited.ContainsValue(false))
            {
                Case a = LessNonVisited();
                HandleCase(a);
            }
        }

        private void HandleCase(Case a)
        {
            isVisited[a] = true;
            foreach (Case neightboor in a.Voisins)
            {
                Release(a, neightboor);
            }
        }

        public override List<TypeMouvement> GetChemin(Case arrivee)
        {
            List<Case> path = new List<Case>();
            Case currentCase = arrivee;
            while (previous[currentCase] != null)
            {
                path.Add(currentCase);
            }
            List<TypeMouvement> result = new List<TypeMouvement>();
            for (int i = path.Count - 1; i >= 0; i--)
            {
                Case _case = path[i];
                AddMove(result, _case);
            }
            return result;
        }

        private void AddMove(List<TypeMouvement> result, Case _case)
        {
            if (previous[_case] != null)
                result.Add(previous[_case].GetMouvementPourAller(_case));
        }

        private void Initialisation(Case start)
        {
            List<Case> sommets = new List<Case>(Carte.Cases.Values);
            foreach (Case _case in sommets)
            {
                isVisited[_case] = false;
                previous[_case] = null;
            }
            SetDistance(start, 0);
        }

        private void Release(Case a, Case b)
        {
            int distance_a = GetDistance(a);
            int distance_between = GetDistanceBetweenCases(a, b);
            if (GetDistance(b) > distance_a + distance_between)
            {
                SetDistance(b, distance_a + distance_between);
                previous[b] = a;
            }
        }

        private Case LessNonVisited()
        {
            Case result = null;
            
            foreach (Case _case in isVisited.Keys)
            {
                result = SelectClosestNonVisited(result, _case);
            }

            return result;
        }

        private Case SelectClosestNonVisited(Case result, Case _case)
        {
            if (!isVisited[_case])
            {
                result = SelectClosetCase(result, _case);
            }

            return result;
        }

        private Case SelectClosetCase(Case result, Case _case)
        {
            if (GetDistance(_case) < GetDistance(result) || GetDistance(result) == -1)
            {
                result = _case;
            }

            return result;
        }

        private int GetDistanceBetweenCases(Case a, Case b)
        {
            int result = -1;

            result = b.MoveCost;

            return result;
        }
    }
}
