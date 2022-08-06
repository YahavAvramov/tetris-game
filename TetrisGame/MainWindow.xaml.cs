using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace TetrisGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly int maxDelay = 800;
        public readonly int minDelay = 120;
        public readonly int DelayIncrese = 15;
        public readonly ImageSource[] images = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),//empty
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),//kind of blue
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),//blue
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),//orange
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),//yellow
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),//green
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),//purple
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),//red
        };
        private ImageSource[] blocksImage = new ImageSource[]
        {
         new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),//empty
         new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),//I block
         new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),//J block
         new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),//L block
         new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),// O block
         new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),// s block
         new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),// T block
         new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative)),// Z block
        };

        private readonly Image[,] imageControle;

        private GameSetUp gameSet = new GameSetUp();

        public MainWindow()
        {
            InitializeComponent();
            imageControle = SetUpGameCanvas(gameSet.GameGrid);//giving the image arry its location 
        }
        private Image[,] SetUpGameCanvas(TheGameGrid grid)
        {
            Image[,] images = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;//game map pixels/number of cells
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControle = new Image
                    {
                        Width = cellSize,
                        Height = cellSize,
                    };//creat a new cell in the [r,c] position 
                    Canvas.SetTop(imageControle, (r - 4) * cellSize + 35);// the rows in place 0 is out of the canvas, therfore it won't being seen
                    Canvas.SetLeft(imageControle, c * cellSize);
                    GameCanvas.Children.Add(imageControle);
                    images[r, c] = imageControle;
                }

            }
            return images;
        }

        private void DrawGrid(TheGameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)//for each position 
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControle[r, c].Source = images[id];
                }
            }

        }
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TeilPositions())
            {
                imageControle[p.Row, p.Column].Source = images[block.Id];
            }
        }

        private void DrawNextBlock(BlockQue blockQue)
        {
            Block next = blockQue.NextBlock;
            NextImage.Source = blocksImage[next.Id];

        }
        private void Draw(GameSetUp gameSetUp)
        {
            DrawGrid(gameSet.GameGrid);
            DrawBlock(gameSet.CurrentBlock);
            DrawNextBlock(gameSet.BlockQue);
            ScoreText.Text = $"score: {gameSet.Score}";
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameSet.GameOver) { return; }
            switch (e.Key)
            {
                case Key.Left:
                    gameSet.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameSet.MoveBlockRight();
                    break;
                case Key.Down:
                    gameSet.MoveBlockDown();
                    break;
                case Key.Up:
                    gameSet.RotateBlockCW();
                    break;
                case Key.Z:
                    gameSet.RotateBlickCCW();
                    break;
                case Key.Q:
                    gameSet.Score += 10;
                    break;
                default:
                    return;
            }
            Draw(gameSet);
        }
        private async Task GameLoop()//this function is what moving the blocks down with the time spaned
        {
            Draw(gameSet);
            while (!gameSet.GameOver)
            {
                int delay = Math.Max(minDelay , maxDelay -(gameSet.Score*DelayIncrese));//cano't be less then the min value delay , evry score you get the game become faster
                await Task.Delay(delay);
                gameSet.MoveBlockDown();
                Draw(gameSet);
            }
            GameOverMenu.Visibility = Visibility.Visible; //we get to here only if we break the lop by game over, this show the game over menu
            FinalScoreText.Text = $"you'r Score {gameSet.Score}";
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
             await GameLoop();
        }

        private async void PlayAginClick(object sender, RoutedEventArgs e)
        {
            gameSet = new GameSetUp();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }
    }
}
