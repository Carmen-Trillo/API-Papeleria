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
    public class PersonaLogic : IPersonaLogic
    {
        private readonly ServiceContext _serviceContext;
        public PersonaLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public int InsertPersona(PersonaItem personaItem)
        {
            _serviceContext.Personas.Add(personaItem);
            _serviceContext.SaveChanges();
            return personaItem.Id;
        }

        public void UpdatePersona(PersonaItem personaItem)
        {
            _serviceContext.Personas.Update(personaItem);

            _serviceContext.SaveChanges();
        }
   
        public void DeletePersona(int id)
        {
            var personaToDelete = _serviceContext.Set<PersonaItem>()
                .Where(u => u.Id == id).First();

            personaToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }


        public List<PersonaItem> GetAllPersonas()
        {
            return _serviceContext.Set<PersonaItem>().ToList();
        }
    }
    
}

