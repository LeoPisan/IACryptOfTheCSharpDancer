using IACryptOfTheCSharpDancer.metier.carte;
using System;
using Xunit;

namespace IATest
{
    public class TestVoisinsCoordonnees
    {

        private Random generateur = new Random();

        [Fact]
        public void TestGetVoisinHAUT()
        {
            for(int i=0;i<10;i++)
            {
                int ligne = generateur.Next(20);
                int colonne = generateur.Next(20);
                Coordonnees centre = new Coordonnees(ligne, colonne);
                Coordonnees attendu = new Coordonnees(ligne-1, colonne);
                Assert.Equal(attendu, centre.GetVoisin(TypeMouvement.HAUT));
            }
        }

        [Fact]
        public void TestGetVoisinBAS()
        {
            for (int i = 0; i < 10; i++)
            {
                int ligne = generateur.Next(20);
                int colonne = generateur.Next(20);
                Coordonnees centre = new Coordonnees(ligne, colonne);
                Coordonnees attendu = new Coordonnees(ligne + 1, colonne);
                Assert.Equal(attendu, centre.GetVoisin(TypeMouvement.BAS));
            }
        }

        [Fact]
        public void TestGetVoisinDROITE()
        {
            for (int i = 0; i < 10; i++)
            {
                int ligne = generateur.Next(20);
                int colonne = generateur.Next(20);
                Coordonnees centre = new Coordonnees(ligne, colonne);
                Coordonnees attendu = new Coordonnees(ligne, colonne+1);
                Assert.Equal(attendu, centre.GetVoisin(TypeMouvement.DROITE));
            }
        }

        [Fact]
        public void TestGetVoisinGAUCHE()
        {
            for (int i = 0; i < 10; i++)
            {
                int ligne = generateur.Next(20);
                int colonne = generateur.Next(20);
                Coordonnees centre = new Coordonnees(ligne, colonne);
                Coordonnees attendu = new Coordonnees(ligne, colonne - 1);
                Assert.Equal(attendu, centre.GetVoisin(TypeMouvement.GAUCHE));
            }
        }


        [Fact]
        public void TestGetMouvementPourAller()
        {
            for(int i=0;i<10;i++)
            {
                int ligne = generateur.Next(20);
                int colonne = generateur.Next(20);
                Coordonnees centre = new Coordonnees(ligne, colonne);
                Coordonnees haut = new Coordonnees(ligne - 1, colonne);
                Coordonnees bas = new Coordonnees(ligne + 1, colonne);
                Coordonnees droite = new Coordonnees(ligne, colonne + 1);
                Coordonnees gauche = new Coordonnees(ligne, colonne - 1);

                Assert.Equal(TypeMouvement.HAUT, centre.GetMouvementPourAller(haut));
                Assert.Equal(TypeMouvement.BAS, centre.GetMouvementPourAller(bas));
                Assert.Equal(TypeMouvement.DROITE, centre.GetMouvementPourAller(droite));
                Assert.Equal(TypeMouvement.GAUCHE, centre.GetMouvementPourAller(gauche));

            }

        }
    }
}
