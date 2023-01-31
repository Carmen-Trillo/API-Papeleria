namespace API_Papeleria.IServices
{
    public interface ISecurityServices
    {
        bool ValidateUsuarioCredentials(string usuarioUsuario, string usuarioPassWord, int idRol);
    }
}
