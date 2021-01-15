using System;

namespace ToyBlockFactoryKata
{
    public class Block : IEquatable<Block>
    {
        public Block(Shape shape, Colour colour)
        {
            Shape = shape;
            Colour = colour;
        }

        private Colour Colour { get; }
        private Shape Shape { get; }

        public bool Equals(Block other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Colour == other.Colour && Shape == other.Shape;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Block) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Colour, (int) Shape);
        }
    }
}