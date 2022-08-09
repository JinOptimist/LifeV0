using LifeV0.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Worlds
{
    public class WorldBuilder
    {
        public const int InitialLightPower = 10;
        private Random _random = new Random();

        public World GenerateRandomWorld(int width = 100, int height = 100, float creaturesPopulation = 0.05f)
        {
            World world = new World();
            world.Width = width;
            world.Height = height;
            world.Chunks = new WorldChunk[width, height];

            var creatureBuilder = new CreatureBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var lightPower = InitialLightPower * x * y / width / height;
                    var chunk = new WorldChunk(world, x, y, lightPower);
                    world.Chunks[x, y] = chunk;
                }
            }

            var chunkCount = width * height;
            var creatureCount = Math.Ceiling(chunkCount * creaturesPopulation);

            for (int i = 0; i < creatureCount; i++)
            {
                var creaturePlaceSeed = _random.Next(chunkCount);

                var y = creaturePlaceSeed / width;
                var x = creaturePlaceSeed % width;
                var chunk = world[x, y];
                var creature = creatureBuilder.BuildRandomCreature(chunk);
                chunk.Creature = creature;
            }
            
            return world;
        }
    }
}
