namespace ToyBlockFactoryKata.Reports
{
    public record TableColumn(string MeasuredItem, int Quantity)
    {
        public override string ToString()
        {
            return $"{Quantity,7}";
        }
    }
}