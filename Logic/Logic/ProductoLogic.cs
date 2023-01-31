using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;

namespace Logic.Logic
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly ServiceContext _serviceContext;
        public ProductoLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public int InsertProducto(ProductoItem productoItem)
        {
            _serviceContext.Productos.Add(productoItem);
            _serviceContext.SaveChanges();
            return productoItem.Id;
        }

        public void UpdateProducto(ProductoItem productoItem)
        {
            _serviceContext.Productos.Update(productoItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteProducto(int id)
        {
            var productoToDelete = _serviceContext.Set<ProductoItem>()
                 .Where(u => u.Id == id).First();

            productoToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public void DeleteProductoMarca(string Marca)
        {
            var productoMarcaToDelete = _serviceContext.Set<ProductoItem>()
                 .Where(u => u.Marca == Marca).First();

            productoMarcaToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<ProductoItem> GetAllProductos()
        {
            return _serviceContext.Set<ProductoItem>().ToList();
        }

        public List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter)
        {
            var resultList = _serviceContext.Set<ProductoItem>()
                                        .Where(u => u.IsActive == true);

            //.Where(u => u.Marca = productoFilter.Marca);

            if (productoFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > productoFilter.InsertDateFrom);
            }

            if (productoFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < productoFilter.InsertDateTo);
            }
            if (productoFilter.PrecioDesde != null)
            {
                resultList = resultList.Where(u => u.Precio > productoFilter.PrecioDesde);
            }

            if (productoFilter.PrecioHasta != null)
            {
                resultList = resultList.Where(u => u.Precio < productoFilter.PrecioHasta);
            }

            return resultList.ToList();
        }


        
    }
}

