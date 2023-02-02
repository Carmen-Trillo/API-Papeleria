using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class TipoClienteLogic : ITipoClienteLogic
    {
        private readonly ServiceContext _serviceContext;
        public TipoClienteLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertTipoCliente(TipoClienteItem tipoClienteItem)
        {
            _serviceContext.TiposClientes.Add(tipoClienteItem);
            _serviceContext.SaveChanges();
            return tipoClienteItem.Id;
        }

        public void UpdateTipoCliente(TipoClienteItem tipoClienteItem)
        {
            _serviceContext.TiposClientes.Update(tipoClienteItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteTipoCliente(int id)
        {
            var tipoClienteToDelete = _serviceContext.Set<TipoClienteItem>()
                .Where(u => u.Id == id).First();

            tipoClienteToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<TipoClienteItem> GetAllTiposClientes()
        {
            return _serviceContext.Set<TipoClienteItem>().ToList();
        }
    }
}
