using Entities.Entities;
using Logic.ILogic;
using API_Papeleria.IServices;
using Logic.Logic;

namespace API_Papeleria.Services
{
    public class PersonaServices : IPersonaServices
    {
        private readonly IPersonaLogic _personaLogic;
        public PersonaServices(IPersonaLogic personaLogic)
        {
            _personaLogic = personaLogic;
        }


        public int InsertPersona(PersonaItem personaItem)
        {
            _personaLogic.InsertPersona(personaItem);
            return personaItem.Id;
        }


        public void UpdatePersona(PersonaItem personaItem)
        {
            _personaLogic.UpdatePersona(personaItem);
        }

        public void DeletePersona(int id)
        {
            _personaLogic.DeletePersona(id);
        }

        public List<PersonaItem> GetAllPersonas()
        {
            return _personaLogic.GetAllPersonas();
        }



    }
}
