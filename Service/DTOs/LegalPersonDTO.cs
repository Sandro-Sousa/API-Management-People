﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class LegalPersonDTO
    {
        public int LegalPersonId { get; set; }
        public string? CNPJ { get; set; }
        public DateTime OpeningDate { get; set; }
        // Razão Social
        public string? CompanyName { get; set; }
        // Nome Fantasia
        public string? TradingName { get; set; }
        // Status de Cadastral
        public string? RegistrationStatus { get; set; }
        public PeopleDTO? People { get; set; }

        public LegalPersonDTO()
        {
            this.People = new PeopleDTO();
        }
    }
}
