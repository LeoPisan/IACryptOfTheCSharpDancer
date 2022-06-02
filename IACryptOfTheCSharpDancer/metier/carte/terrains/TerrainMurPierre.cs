using System;
using System.Collections.Generic;
using System.Text;

namespace IACryptOfTheCSharpDancer.metier.carte.terrains
{
    class TerrainMurPierre : Terrain
    {
        public override TypeTerrain Type => TypeTerrain.MURPIERRE;
        public override bool EstAccessible => false;
    }
}
