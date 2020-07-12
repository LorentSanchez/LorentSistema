using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Data.Entities
{
    public class Supplier_Classification
    {
        public int Id { get; set; }
        public string  ClasificacionSuplidor { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }

    }
}
