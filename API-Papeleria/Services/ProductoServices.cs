using API_Papeleria.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;

    public class ProductoServices : IProductoServices
    {
    private readonly IProductoLogic _productoLogic;
    public ProductoServices(IProductoLogic productoLogic)
    {
        _productoLogic = productoLogic;
    }
    public int InsertProducto(ProductoItem productoItem)
    {
        _productoLogic.InsertProducto(productoItem);
        return productoItem.Id;
    }
    public List<ProductoItem> GetAllProductos()
    {
        return _productoLogic.GetAllProductos();
    }
    public List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter)
    {
        return _productoLogic.GetProductosByCriteria(productoFilter);
    }

    public void UpdateProducto(ProductoItem productoItem)
    {
        _productoLogic.UpdateProducto(productoItem);
    }

    public void DeleteProducto(int id)
    {
        _productoLogic.DeleteProducto(id);
    }
}

