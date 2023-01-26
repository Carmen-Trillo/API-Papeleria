using Entities.Entities;
using Entities.SearchFilters;

namespace API_Papeleria.IServices
{
    public interface IProductoServices
    {
        List<ProductoItem> GetAllProductos();
        List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter);
        int InsertProducto(ProductoItem productoItem);
    }
}
