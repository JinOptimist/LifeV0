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
                    Console.Write('o');
                }
                else
                {
                    Console.Write('.');
                }
            }
        }
    }
}
