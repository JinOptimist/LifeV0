using LifeV0.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Creatures
{
    public class CreatureBuilder
    {

        private Random _random = new Random();

        public Creature BuildRandomCreature(WorldChunk worldChunk)
        {
            var gens = GetInitialGens();

            var creature = new Creature(CreatureSettings.InitialEnergy, gens, worldChunk);

            return creature;
        }

        public void Birth(Creature creature)
        {
            var genCopyCost = (int)Math.Ceiling(CreatureSettings.GenCopyEnergyConsumption * creature.Gens.Length);
            creature.Energry -= genCopyCost;
            creature.Energry /= 2;

            var chunk = creature.WorldChunk;
            var nearEpmtyChunks = chunk.World.GetNearChunks(chunk.X, chunk.Y)
                .Where(x => !x.HasCreature)
                .ToList();

            if (nearEpmtyChunks.Any())
            {
                var randmonIndex = _random.Next(nearEpmtyChunks.Count);
                var newCreatureHomeChunk = nearEpmtyChunks[randmonIndex];
                var child = new Creature(creature.Energry, CopyGens(creature.Gens), newCreatureHomeChunk);

                newCreatureHomeChunk.Creature = child;
            }
            else
            {
                //Kill
                creature.Energry = -1;
            }
        }

        private Gen[] CopyGens(Gen[] gens)
        {
            var newGenLength = gens.Length;
            if (_random.NextDouble() < CreatureSettings.ChanseOfMutation)
            {
                newGenLength++;
            }
            if (_random.NextDouble() < CreatureSettings.ChanseOfMutation)
            {
                newGenLength--;
            }

            var newGens = new Gen[newGenLength];
            for (int i = 0; i < Math.Min(gens.Length, newGenLength); i++)
            {
                newGens[i] = _random.NextDouble() < CreatureSettings.ChanseOfMutation
                    ? RandomGen()
                    : gens[i];
            }

            if (newGenLength > gens.Length)
            {
                newGens[newGenLength - 1] = RandomGen();
            }

            return newGens;
        }

        private Gen[] GetInitialGens()
        {
            var gensCount = _random.Next(CreatureSettings.InitialGensCountMin, CreatureSettings.InitialGensCountMax);
            var gens = new Gen[gensCount];
            for (int i = 0; i < gensCount; i++)
            {
                gens[i] = RandomGen();
            }

            return gens;
        }

        private Gen RandomGen()
        {
            var values = Enum.GetValues(typeof(Gen));
            return (Gen)_random.Next(values.Length);
        }
    }
}
