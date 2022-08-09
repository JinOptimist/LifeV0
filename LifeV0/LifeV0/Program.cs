using LifeV0.ConsoleUi;
using LifeV0.Worlds;

namespace LifeV0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var world = new WorldBuilder().GenerateRandomWorld(60, 40);
            Console.WriteLine("World building is done");

            //world.Tick();

            var worldTimeManager = new WorldTimeManager(world);
            var drawer = new WorldDrawer();

            var tick = 0;
            while (true)
            {
                tick++;

                if (tick > 10 * 1000)
                {
                    drawer.Draw(world);
                    Thread.Sleep(100);
                }

                worldTimeManager.Tick();
            }
        }
    }
}