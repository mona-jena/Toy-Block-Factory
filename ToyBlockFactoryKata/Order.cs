using System.Collections.Generic;

namespace ToyBlockFactoryKata
{
    public class Order
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string DueDate { get; set; }
        public string OrderNumber { get; set; }
        public Dictionary<Block, int> BlockList { get; }
        
        internal Order() 
        {
            BlockList = new Dictionary<Block, int>(new BlockMatcher());
        }

        public void AddBlock(Shape shape, Colour colour)
        {
            var block = new Block(shape, colour);
            if (BlockList.TryGetValue(block, out var blockQuantity))
                BlockList[block] = ++blockQuantity;
            else
                BlockList.Add(block, 1);
        }
    }
}