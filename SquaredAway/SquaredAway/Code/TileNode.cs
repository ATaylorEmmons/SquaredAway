using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredAway.Code
{
    public class TileNode
    {
        public TileNode Up;
        public TileNode Down;
        public TileNode Left;
        public TileNode Right;

        public bool isOccupied;
        public Tile payload;


        public TileNode()
        {
            this.Up = null;
            this.Down = null;
            this.Left = null;
            this.Right = null;
        }

        public void setTile(Tile t)
        {
            this.payload = t;
            this.isOccupied = true;
        }

        public void ShiftLeft()
        {
            if (this.isOccupied && (this.payload.Type != Tile.BlockTypes.GREY))
            {
                if (this.Left != null && !this.Left.isOccupied)
                {
                    this.payload.doAnimate = true;
                    this.Left.payload = this.payload;
                    this.Left.isOccupied = true;

                    this.isOccupied = false;
                    this.payload = null;

                }
            }
        }

        public void ShiftRight()
        {
            if (this.isOccupied && (this.payload.Type != Tile.BlockTypes.GREY))
            {
                if (this.Right != null && !this.Right.isOccupied)
                {
                    this.payload.doAnimate = true;
                    this.Right.payload = this.payload;
                    this.Right.isOccupied = true;

                    this.isOccupied = false;
                    this.payload = null;
                }
            }
        }

        public void ShiftUp()
        {
            if (this.isOccupied && (this.payload.Type != Tile.BlockTypes.GREY))
            {
                if (this.Up != null && !this.Up.isOccupied)
                {
                    this.payload.doAnimate = true;
                    this.Up.payload = this.payload;
                    this.Up.isOccupied = true;

                    this.isOccupied = false;
                    this.payload = null;
                }
            }
        }

        public void ShiftDown()
        {
            if (this.isOccupied && (this.payload.Type != Tile.BlockTypes.GREY))
            {
                if (this.Down != null && !this.Down.isOccupied)
                {
                    this.payload.doAnimate = true;
                    this.Down.payload = this.payload;
                    this.Down.isOccupied = true;

                    this.isOccupied = false;
                    this.payload = null;
                }
            }
        }
    }
}
