# SquaredAway

### How to play
Use the arrow keys to move the squares around. Grey squares don't move. Make a bigger square out of the blue smaller ones too win.

### How to make levels
Open the LevelData.xml file that is in the same directory as the .exe.
* The top level element has an integer to count the total number of levels. Be sure this is the correct value.

* Each level has a name and a size. The size determines how many tiles are on one length of the square.
A size of 4 means 16 tiles.

*The contents of each level element has a list of integers from 0 to 5.
0. - An empty space
1. - A blue tile(the win condition)
2. - A green tile
3. - A yellow tile
4. - A red tile
5. - A grey tile(these don't move)


