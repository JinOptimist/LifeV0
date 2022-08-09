using LifeV0.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Worlds
{
    public class WorldTimeManager
    {
        private CreatureBuilder _creatureBuilder = new CreatureBuilder();

        public WorldTimeManager(World world)
        {
            World = world;
        }

        public World World { get; set; }

        public void Tick()
        {
            foreach (var chunk in World.Chunks)
            {
                chunk.Tick();

                if (chunk.HasCreature)
                {
                    CreatureTick(chunk.Creature);
                }
            }
        }

        private void CreatureTick(Creature creature)
        {
            var activeGen = creature.Gens[creature.ActiveGenIndex];

            switch (activeGen)
            {
                case Gen.Idle:
                    break;
                case Gen.Fotosintez:
                    creature.Energry += creature.WorldChunk.LightPower;
                    break;
                case Gen.Birth:
                    _creatureBuilder.Birth(creature);
                    break;
                case Gen.MoveNorth:
                    break;
                case Gen.MoveSouth:
                    break;
                case Gen.MoveWest:
                    break;
                case Gen.MoveEast:
                    break;
                default:
                    break;
            }

            creature.Energry -= CreatureSettings.MinEnergyConsumption;
            if (creature.Energry < 0)
            {
                creature.WorldChunk.Creature = null;
            }

            creature.ActiveGenIndex = (creature.ActiveGenIndex + 1) % creature.Gens.Length;
        }
    }
}
