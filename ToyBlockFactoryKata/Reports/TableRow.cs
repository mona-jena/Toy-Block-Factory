using System.Collections.Generic;
using ToyBlockFactoryKata.Orders;

namespace ToyBlockFactoryKata.Reports
{
    public record TableRow(Shape Shape, List<TableColumn> TableColumn)
    {
        public override string ToString()
        {
            return $"{Shape,-8} |{string.Join(" | ", TableColumn)}";
        }
    }
}