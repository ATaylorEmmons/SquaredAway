using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SquaredAway.Code
{
    public class Tile
    {
        private Rectangle rectangle;

        private float size;

        public BlockTypes Type { get; set; }
        public bool doAnimate = false;


        public enum BlockTypes
        {
            TRANSPARENT, //A space with no block
            BLUE,
            GREEN,
            YELLOW,
            RED,
            GREY
        }


        public Tile(Rectangle r, BlockTypes type, float size)
        {
            this.rectangle = r;
            this.size = size;
            this.Type = type;
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }
    }
}
