using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class BlockQue// chosing the nexst Block to appier at the game
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
         
        };
        public BlockQue()
        {
            NextBlock = RandomBlock();
        }
        private readonly Random random = new Random();
        public Block NextBlock { get; private set; }

        private Block RandomBlock() { return blocks[random.Next(blocks.Length)]; }

        public Block GetAndUpDate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);// don't allowing to get the sam block Twice in a row

            return block;
            

        }
        
           
        
    }
}
