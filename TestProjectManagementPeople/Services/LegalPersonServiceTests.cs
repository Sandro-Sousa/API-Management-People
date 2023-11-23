using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Repository.Interfaces;
using Service.DTOs;
using Service.Services;

namespace TestProjectManagementPeople.Services
{
    public class LegalPersonServiceTests
    {
        private LegalPersonService legalPersonService;

        public LegalPersonServiceTests()
        {
            legalPersonService = new LegalPersonService(new Mock<IMapper>().Object, new Mock<ILegalPersonRepository>().Object, new Mock<IPeopleRepository>().Object);
        }

        [Fact]
        public void GetAllLegalPerson()
        {
            var result = legalPersonService.GetAllLegalPerson();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetLegalPersonById()
        {
            var result = legalPersonService.GetLegalPersonById(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void InsertLegalPerson()
        {
            var result = legalPersonService.InsertLegalPerson(new LegalPersonDTO
            {
                CNPJ = "123456789",
                OpeningDate = DateTime.Now,
                CompanyName = "Teste Ltda",
                TradingName = "Teste",
                RegistrationStatus = "Active",
                People = new PeopleDTO
                {
                    Name = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Phone = "1234567890",
                    Address = "123 Main Street",
                    City = "TestCity",
                    State = "TS",
                    Country = "TestCountry",
                    ZipCode = "12345",
                    Age = 30,
                }
            });

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateLegalPerson()
        {
            var result = legalPersonService.UpdateLegalPerson(new LegalPersonDTO
            {
                LegalPersonId = 1,
                CNPJ = "123456789",
                OpeningDate = DateTime.Now,
                CompanyName = "Teste Ltda",
                TradingName = "Teste",
                RegistrationStatus = "Teste"
            });

            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteLegalPerson()
        {
            var result = legalPersonService.DeleteLegalPerson(1);

            Assert.NotNull(result);
        }
    }
}
