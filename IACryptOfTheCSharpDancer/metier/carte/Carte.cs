using IACryptOfTheCSharpDancer.metier.carte.objets;
using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    /// <summary>
    /// représente la carte du jeu
    /// </summary>
    public class Carte
    {
        private Dictionary<Coordonnees, Case> cases;
        private int taille;
        private Coordonnees coordonneesDepart;
        private List<Objet> diamants;

        /// <summary>
        /// nombre de cases contenues dans la carte
        /// </summary>
        public int Taille => taille;
        /// <summary>
        /// coordonnées de départ du joueur
        /// </summary>
        public Coordonnees CoordonneesDepart => coordonneesDepart;

        /// <summary>
        /// listte des diamants de la carte
        /// </summary>
        public List<Objet> Diamants { get => diamants; }



        /// <summary>
        /// créée une carte selon un message reçu depuis le serveur
        /// </summary>
        /// <param name="messageRecu">message reçu à partir duquel créer la carte</param>
        public Carte(string messageRecu)
        {
            diamants = new List<Objet>();
            this.cases = new Dictionary<Coordonnees, Case>();
            this.taille = (int)Math.Sqrt(messageRecu.Length);
            for (int i = 0; i < this.taille; i++)
                for (int j = 0; j < this.taille; j++)
                    this.AjouterCase(messageRecu[j + this.taille * i], new Coordonnees(i, j));

            for (int i = 0; i < this.taille; i++)
            {
                for (int j = 0; j < this.taille; j++)
                {
                    Coordonnees cooCase = new Coordonnees(i, j);
                    foreach (TypeMouvement mouvement in
                    (TypeMouvement[])Enum.GetValues(typeof(TypeMouvement)))
                    {
                        Coordonnees cooVoisin = cooCase.GetVoisin(mouvement);
                        if (this.cases.ContainsKey(cooVoisin))
                        {
                            this.cases[cooCase].AjouterVoisin(this.cases[cooVoisin]);
                        }
                    }
                }
            }
        }

        public Case GetCaseAt(Coordonnees coordonnees)
        {
            return cases[coordonnees];
        }

        //ajoute une case à la carte
        private void AjouterCase(char caractere, Coordonnees coordonnees)
        {
            Case newCase = FabriqueCase.Creer(caractere, coordonnees);
            cases.Add(coordonnees, newCase);
            switch (caractere)
            {
                case 'J':
                    coordonneesDepart = coordonnees;
                    break;
                case 'D':
                    diamants.Add(newCase.Objet);
                    break;
            }
        }
    }
}
