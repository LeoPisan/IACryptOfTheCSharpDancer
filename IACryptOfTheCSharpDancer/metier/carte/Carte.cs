using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte
{
    /// <summary>
    /// représente la carte du jeu
    /// </summary>
    class Carte
    {
        private Dictionary<Coordonnees, Case> cases;
        private int taille;
        /// <summary>
        /// nombre de cases contenues dans la carte
        /// </summary>
        public int Taille => taille;

        /// <summary>
        /// créée une carte selon un message reçu depuis le serveur
        /// </summary>
        /// <param name="messageRecu">message reçu à partir duquel créer la carte</param>
        public Carte(string messageRecu)
        {
            this.cases = new Dictionary<Coordonnees, Case>();
            this.taille = (int)Math.Sqrt(messageRecu.Length);
            for (int i = 0; i < this.taille; i++)
                for (int j = 0; j < this.taille; j++)
                    this.AjouterCase(messageRecu[j + this.taille * i], new Coordonnees(i, j));
        }

        //ajoute une case à la carte
        private void AjouterCase(char caractere, Coordonnees coordonnees)
        {
            this.cases.Add(coordonnees, FabriqueCase.Creer(caractere, coordonnees));
        }
    }
}
