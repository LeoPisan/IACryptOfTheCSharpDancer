using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class TerrainBord : Terrain
    {
        public override TypeTerrain Type => TypeTerrain.BORD;
        public override bool EstAccessible => false;
    }
}
