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
        int InsertProducto(ProductoItem productoItem);
        void UpdateProducto(ProductoItem productoItem);
        void DeleteProducto(int id);
        void DeleteProductoMarca(string Marca);
        List<ProductoItem> GetAllProductos();
        List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter);
    }
}
