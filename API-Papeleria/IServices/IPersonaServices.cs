using Entities.Entities;
using Entities.SearchFilters;

namespace API_Papeleria.IServices
{
    public interface IPersonaServices
    {
        int InsertPersona(PersonaItem personaItem);
        void UpdatePersona(PersonaItem personaItem);
        void DeletePersona(int id);
        List<PersonaItem> GetAllPersonas();

        //List<PersonaItem> GetPersonaByCriteria(PersonaFilter personaFilter);
    }
}
