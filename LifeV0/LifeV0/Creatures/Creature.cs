using LifeV0.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Creatures
{
    public class Creature
    {
        public Creature(int energry, Gen[] gens, WorldChunk worldChunk)
        {
            Energry = energry;
            Gens = gens;
            WorldChunk = worldChunk;
            ActiveGenIndex = 0;
        }

        public int Energry { get; set; }

        public Gen[] Gens { get; set; }
        
        public int ActiveGenIndex { get; set; }

        public WorldChunk WorldChunk { get; set; }
    }
}
