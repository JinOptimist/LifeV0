using LifeV0.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Worlds
{
    public class WorldChunk
    {
        public WorldChunk(World world, int x, int y, int lightPower)
        {
            World = world;
            X = x;
            Y = y;
            LightPower = lightPower;
        }

        public World World { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int LightPower { get; set; }

        public Creature Creature { get; set; }

        public bool HasCreature => Creature != null;

        public void Tick()
        {
            //Nothing for now.
            //TODO: ChangeLightPower
        }
    }
}
