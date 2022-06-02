using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using Xunit;

namespace IATest
{
    public class TestVoisinsMap
    {
        private String mapString =
                "BBBBBBB" +
                "BMMMMMB" +
                "BMD DMB" +
                "BM J MB" +
                "BMD DMB" +
                "BMMMMMB" +
                "BBBBBBB";

        [Fact]
        public void TestVoisinsNormal()
        {
            Carte carte = new Carte(mapString);
            List<Coordonnees> cooVoisins = new List<Coordonnees>();
            cooVoisins.Add(new Coordonnees(0, 1));
            cooVoisins.Add(new Coordonnees(2, 1));
            cooVoisins.Add(new Coordonnees(1, 2));
            cooVoisins.Add(new Coordonnees(1, 0));

            Case c = carte.GetCaseAt(new Coordonnees(1, 1));
            Assert.Equal(4, c.Voisins.Count);
            foreach(Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }
        }

        [Fact]
        public void TestVoisinsCoin()
        {
            Carte carte = new Carte(mapString);
            
            //HAUT GAUCHE
            List<Coordonnees> cooVoisins = new List<Coordonnees>();
            cooVoisins.Add(new Coordonnees(0, 1));
            cooVoisins.Add(new Coordonnees(1, 0));

            Case c = carte.GetCaseAt(new Coordonnees(0, 0));
            Assert.Equal(2, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }

            //HAUT DROIT
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(0, 5));
            cooVoisins.Add(new Coordonnees(1, 6));

            c = carte.GetCaseAt(new Coordonnees(0, 6));
            Assert.Equal(2, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }

            //BAS DROIT
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(5, 6));
            cooVoisins.Add(new Coordonnees(6, 5));

            c = carte.GetCaseAt(new Coordonnees(6, 6));
            Assert.Equal(2, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }


            //BAS GAUCHE
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(5, 0));
            cooVoisins.Add(new Coordonnees(6, 1));

            c = carte.GetCaseAt(new Coordonnees(6, 0));
            Assert.Equal(2, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }
        }

        [Fact]
        public void TestVoisinsBord()
        {
            Carte carte = new Carte(mapString);

            //HAUT
            List<Coordonnees> cooVoisins = new List<Coordonnees>();
            cooVoisins.Add(new Coordonnees(0, 1));
            cooVoisins.Add(new Coordonnees(0, 3));
            cooVoisins.Add(new Coordonnees(1, 2));

            Case c = carte.GetCaseAt(new Coordonnees(0, 2));
            Assert.Equal(3, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }

            //DROIT
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(2, 5));
            cooVoisins.Add(new Coordonnees(1, 6));
            cooVoisins.Add(new Coordonnees(3, 6));

            c = carte.GetCaseAt(new Coordonnees(2, 6));
            Assert.Equal(3, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }

            //GAUCHE
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(2, 1));
            cooVoisins.Add(new Coordonnees(1, 0));
            cooVoisins.Add(new Coordonnees(3, 0));

            c = carte.GetCaseAt(new Coordonnees(2, 0));
            Assert.Equal(3, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }


            //BAS
            cooVoisins.Clear();
            cooVoisins.Add(new Coordonnees(5, 2));
            cooVoisins.Add(new Coordonnees(6, 1));
            cooVoisins.Add(new Coordonnees(6, 3));

            c = carte.GetCaseAt(new Coordonnees(6, 2));
            Assert.Equal(3, c.Voisins.Count);
            foreach (Coordonnees cooVoisin in cooVoisins)
            {
                Assert.Contains<Case>(carte.GetCaseAt(cooVoisin), c.Voisins);
            }
        }
    }
}
