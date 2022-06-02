using IACryptOfTheCSharpDancer.metier.carte;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Module en charge de mémoriser les informations dont l'IA a besoin pour fonctionner</summary>
    public class ModuleMemoire : Module
    {
        private Carte carte;
        private Joueur joueur;

        public Joueur Joueur => joueur;

        #region public methods
        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleMemoire(IA ia) : base(ia){}

        /// <summary>
        /// créée la carte selon un message reçu
        /// </summary>
        /// <param name="messageRecu">message depuis lequel crééer la carte</param>
        public void GenererCarte(string messageRecu)
        {
            this.carte = new Carte(messageRecu);
            GenererJoueur(carte.CoordonneesDepart);
        }

        /// <summary>
        /// indique si la carte a été créée
        /// </summary>
        /// <returns>valeur booléenne indiquant si la carte est bel et bien créée</returns>
        public bool HasCarte()
        {
            return this.carte != null;
        }

        public bool HasJoueur()
        {
            return Joueur == null;
        }

        public void GenererJoueur(Coordonnees coordonnees)
        {
            this.joueur = new Joueur(coordonnees);
        }
        #endregion
    }
}
