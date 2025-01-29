using Hackathon.Core.Models;
using Hackathon.Domain.Services;
using Moq;

namespace Hackathon.Domain.UnitTest
{
    public class AppointmentTest
    {

        [Fact]
        public void CreateContact_ShouldReturnException_WhenStartDateGreaterThanFinishDate()
        {
            // Arrange
            Appointment appointment = new Appointment()
            {
                Title = "Teste Unit�rio",
                Description = "Data incial maior que data final",
                StartAt = new DateTime(2025, 1,  10, 10, 30, 0, 0),
                FinishAt = new DateTime(2025, 1, 10, 10, 0, 0, 0),
                DoctorId = new Guid(),
                PatientId = new Guid()
            };

            var mockRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var appointmentService = new AppointmentServices(mockRepository.Object);

            // Act
            var result = appointmentService.Create(appointment);

            // Asset
            Assert.Equal("A data final deve ser maior que a data inicial", result.Exception.InnerException.Message.ToString());
        }

        [Fact]
        public void CreateContact_ShouldReturnException_WhenDoctorFieldIsEmpty()
        {
            // Arrange
            Appointment appointment = new Appointment()
            {
                Title = "Teste Unit�rio",
                Description = "Sem c�digo do m�dico",
                StartAt = new DateTime(2025, 1, 10, 10, 30, 0, 0),
                FinishAt = new DateTime(2025, 1, 10, 11, 0, 0, 0),                
            };

            var mockRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var appointmentService = new AppointmentServices(mockRepository.Object);

            // Act
            var result = appointmentService.Create(appointment);

            // Asset
            Assert.Equal("O c�digo do m�dico deve ser informado", result.Exception.InnerException.Message.ToString());
        }

        [Fact]  
        public void CreateContact_ShouldReturnException_WhenStartFieldIsEmpty()
        {
            // Arrange
            Appointment appointment = new Appointment()
            {
                Title = "Teste Unit�rio",
                Description = "Sem data incial",
                FinishAt = new DateTime(2025, 1, 10, 11, 0, 0, 0),
                DoctorId = new Guid(),
                PatientId = new Guid()
            };

            var mockRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var appointmentService = new AppointmentServices(mockRepository.Object);

            // Act
            var result = appointmentService.Create(appointment);

            // Asset
            Assert.Equal("Data inicial de atendimento n�o pode ser nula", result.Exception.InnerException.Message.ToString());
        }

        [Fact]
        public void CreateContact_ShouldReturnException_WhenFinishFieldIsEmpty()
        {
            // Arrange
            Appointment appointment = new Appointment()
            {
                Title = "Teste Unit�rio",
                Description = "Sem data final",
                StartAt = new DateTime(2025, 1, 10, 11, 0, 0, 0),
                DoctorId = new Guid(),
                PatientId = new Guid()
            };

            var mockRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var appointmentService = new AppointmentServices(mockRepository.Object);

            // Act
            var result = appointmentService.Create(appointment);

            // Asset
            Assert.Equal("Data final de atendimento n�o pode ser nula", result.Exception.InnerException.Message.ToString());
        }
    }
}