using AutoMapper;
using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Interfaces.Services;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using Moq;

namespace Candidato_Banreservas_Test.Cadidato
{
    public class CadidateServiceTest
    {
        public CadidateServiceTest() { }

        [Test]
        public async Task Should_Return_A_Cadidate_List()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mockService = new Mock<IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>>();
            var CandidateList = new List<CandidatoDTO>()
            {
                new CandidatoDTO 
                {
                    Id = new int(), 
                    Nombres = "Jefferson Ramsel", 
                    Apellidos = "De la Cruz Sosa", 
                    CorreoElectronico = "test@email.com",
                    FechaNacimiento = DateTime.Now,
                    PuestoAplicado = "Backend Developer"
                }
            };
            mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(CandidateList);

            //Act
            var result = await mockService.Object.GetAllAsync();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Any(), Is.True);
            });
        }

        [Test]
        public async Task Should_Return_A_Candidate_Entity()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mockService = new Mock<IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>>();
            var Candidate = new CandidatoDTO
            {
                Id = new int(),
                Nombres = "Peteer",
                Apellidos = "De la Cruz Sosa",
                CorreoElectronico = "test@email.com",
                FechaNacimiento = DateTime.Now,
                PuestoAplicado = "Backend Developer"
            };
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(Candidate);

            //Act
            var result = await mockService.Object.GetByIdAsync(new int());

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Apellidos, Has.Length.GreaterThan(6));
            });
        }

        [Test]
        public async Task Should_Create_A_Candidate_And_Return_The_Result()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mockService = new Mock<IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>>();
            var Candidate = new CandidatoDTO
            {
                Id = new int(),
                Nombres = "Andrew",
                Apellidos = "De la Cruz Sosa",
                CorreoElectronico = "test@email.com",
                FechaNacimiento = DateTime.Now,
                PuestoAplicado = "Backend Developer",
            };
            mockService.Setup(x => x.AddAsync(It.IsAny<CandidatoRequest>())).ReturnsAsync(Candidate);

            //Act
            var request = new CandidatoRequest
            {
                Nombres = "Andrew",
                Apellidos = "De la Cruz Sosa",
                CorreoElectronico = "test@email.com",
                FechaNacimiento = DateTime.Now,
                PuestoAplicado = "Backend Developer",
            };
            var result = await mockService.Object.AddAsync(request);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Nombres, Has.Length.GreaterThan(5));
                Assert.That(result.Nombres, Is.EqualTo("Andrew"));
            });
        }
        [Test]
        public async Task Should_Update_A_Candidate_And_Return_The_Result()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mockService = new Mock<IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>>();
            var Candidate = new CandidatoDTO
            {
                Id = new int(),
                Nombres = "Kennidy"
            };
            mockService.Setup(x => x.UpdateServiceAsync(It.IsAny<UpdateCandidatoRequest>()));

            //Act
            var request = new UpdateCandidatoRequest
            {
                Id = new int(),
                Nombres = "name"
            };
            var result = mockService.Object.UpdateServiceAsync(request);
        }

        [Test]
        public async Task Should_Delete_A_Candidate()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mockService = new Mock<IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>>();
            mockService.Setup(x => x.DeleteAsync(It.IsAny<int>() ));

            //Act
            await mockService.Object.DeleteAsync(new int());
        }
    }
}
