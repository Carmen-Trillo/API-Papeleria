using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductoLogic
    {
        List<ProductoItem> GetAllProductos();
        List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter);
        void InsertProductoItem(ProductoItem productoItem);
    }
}
