using LifeV0.Worlds;

namespace LifeV0.ConsoleUi
{
    public class WorldDrawer
    {
        public const int Offset = 3;

        public void Draw(World world)
        {
            
            foreach (var chunk in world.Chunks)
            {
                Console.SetCursorPosition(chunk.X + Offset, chunk.Y + Offset);

                if (chunk.HasCreature)
                {
                    if (chunk.Creature.Gens.Contains(Creatures.Gen.Birth))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write('o');
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write('.');
                }
            }
        }
    }
}
