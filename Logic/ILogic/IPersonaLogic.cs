using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPersonaLogic
    {
        int InsertPersona(PersonaItem personaItem);
        void UpdatePersona(PersonaItem personaItem);
        void DeletePersona(int id);
        List<PersonaItem> GetAllPersonas();
    }
}
