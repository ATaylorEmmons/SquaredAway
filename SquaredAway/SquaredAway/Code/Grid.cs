using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredAway.Code
{
    public class Grid
    {
        private TileNode[,] nodes;
        private int size;

       
        public Grid(int size)
        {
            this.nodes = new TileNode[size, size];

            this.size = size;
            this.connect();
        }

        private void connect()
        {

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    //Create all of the nodes
                    this.nodes[i, j] = new TileNode();
                }
            }

            //connect the nodes to their neighbors

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if (j > 0)
                    {
                        this.nodes[i, j].Left = this.nodes[i, j - 1];
                    }

                    if(j < size - 1)
                    {
                        this.nodes[i, j].Right = this.nodes[i, j + 1];
                    }

                    if(i > 0)
                    {
                        this.nodes[i, j].Up = this.nodes[i - 1, j];
                    }

                    if(i < size - 1)
                    {
                        this.nodes[i, j].Down = this.nodes[i + 1, j];
                    }
                }
            }
        }

        public void setTile(Tile tile, int i, int j)
        {
            this.nodes[i, j].setTile(tile);
        }


        /*
         * The order that the nodes are iterated through matters
         * otherwise blocks that havn't moved yet may prevent neighboring
         * blocks from moving that should be moving.
         */
         
        public void ShiftLeft()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.nodes[i, j].ShiftLeft();
                }
            }
        }

        public void ShiftRight()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = this.size - 1; j >= 0; j--)
                {
                    this.nodes[i, j].ShiftRight();
                }
            }
        }

        public void ShiftUp()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.nodes[i, j].ShiftUp();
                }
            }
        }

        public void ShiftDown()
        {
            for (int i = this.size - 1; i >= 0; i--)
            {
                for (int j = 0; j < this.size; j++)
                {
                    this.nodes[i, j].ShiftDown();
                }
            }
        }

        public bool CheckForWin()
        {
            // We don't need to check the right most or lower most
            // nodes to make a square
            for (int i = 0; i < this.size - 1; i++)
            {
                for (int j = 0; j < this.size - 1; j++)
                {
                    TileNode n = this.nodes[i, j];
                    if (n.isOccupied && n.Right.isOccupied && n.Right.Down.isOccupied && n.Down.isOccupied)
                    {

                        int a = (int)n.payload.Type;
                        int b = (int)n.Right.payload.Type;
                        int c = (int)n.Right.Down.payload.Type;
                        int d = (int)n.Down.payload.Type;

                        //The sum of the ids of Blue Squares is 4
                        // any other sum of ids cannot be 4
                        if ((a + b + c + d) == 4)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

      
    }
}
