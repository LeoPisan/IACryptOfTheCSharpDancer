using IACryptOfTheCSharpDancer.metier.algorithme;
using IACryptOfTheCSharpDancer.metier.carte;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATest
{
    public class TestParcoursLargeurChemin
    {
        private String mapString =
                "BBBBBBB" +
                "BJMM  B" +
                "B PPP B" +
                "BDMMMDB" +
                "B B   B" +
                "B  SMMB" +
                "BBBBBBB";


        [Fact]

        public void TestGetChemin()
        {
            Carte carte = new Carte(mapString);
            Case depart = carte.GetCaseAt(new Coordonnees(1, 1));

            ParcoursLargeur instance = new ParcoursLargeur(carte);
            instance.CalculerDistancesDepuis(depart);

            List<TypeMouvement> expected = new List<TypeMouvement>()
            {
                TypeMouvement.BAS,
                TypeMouvement.BAS,
                TypeMouvement.BAS,
                TypeMouvement.BAS,
                TypeMouvement.DROITE,
                TypeMouvement.DROITE,
                TypeMouvement.HAUT,
                TypeMouvement.DROITE,
                TypeMouvement.DROITE,
                TypeMouvement.HAUT,
                TypeMouvement.HAUT,
                TypeMouvement.HAUT,
                TypeMouvement.GAUCHE
            };

            List<TypeMouvement> result = instance.GetChemin(carte.GetCaseAt(new Coordonnees(1, 4)));

            Assert.Equal<TypeMouvement>(expected, result);
        }
    }
}
