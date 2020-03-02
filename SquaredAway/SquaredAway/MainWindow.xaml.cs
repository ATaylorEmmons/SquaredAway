using SquaredAway.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SquaredAway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        const string levelLocation = "LevelData.xml";
        Level currentLevel;

        float tileSize = 0.0f;
        List<Tile> tiles;

        int shifts = 0;


        enum AnimationStates
        {
            CAN_ANIMATE,
            IS_ANIMATING,
            WON_LEVEL
        }

        AnimationStates boardState;

        //These numbers "feel good" to play at
       
        int animationDuration = 50; //Milliseconds
        int maxFrames = 100;
        int currentFrame = 0;
        DispatcherTimer animationTimer;


        Direction animationDirection;


        Code.Grid grid;

        SolidColorBrush[] TileColors = new SolidColorBrush[6]
        {
            Brushes.Transparent,
            Brushes.DeepSkyBlue,
            Brushes.LightGreen,
            Brushes.PaleGoldenrod,
            Brushes.PaleVioletRed,
            Brushes.Gainsboro
        };

        public MainWindow()
        {
            InitializeComponent();

            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyDownEvent, new KeyEventHandler(KeyUp), true);

            Initilize();
            
        }


        private void Initilize()
        {

            boardState = AnimationStates.CAN_ANIMATE;

            animationTimer = new DispatcherTimer();
            animationTimer.Tick += AnimationDispatch;
            animationTimer.Interval = TimeSpan.FromMilliseconds(animationDuration / maxFrames);

            LevelManager.Initilize(levelLocation);
           
            foreach(Level l in LevelManager.Levels)
            {
                Button button = new Button();
                button.Content = l.Name;
                button.Height = 50;
                button.Margin = new Thickness(0, 10, 0, 10);
                button.Click += LevelSelect_Click;
                stackPanel_Levels.Children.Add(button);
            }

            this.LoadLevel(LevelManager.Levels[LevelManager.LastLevelPlayed]);
        }

   

        private void StartAnimation()
        {
            boardState = AnimationStates.IS_ANIMATING;

            animationTimer.Start();
        }

        private void AnimationDispatch(object sender, EventArgs e)
        {
            if(currentFrame < maxFrames)
            {
                currentFrame++;
                AnimationFrame();
            } else if(currentFrame == maxFrames)
            {
                StopAnimation();
            }
        }


        private void StopAnimation()
        {

            boardState = AnimationStates.CAN_ANIMATE;

            animationTimer.Stop();

            currentFrame = 0;

            foreach (Tile t in this.tiles)
            {
                t.doAnimate = false;
            }

            label_PlayerShifts.Content = "Shifts: " + shifts;

            if (grid.CheckForWin() )
            {
                WonGame();
            }
        }

        private void WonGame()
        {
            label_PlayerShifts.Content = "Won with: " + shifts + " shifts!";
        }

        private void AnimationFrame()
        {

            float movementStep = tileSize / maxFrames;

            foreach (Tile t in this.tiles)
            {
                if (t.doAnimate)
                {
                    if (animationDirection == Direction.RIGHT)
                    {
                        Canvas.SetLeft(t.Rectangle, Canvas.GetLeft(t.Rectangle) + movementStep);
                       
                    }
                    else if (animationDirection == Direction.LEFT)
                    {
                        Canvas.SetLeft(t.Rectangle, Canvas.GetLeft(t.Rectangle) - movementStep);
                        
                    }
                    else if (animationDirection == Direction.UP)
                    {
                        Canvas.SetTop(t.Rectangle, Canvas.GetTop(t.Rectangle) - movementStep);
                        
                    }
                    else if (animationDirection == Direction.DOWN)
                    {
                        Canvas.SetTop(t.Rectangle, Canvas.GetTop(t.Rectangle) + movementStep);
                        
                    }
                    else
                    {
                        //invalid direction
                    }

                }
            }
        }



        private new void KeyUp(object sender, KeyEventArgs e)
        {
            if (boardState == AnimationStates.CAN_ANIMATE)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        this.shifts++;
                        this.animationDirection = Direction.UP;
                        grid.ShiftUp();
                        StartAnimation();
                        break;
                    case Key.Down:
                        this.shifts++;
                        this.animationDirection = Direction.DOWN;
                        grid.ShiftDown();
                        StartAnimation();
                        break;
                    case Key.Left:
                        this.shifts++;
                        this.animationDirection = Direction.LEFT;
                        grid.ShiftLeft();
                        StartAnimation();
                        break;
                    case Key.Right:
                        this.shifts++;
                        this.animationDirection = Direction.RIGHT;
                        grid.ShiftRight();
                        StartAnimation();
                        break;
                }
            }
        }

        private void LoadLevel(Level level)
        {

            this.currentLevel = level;
            canvas_Board.Children.Clear();
            tiles = new List<Tile>();
            this.shifts = 0;

            label_LevelName.Content = level.Name;
            label_PlayerShifts.Content = "Shifts: " + this.shifts;

            this.grid = new Code.Grid(level.GridSize);


            //canvas_Board.Width should always == canvas_Board.Height 
            tileSize = (float)canvas_Board.Width / (float)level.GridSize;

            for (int i = 0; i < level.GridSize; i++)
            {
                for (int j = 0; j < level.GridSize; j++)
                {
                    SpawnTile(level.TileData[i, j], i, j);
                }
            }

        }


        private void SpawnTile(int mapTileInt, int i, int j)
        {
            Tile.BlockTypes types = Tile.BlockTypes.TRANSPARENT;
            Rectangle r;

            switch (mapTileInt)
            {

                case 0:
                    //Space tile. do nothing
                    return;
                case 1:
                    types = Tile.BlockTypes.BLUE;
                    break;
                case 2:
                    types = Tile.BlockTypes.GREEN;
                    break;
                case 3:
                    types = Tile.BlockTypes.YELLOW;
                    break;
                case 4:
                    types = Tile.BlockTypes.RED;
                    break;
                case 5:
                    types = Tile.BlockTypes.GREY;
                    break;
            }

           
            r = new Rectangle();
            r.Fill = TileColors[(int)types];
            r.Width = tileSize;
            r.Height = tileSize;

            Canvas.SetLeft(r, j * tileSize);
            Canvas.SetTop(r, i * tileSize);


            canvas_Board.Children.Add(r);

            Tile t = new Tile(r, types, tileSize);
            tiles.Add(t);
            grid.setTile(t, i, j);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            this.LoadLevel(this.currentLevel);
        }

        private void LevelSelect_Click(object sender, RoutedEventArgs e)
        {
            Button clickee = (Button)sender;
            this.LoadLevel(LevelManager.GetLevelFromName(clickee.Content.ToString()));
        }
    }
}
