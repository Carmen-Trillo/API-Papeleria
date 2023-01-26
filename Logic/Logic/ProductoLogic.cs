using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductoLogic : BaseContextLogic, IProductoLogic
    {
        public ProductoLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public List<ProductoItem> GetAllProductos()
        {
            return _serviceContext.Set<ProductoItem>().ToList();
        }

        public List<ProductoItem> GetProductosByCriteria(ProductoFilter productoFilter)
        {
            //ejemplo para IsActive solamente
            return _serviceContext.Set<ProductoItem>()
                .Where(p => p.IsActive == productoFilter.IsActive)
            .ToList();
        }

        public void InsertProductoItem(ProductoItem productoItem)
        {
            _serviceContext.Productos.Add(productoItem);
            _serviceContext.SaveChanges();
        }
    }
}

