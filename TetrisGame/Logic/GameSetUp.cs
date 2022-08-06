using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class GameSetUp
    {
        private Block currentBlock;
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.ReSetRotate();
                for (int i = 0; i < 2; i++)// make the block show at the start of the canvas
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {   
                        currentBlock.Move(-1,0);

                    }
                }
            }
        }
        public int Score { get;  set; }
        public TheGameGrid GameGrid { get; }
        public BlockQue BlockQue { get; }
        public bool GameOver { get; private set; }

        public GameSetUp()
        {
            GameGrid = new TheGameGrid(24, 10);//size of the Game canvas map
            BlockQue = new BlockQue();
            CurrentBlock = BlockQue.GetAndUpDate();
        }
        private bool BlockFits()
        {
            foreach (Position p in currentBlock.TeilPositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column)) { return false; }// if all the block row and coulm are in the game map space  
            }
            return true;
        }
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())//if the Block can't rotate to the diraction he rotate to the other diraction
            {
                CurrentBlock.RotateCCW();
            }
        }
        public void RotateBlickCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);//moving one space to left
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);// if there is no place to move left so the Block move right
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);//if there is no place to move right so the Block move left
            }
        }
        public bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));//if the row number 0 and 1 are not empty the game is over
        }
        private void PlaceBlook()
        {
            foreach (Position p in CurrentBlock.TeilPositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }
           Score+= GameGrid.ClearAllFullRows();
            if (IsGameOver())
            {
                GameOver = true;
            }
            else//if the game is not end renew the block
            {
                CurrentBlock = BlockQue.GetAndUpDate();
            }
        }
        public void MoveBlockDown()//this function is in charge of moving the blocks down by the user
        {
        
            CurrentBlock.Move(1, 0);
            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlook();
            }
        }
    }
}
