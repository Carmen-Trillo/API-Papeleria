using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ProductoItem
    {
        public ProductoItem()
        {
            IsActive = true;
            IsPublic = true;
        }
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Marca { get; set; }

        public decimal Precio { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; private set; }
        public bool IsPublic { get; private set; }
     
    }
}

