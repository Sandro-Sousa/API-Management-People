using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class NaturalPerson
    {
        public int IdNaturalPerson { get; set; }
        public string? CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public People People { get; set; }

        public NaturalPerson()
        {
            this.People = new People();
        }
    }
}
