﻿using Software2.DTO;
using Software2.Repository;
using Software2.SharedMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Services
{
    public class AppointmentService
    {
        string username;

        public AppointmentService(string username)
        {
            this.username = username;
        }

        public appointmentDTO getAppointmentDTOByID(int id)
        {
            var _repo = new CalendarRepository();
            var appointment = _repo.getAppointmentByID(id);
            convertAppointmentTimeToLocalTime(ref appointment);
            var dto = mapDTO(appointment);
            return dto;
        }

        public void updateAppointmentDTO(appointmentDTO dto)
        {
            var _repo = new CalendarRepository();
            string concatTitle = concatTitleFromTypeAndTitle(dto);
            var updatedAppointment = _repo.getAppointmentByID(dto.appointmentID);
            updatedAppointment = mapDTOToAppointment(dto, concatTitle, updatedAppointment);
            updatedAppointment.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            updatedAppointment.start = DateTimeMethods.ConvertToUniversalTime(updatedAppointment.start);
            updatedAppointment.end = DateTimeMethods.ConvertToUniversalTime(updatedAppointment.end);
            updatedAppointment.lastUpdateBy = username;
            _repo.updateAppointment(updatedAppointment);

        }

        public List<appointmentDTO> getAppointmentDTOsByWeek()
        {
            var _repo = new CalendarRepository();
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            Console.WriteLine(weekNum);
            List<appointmentDTO> appointmentDTOs = new List<appointmentDTO>();
            var appointments = _repo.getAppointmentsByWeek(weekNum, username);
            
            for (var i = 0; i <= appointments.Count - 1; i++)
            {
                var appointment = appointments[i];
                convertAppointmentTimeToLocalTime(ref appointment);
                var dto = mapDTO(appointment);
                appointmentDTOs.Add(dto);
            }

            return appointmentDTOs;
        }

        public List<appointmentDTO> getAppointmentDTOsByMonth(int month)
        {
            var _repo = new CalendarRepository();
            var appointments = _repo.getAppointmentsByMonth(month, username);
            List<appointmentDTO> appointmentDTOs = new List<appointmentDTO>();

            for (var i = 0; i <= appointments.Count - 1; i++)
            {
                var appointment = appointments[i];
                convertAppointmentTimeToLocalTime(ref appointment);
                var dto = mapDTO(appointment);
                appointmentDTOs.Add(dto);
            }

            return appointmentDTOs;
        }

        private appointment mapDTOToAppointment(appointmentDTO dto, string concatTitle, appointment appointment)
        {
            appointment.title = concatTitle;
            appointment.appointmentId = dto.appointmentID;
            appointment.contact = dto.contact;
            appointment.customerId = dto.customerId;
            appointment.description = dto.description;
            appointment.end = dto.end;
            appointment.location = dto.location;
            appointment.start = dto.start;
            appointment.url = dto.url;
            return appointment;
        }

        private string concatTitleFromTypeAndTitle(appointmentDTO dto)
        {
            string concat;
            return concat = dto.title + "|" + dto.type;
        }

        public List<appointmentDTO> getAppointmentDTOs()
        {
            var _repo = new CalendarRepository();
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
            var dto = setDTOTitleAndType(a);
            dto.appointmentID = a.appointmentId;
            dto.description = a.description;
            dto.customerName = a.customer.customerName;
            dto.start = a.start.ToLocalTime();
            dto.end = a.end.ToLocalTime();
            dto.location = a.location;
            dto.url = a.url;
            dto.contact = a.contact;
            dto.customerId = a.customerId;
            return dto;
        }

        private appointmentDTO setDTOTitleAndType(appointment appointment)
        {
            string[] splitCharacters = appointment.title.Split('|');
            appointmentDTO dto = new appointmentDTO();
            dto.title = splitCharacters[0];
            dto.type = splitCharacters[1];
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

            var _repo = new CalendarRepository();
            _repo.addAppointment(appointmentToCreate);
        }

        public void addAppointmentDTO(appointmentDTO appointmentDTO)
        {
            string concatTitle = concatTitleFromTypeAndTitle(appointmentDTO);
            var appointment = new appointment();
            appointment = mapDTOToAppointment(appointmentDTO, concatTitle, appointment);

            appointment.createDate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            appointment.lastUpdate = DateTimeMethods.ConvertToUniversalTime(DateTime.Now);
            appointment.start = DateTimeMethods.ConvertToUniversalTime(appointment.start);
            appointment.end = DateTimeMethods.ConvertToUniversalTime(appointment.end);
            appointment.createdBy = username;
            appointment.lastUpdateBy = username;

            var _repo = new CalendarRepository();
            _repo.addAppointment(appointment);
        }

        public void deleteAppointment(int appointmentID)
        {
            var _repo = new CalendarRepository();
            _repo.deleteAppointment(appointmentID);
        }

        public List<AppointmentDate> getAllAppointmentDatesForAUser(string username)
        {
            var _repo = new CalendarRepository();
            var allAppointments = _repo.getAllAppointmentDatesForAUser(username);
            foreach(var a in allAppointments)
            {
                a.Start = a.Start.ToLocalTime();
                a.End = a.End.ToLocalTime();
            }
            return allAppointments;
        }

        public List<appointment> getAllAppointmentsForAUser(string username)
        {
            var _repo = new CalendarRepository();
            var allAppointments = _repo.getallAppointmentsForAUser(username);
            return allAppointments;
        }

        private void convertAppointmentTimeToLocalTime(ref appointment appointment)
        {
            appointment.start = appointment.start.ToLocalTime();
            appointment.end = appointment.end.ToLocalTime();
        }

        public List<appointment> getAllAppointmentsForACustomer(int customerID)
        {
            var _repo = new CalendarRepository();
            var allAppointments = _repo.getAllAppointmentsForACustomer(customerID);
            return allAppointments;
        }

        public appointment getAppointmentByID(int id)
        {
            var _repo = new CalendarRepository();
            var appointment = _repo.getAppointmentByID(id);
            return appointment;
        }

        public List<AppointmentTypeCount> GetAppointmentTypeAndCountByMonth(int month)
        {
            var _repo = new CalendarRepository();
            var appointments = _repo.getAppointmentsByMonth(month, username);

            foreach (var a in appointments)
            {
                string[] typeAndTitle = a.title.Split('|');
                a.title = typeAndTitle[1];
            }

            var appointmentsWithTypeAndCount = appointments.GroupBy(a => a.title)
                .Select(b => new AppointmentTypeCount
                { Type = b.First().title, Count = b.Count() }
                );

            return appointmentsWithTypeAndCount.ToList();
        }

        public appointmentDTO getAppointmentsComingUp()
        {
            var _repo = new CalendarRepository();
            var appointments = _repo.getallAppointmentsForAUser(username);
            var appointment = appointments.Where
                (a => a.start.ToLocalTime().AddMinutes(-15) <= DateTime.Now && a.start.ToLocalTime() > DateTime.Now).FirstOrDefault();

            var dto = new appointmentDTO();
            if(appointment != null)
            {
                dto = mapDTO(appointment);
                return dto;
            }
            
            return null;
        }

        public appointmentDTO getAppointmentsWithin15Minutes()
        {
            var _repo = new CalendarRepository();
            var appointments = _repo.getallAppointmentsForAUser(username);
            var now = DateTime.Now;
            // The following lambda allows me to find an appointment, from the current user logged in, that is coming up in the next 15 minutes.
            // In order to do this, I need to subtract 15 mintues from now which takes into account date, day, hour, minute, seconds, etc.
            var appointment = appointments.Where(
                a => a.start.ToLocalTime().AddMinutes(-15).Subtract(now).Duration().Minutes == TimeSpan.FromMinutes(0).Minutes &&
                a.start.ToLocalTime().AddMinutes(-15).Minute == now.Minute
                ).FirstOrDefault();
            var dto = new appointmentDTO();
            if(appointment != null)
            {
                dto = mapDTO(appointment);
                return dto;
            }
            return null;
        }
    }
}