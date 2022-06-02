using IACryptOfTheCSharpDancer.metier.algorithme;
using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATest
{
    public class TestParcoursLargeur
    {
        private String mapString =
                "BBBBBBB" +
                "BJMMM B" +
                "B PPP B" +
                "BDMMMDB" +
                "B  B  B" +
                "B  S  B" +
                "BBBBBBB";


        [Fact]
        public void TestcalculerDistancesDepuis()
        {
            Carte carte = new Carte(mapString);
            Case depart = carte.GetCaseAt(new Coordonnees(1, 1));

            ParcoursLargeur instance = new ParcoursLargeur(carte);
            instance.CalculerDistancesDepuis(depart);

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 0))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 1))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 3))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 4))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(0, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 0))));
            Assert.Equal(0, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 1))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 3))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 4))));
            Assert.Equal(12, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(1, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 0))));
            Assert.Equal(1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 1))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 3))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 4))));
            Assert.Equal(11, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(2, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 0))));
            Assert.Equal(2, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 1))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 3))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 4))));
            Assert.Equal(10, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(3, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 0))));
            Assert.Equal(3, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 1))));
            Assert.Equal(4, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 3))));
            Assert.Equal(8, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 4))));
            Assert.Equal(9, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(4, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 0))));
            Assert.Equal(4, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 1))));
            Assert.Equal(5, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 2))));
            Assert.Equal(6, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 3))));
            Assert.Equal(7, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 4))));
            Assert.Equal(8, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(5, 6))));

            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 0))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 1))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 2))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 3))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 4))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 5))));
            Assert.Equal(-1, instance.GetDistance(carte.GetCaseAt(new Coordonnees(6, 6))));
        }
    }
}
