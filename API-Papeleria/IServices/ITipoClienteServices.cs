using Entities.Entities;

namespace API_Papeleria.IServices
{
    public interface ITipoClienteServices
    {
        int InsertTipoCliente(TipoClienteItem tipoClienteItem);
        void UpdateTipoCliente(TipoClienteItem tipoClienteItem);
        void DeleteTipoCliente(int id);
        List<TipoClienteItem> GetAllTiposClientes();
    }
}
