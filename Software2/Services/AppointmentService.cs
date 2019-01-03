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
            return _repo.getAppointmentByID(id);
        }

        public void updateAppointment(appointment updatedAppointment)
        {
            updatedAppointment.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            updatedAppointment.lastUpdateBy = username;

            _repo.updateAppointment(updatedAppointment);
        }

        public List<appointmentDTO> getAppointmentDTOs()
        {
            var appointments = _repo.getAppointments();
            List<appointmentDTO> appointmentDTOs = new List<appointmentDTO>();
            foreach (var a in appointments)
            {
                var dto = mapDTO(a);
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
            return _repo.getAllAppointmentDatesForAUser(username);
        }
    }
}