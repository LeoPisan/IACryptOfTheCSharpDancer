using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class TerrainSortie : Terrain
    {
        public override TypeTerrain Type => TypeTerrain.SORTIE;
        public override bool EstAccessible => true;
    }
}
