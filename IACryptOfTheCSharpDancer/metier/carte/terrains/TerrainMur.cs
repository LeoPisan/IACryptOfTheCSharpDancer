using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class TerrainMur : Terrain
    {
        public override TypeTerrain Type => TypeTerrain.MUR;
        public override bool EstAccessible => false;
    }
}
