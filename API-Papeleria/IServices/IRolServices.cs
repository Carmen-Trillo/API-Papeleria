using Entities.Entities;

namespace API_Papeleria.IServices
{
    public interface IRolServices
    {
        int InsertRol(RolItem rolItem);
        void UpdateRol(RolItem rolItem);
        void DeleteRol(int id);
        List<RolItem> GetAllRoles();
    }
}
