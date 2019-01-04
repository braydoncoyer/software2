using Software2.DTO;
using Software2.Repository;
using Software2.SharedMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AppointmentService
    {
        CalendarRepository _repo = new CalendarRepository();
        string username;

        public AppointmentService(string username)
        {
            this.username = username;
        }

        public appointment getAppointmentByID(int id)
        {
            var appointment = _repo.getAppointmentByID(id);
            convertAppointmentTimeToLocalTime(ref appointment);
            return appointment;
        }

        public void updateAppointment(appointment updatedAppointment)
        {
            updatedAppointment.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            updatedAppointment.start = DateTimeMethods.ConvertToUniversalTime(updatedAppointment.start);
            updatedAppointment.end = DateTimeMethods.ConvertToUniversalTime(updatedAppointment.end);
            updatedAppointment.lastUpdateBy = username;

            _repo.updateAppointment(updatedAppointment);
        }

        public List<appointmentDTO> getAppointmentDTOs()
        {
            var appointments = _repo.getAppointments();
            List<appointmentDTO> appointmentDTOs = new List<appointmentDTO>();

            for(var i = 0; i <= appointments.Count-1; i++)
            {
                var appointment = appointments[i];
                convertAppointmentTimeToLocalTime(ref appointment);
                var dto = mapDTO(appointment);
                appointmentDTOs.Add(dto);
            }
            
            return appointmentDTOs;
        }

        public appointmentDTO mapDTO(appointment a)
        {
            var dto = new appointmentDTO();
            dto.appointmentID = a.appointmentId;
            dto.title = a.title;
            dto.description = a.description;
            dto.customerName = a.customer.customerName;
            dto.start = a.start;
            dto.end = a.end;
            dto.location = a.location;
            return dto;
        }

        public void addAppointment(appointment appointmentToCreate)
        {
            appointmentToCreate.createDate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            appointmentToCreate.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            appointmentToCreate.start = DateTimeMethods.ConvertToUniversalTime(appointmentToCreate.start);
            appointmentToCreate.end = DateTimeMethods.ConvertToUniversalTime(appointmentToCreate.end);
            appointmentToCreate.createdBy = username;
            appointmentToCreate.lastUpdateBy = username;

            _repo.addAppointment(appointmentToCreate);
        }

        public void deleteAppointment(int appointmentID)
        {
            _repo.deleteAppointment(appointmentID);
        }

        public List<AppointmentDate> getAllAppointmentDatesForAUser(string username)
        {
            var allAppointments = _repo.getAllAppointmentDatesForAUser(username);
            foreach(var a in allAppointments)
            {
                a.Start = a.Start.ToLocalTime();
                a.End = a.End.ToLocalTime();
            }
            return allAppointments;
        }

        private void convertAppointmentTimeToLocalTime(ref appointment appointment)
        {
            appointment.start = appointment.start.ToLocalTime();
            appointment.end = appointment.end.ToLocalTime();
        }
    }
}