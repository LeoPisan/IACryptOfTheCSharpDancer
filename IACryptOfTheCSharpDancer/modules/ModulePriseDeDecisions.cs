using System;
using System.Collections.Generic;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>Ce module est en charge de prendre les décisions pour l'IA (que doit je faire ?)</summary>
    public class ModulePriseDeDecisions : Module
    {
        private Random random = new Random();
        private List<string> messagesDrunken = new List<string>() { "MOVE LEFT", "MOVE RIGHT", "MOVE DOWN", "MOVE UP" };


        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">Ia dont dépend le module</param>
        public ModulePriseDeDecisions(IA ia) : base(ia){}

        /// <summary>Méthode déterminant la prochaine action à réaliser</summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public string DeterminerNouvelleAction(string messageRecuDuServeur)
        {
            string retour = null;
            if (!IA.ModuleMemoire.HasCarte())
                retour = "MAP";
            else
            {
                retour = "END";
                this.IA.ArreterLaCommunication();
            }
            return retour;
        }

        private string ActionBlindDrunken()
        {
            return messagesDrunken[random.Next(messagesDrunken.Count)];

        }
    }
}
