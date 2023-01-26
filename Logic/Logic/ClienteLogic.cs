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
    public class ClienteLogic : BaseContextLogic, IClienteLogic
    {
        public ClienteLogic(ServiceContext serviceContext) : base(serviceContext) { }
        public void InsertClienteItem(ClienteItem clienteItem)
        {
            _serviceContext.Clientes.Add(clienteItem);
            _serviceContext.SaveChanges();
        }
    }
}
