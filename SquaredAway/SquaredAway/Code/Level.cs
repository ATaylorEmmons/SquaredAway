using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredAway.Code
{
    public class Level
    {

        public string Name { get { return name; } }
        string name;

        public int GridSize { get { return gridSize; } }
        int gridSize;


        public int[,] TileData { get { return tileData; } }
        int[,] tileData;


        public Level(string name, int gridSize, int[,] data)
        {
            this.name = name;
            this.gridSize = gridSize;
            this.tileData = data;
        }
    }
}
