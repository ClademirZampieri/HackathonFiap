using Hackathon.Core.DTO;
using Hackathon.Core.Models;
using Hackathon.Domain.Services;
using MassTransit;
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

            var emailSettings = new EmailMessageSettings() { 
                Body = "<html><head><meta charset='UTF-8'><title>Notifica��o de Consulta</title></head><body style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'><p>Ol�, Dr. <strong>{nome_do_m�dico}</strong>!</p><p>Voc� tem uma <strong>nova consulta marcada!</strong></p><p><strong>Paciente:</strong> {nome_do_paciente}</p><p><strong>Data e hor�rio:</strong> {data} �s {hor�rio_agendado}</p><br><p>Atenciosamente,</p><p><em>Sua Cl�nica</em></p></body></html>", 
                Subject = "Health&Med - Nova consulta agendada"
            };

            var mockAppointmentRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var mockUserRepository = new Mock<Hackathon.Data.Interfaces.IUserRepository>();
            var mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var appointmentService = new AppointmentServices(mockAppointmentRepository.Object, mockPublishEndpoint.Object, mockUserRepository.Object, emailSettings);

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

            var emailSettings = new EmailMessageSettings()
            {
                Body = "<html><head><meta charset='UTF-8'><title>Notifica��o de Consulta</title></head><body style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'><p>Ol�, Dr. <strong>{nome_do_m�dico}</strong>!</p><p>Voc� tem uma <strong>nova consulta marcada!</strong></p><p><strong>Paciente:</strong> {nome_do_paciente}</p><p><strong>Data e hor�rio:</strong> {data} �s {hor�rio_agendado}</p><br><p>Atenciosamente,</p><p><em>Sua Cl�nica</em></p></body></html>",
                Subject = "Health&Med - Nova consulta agendada"
            };

            var mockAppointmentRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var mockUserRepository = new Mock<Hackathon.Data.Interfaces.IUserRepository>();
            var mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var appointmentService = new AppointmentServices(mockAppointmentRepository.Object, mockPublishEndpoint.Object, mockUserRepository.Object, emailSettings);

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
            
            var emailSettings = new EmailMessageSettings()
            {
                Body = "<html><head><meta charset='UTF-8'><title>Notifica��o de Consulta</title></head><body style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'><p>Ol�, Dr. <strong>{nome_do_m�dico}</strong>!</p><p>Voc� tem uma <strong>nova consulta marcada!</strong></p><p><strong>Paciente:</strong> {nome_do_paciente}</p><p><strong>Data e hor�rio:</strong> {data} �s {hor�rio_agendado}</p><br><p>Atenciosamente,</p><p><em>Sua Cl�nica</em></p></body></html>",
                Subject = "Health&Med - Nova consulta agendada"
            };

            var mockAppointmentRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var mockUserRepository = new Mock<Hackathon.Data.Interfaces.IUserRepository>();
            var mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var appointmentService = new AppointmentServices(mockAppointmentRepository.Object, mockPublishEndpoint.Object, mockUserRepository.Object, emailSettings);

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

            var emailSettings = new EmailMessageSettings()
            {
                Body = "<html><head><meta charset='UTF-8'><title>Notifica��o de Consulta</title></head><body style='font-family: Arial, sans-serif; font-size: 16px; color: #333;'><p>Ol�, Dr. <strong>{nome_do_m�dico}</strong>!</p><p>Voc� tem uma <strong>nova consulta marcada!</strong></p><p><strong>Paciente:</strong> {nome_do_paciente}</p><p><strong>Data e hor�rio:</strong> {data} �s {hor�rio_agendado}</p><br><p>Atenciosamente,</p><p><em>Sua Cl�nica</em></p></body></html>",
                Subject = "Health&Med - Nova consulta agendada"
            };

            var mockAppointmentRepository = new Mock<Hackathon.Data.Interfaces.IAppointmentRepository>();
            var mockUserRepository = new Mock<Hackathon.Data.Interfaces.IUserRepository>();
            var mockPublishEndpoint = new Mock<IPublishEndpoint>();
            var appointmentService = new AppointmentServices(mockAppointmentRepository.Object, mockPublishEndpoint.Object, mockUserRepository.Object, emailSettings);

            // Act
            var result = appointmentService.Create(appointment);

            // Asset
            Assert.Equal("Data final de atendimento n�o pode ser nula", result.Exception.InnerException.Message.ToString());
        }
    }
}