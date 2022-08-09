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
                .Where(x => !x.HasCreature);
            
            if (nearEpmtyChunks.Any())
            {
                var list = nearEpmtyChunks.ToList();
                var randmonIndex = _random.Next(list.Count);
                var newCreatureHomeChunk = list[randmonIndex];
                var child = new Creature(creature.Energry, CopyGens(creature.Gens), newCreatureHomeChunk);
                
                newCreatureHomeChunk.Creature = child;
            }
            else
            {
                //Die
                creature.WorldChunk.Creature = null;
            }
        }

        private Gen[] CopyGens(Gen[] gens)
        {
            var newGens = new Gen[gens.Length];
            for (int i = 0; i < gens.Length; i++)
            {
                newGens[i] = _random.NextDouble() < CreatureSettings.ChanseOfMutation
                    ? RandomGen()
                    : gens[i];
            }
            
            return newGens;
        }

        private Gen[] GetInitialGens()
        {
            var gensCount = _random.Next(CreatureSettings.InitialGensCountMin, CreatureSettings.InitialGensCountMax);
            var gens = new Gen[gensCount];
            for (int i = 0; i < gensCount - 1; i++)
            {
                gens[i] = Gen.Fotosintez;
            }

            gens[gensCount - 1] = Gen.Birth;

            return gens;
        }

        private Gen RandomGen()
        {
            var values = Enum.GetValues(typeof(Gen));
            return (Gen)_random.Next(values.Length);
        }
    }
}
