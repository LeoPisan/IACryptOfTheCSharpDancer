using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    /// <summary>
    /// représente un terrain générique
    /// </summary>
    abstract class Terrain
    {

        /// <summary>
        /// type du terrain
        /// </summary>
        public abstract TypeTerrain Type { get; }
        /// <summary>
        /// indique si la case est accessible
        /// </summary>
        public abstract bool EstAccessible { get; }
    }
}
