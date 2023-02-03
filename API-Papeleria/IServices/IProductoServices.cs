using Entities.Entities;
using Entities.SearchFilters;

namespace API_Papeleria.IServices
{
    public interface IProductoServices
    {
        int InsertProducto(ProductoItem productoItem);
        void UpdateProducto(ProductoItem productoItem);
        void DeleteProducto(int id);
        List<ProductoItem> GetAllProductos();
        List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter);
        List<ProductoItem> GetProductosByMarca(string marca);
    }
}
