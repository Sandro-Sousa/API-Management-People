using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LegalPerson
    {
        public int IdLegalPerson { get; set; }
        public string? CNPJ { get; set; }
        public DateTime OpeningDate { get; set; }
        // Razão Social
        public string? CompanyName { get; set; }
        // Nome Fantasia
        public string? TradingName { get; set; }
        // Status de Cadastral
        public string? RegistrationStatus { get; set; }
        public People People { get; set; }

        public LegalPerson()
        {
            People = new People();
        }
    }
}
