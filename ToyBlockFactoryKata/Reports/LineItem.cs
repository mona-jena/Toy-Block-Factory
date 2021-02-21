namespace ToyBlockFactoryKata.Reports
{
    public record LineItem(string Description, int Quantity, decimal Price, decimal Total)
    {
        public override string ToString()
        {
            return $"{Description,-25} {Quantity} @ {Price} ppi = {Total}\n";
        }
    }
}