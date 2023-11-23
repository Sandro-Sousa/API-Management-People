using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class NaturalPersonDTO
    {
        public int IdNaturalPerson { get; set; }
        public string? CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public PeopleDTO? People { get; set; }
    }
}
