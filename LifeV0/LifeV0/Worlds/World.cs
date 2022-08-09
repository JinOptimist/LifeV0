using LifeV0.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeV0.Worlds
{
    public class World
    {
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// [X,Y]
        /// </summary>
        public WorldChunk[,] Chunks { get; set; }

        public WorldChunk this[int x, int y] => Chunks[x, y];

        public IEnumerable<WorldChunk> GetNearChunks(int x, int y)
        {
            if (x > 0)
            {
                yield return Chunks[x - 1, y];
            }

            if (x < Width - 2)
            {
                yield return Chunks[x + 1, y];
            }

            if (y > 0)
            {
                yield return Chunks[x, y - 1];
            }

            if (y < Height - 2)
            {
                yield return Chunks[x, y + 1];
            }
        }
    }
}
