using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SearchFilters
{
    public class ProductoFilter
    {
        public bool IsActive { get; set; }
        public DateTime InsertDateFrom { get; set; }
        public DateTime InsertDateTo { get; set; }
        public decimal PrecioDesde { get; set; }
        public decimal PrecioHasta { get; set; }
    }
}
