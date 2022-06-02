using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class TerrainVide : Terrain
    {
        public override TypeTerrain Type => TypeTerrain.VIDE;
        public override bool EstAccessible => true;
    }
}
