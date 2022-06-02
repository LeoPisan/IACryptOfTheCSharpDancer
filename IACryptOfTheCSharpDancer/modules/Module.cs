using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.modules
{
    /// <summary>
    /// Classe abstraite de module. Un module est une partie de l'IA.
    /// </summary>
    public abstract class Module
    {

        /// <summary>L'IA dont ce module dépend</summary>
        private IA ia;
        public IA IA => ia;

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'ia dont dépend le module</param>
        public Module(IA ia)
        {
            this.ia= ia;
        }
    }
}
