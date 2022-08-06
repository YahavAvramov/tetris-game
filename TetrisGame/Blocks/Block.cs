using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position startOffGameMap { get; }
        public abstract int Id { get; }
        private int rotationState;
        private Position offSet;

        public Block()
        {
            offSet = new Position(startOffGameMap.Row, startOffGameMap.Column);
        }
        public IEnumerable<Position> TeilPositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offSet.Row, p.Column + offSet.Column);
            }
        }
        public void RotateCW()
        {
            rotationState = (rotationState +1)%Tiles.Length;
        }
        public void RotateCCW()
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        public void Move(int rowsToMove , int columToMove)
        {
            offSet.Row += rowsToMove;
            offSet.Column += columToMove;
        }
        public void ReSetRotate()
        {
            rotationState = 0;
            offSet.Row = startOffGameMap.Row;
            offSet.Column = startOffGameMap.Column;
        }
    }
}
