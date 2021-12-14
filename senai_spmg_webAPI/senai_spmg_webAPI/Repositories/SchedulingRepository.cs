using Microsoft.EntityFrameworkCore;
using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class SchedulingRepository : ISchedulingRepository
    {
        readonly SPMGContext context = new();
        public void ChangeSituation(int idScheduling, string situation)
        {
            Scheduling searchScheduling = context.Schedulings
                .FirstOrDefault(s => s.IdScheduling == idScheduling);

            switch (situation)
            {
                case "1":
                    searchScheduling.IdSituation = 1;
                    break;

                case "2":
                    searchScheduling.IdSituation = 2;
                    break;

                case "3":
                    searchScheduling.IdSituation = 3;
                    break;

                default:
                    searchScheduling.IdSituation = searchScheduling.IdSituation;
                    break;
            }

            context.Schedulings.Update(searchScheduling);

            context.SaveChanges();
        }

        public void Create(Scheduling newScheduling)
        {
            context.Schedulings.Add(newScheduling);

            context.SaveChanges();
        }

        public void Delete(int idScheduling)
        {
            context.Schedulings.Remove(SearchByID(idScheduling));

            context.SaveChanges();
        }

        public List<Scheduling> ReadAll()
        {
            return context.Schedulings
                 .Select(s => new Scheduling
                 {
                     IdScheduling = s.IdScheduling,
                     IdPatientNavigation = new Patient()
                     {
                         PatientName = s.IdPatientNavigation.PatientName,
                     },
                     IdMedicNavigation = new Medic()
                     {
                         MedicName = s.IdMedicNavigation.MedicName,
                         MedicLastname = s.IdMedicNavigation.MedicLastname,
                     },
                     SchedulingDateHour = s.SchedulingDateHour,
                     IdSituationNavigation = new Situation()
                     {
                         SituationDescription = s.IdSituationNavigation.SituationDescription
                     },
                 })
                 .OrderBy(s => s.SchedulingDateHour)
                 .ToList();
        }

        public List<Scheduling> ReadMine(int idUser, int UserType)
        {

            if (UserType == 2)
            {
                Medic medic = context.Medics.FirstOrDefault(u => u.IdUser == idUser);

                int idMedic = medic.IdMedic;

                return context.Schedulings
                                .Where(s => s.IdMedic == idMedic)
                                .AsNoTracking()
                                .Select(s => new Scheduling()
                                {
                                    SchedulingDateHour = s.SchedulingDateHour,
                                    IdScheduling = s.IdScheduling,
                                    IdMedicNavigation = new Medic()
                                    {
                                        Crm = s.IdMedicNavigation.Crm,
                                        IdUserNavigation = new User()
                                        {
                                            Email = s.IdMedicNavigation.IdUserNavigation.Email
                                        }
                                    },
                                    IdPatientNavigation = new Patient()
                                    {
                                        Cpf = s.IdPatientNavigation.Cpf,
                                        DddPhone = s.IdPatientNavigation.DddPhone,
                                        PhoneNumber = s.IdPatientNavigation.PhoneNumber,
                                        IdUserNavigation = new User()
                                        {
                                            Email = s.IdPatientNavigation.IdUserNavigation.Email
                                        }
                                    },
                                    IdSituationNavigation = new Situation()
                                    {
                                        SituationDescription = s.IdSituationNavigation.SituationDescription
                                    }


                                })
                                .ToList();
            }
            else if (UserType == 3)
            {
                Patient patient = context.Patients.FirstOrDefault(p => p.IdUser == idUser);

                int idPatient = patient.IdPatient;
                return context.Schedulings
                                .Where(s => s.IdScheduling == idPatient)
                                .AsNoTracking()
                                .Select(s => new Scheduling()
                                {
                                    SchedulingDateHour = s.SchedulingDateHour,
                                    IdScheduling = s.IdScheduling,
                                    IdMedicNavigation = new Medic()
                                    {
                                        Crm = s.IdMedicNavigation.Crm,
                                        IdUserNavigation = new User()
                                        {
                                            Email = s.IdMedicNavigation.IdUserNavigation.Email
                                        }
                                    },
                                    IdPatientNavigation = new Patient()
                                    {
                                        Cpf = s.IdPatientNavigation.Cpf,
                                        DddPhone = s.IdPatientNavigation.DddPhone,
                                        PhoneNumber = s.IdPatientNavigation.PhoneNumber,
                                        IdUserNavigation = new User()
                                        {
                                            Email = s.IdPatientNavigation.IdUserNavigation.Email
                                        }
                                    },
                                    IdSituationNavigation = new Situation()
                                    {
                                        SituationDescription = s.IdSituationNavigation.SituationDescription
                                    }


                                })
                                .ToList();
            }

            return null;

        }

        public Scheduling SearchByID(int idScheduling)
        {
            return context.Schedulings
                .Select(s => new Scheduling
                {
                    IdScheduling = s.IdScheduling,
                    IdPatientNavigation = new Patient()
                    {
                        PatientName = s.IdPatientNavigation.PatientName,
                    },
                    IdMedicNavigation = new Medic()
                    {
                        MedicName = s.IdMedicNavigation.MedicName,
                        MedicLastname = s.IdMedicNavigation.MedicLastname,
                    },
                    SchedulingDateHour = s.SchedulingDateHour,
                    IdSituationNavigation = new Situation()
                    {
                        SituationDescription = s.IdSituationNavigation.SituationDescription
                    },
                })
                .FirstOrDefault(s => s.IdScheduling == idScheduling);
        }

        public void UpdateURL(int idScheduling, Scheduling updatedScheduling)
        {
            Scheduling searchScheduling = context.Schedulings.Find(idScheduling);

            if (updatedScheduling.IdPatientNavigation.PatientName != null)
            {
                searchScheduling.IdPatientNavigation.PatientName = updatedScheduling.IdPatientNavigation.PatientName;
            }
            if (updatedScheduling.IdMedicNavigation.MedicName != null)
            {
                searchScheduling.IdMedicNavigation.MedicName = updatedScheduling.IdMedicNavigation.MedicName;

            }
            if (updatedScheduling.IdMedicNavigation.MedicLastname != null)
            {
                searchScheduling.IdMedicNavigation.MedicLastname = updatedScheduling.IdMedicNavigation.MedicLastname;

            }
            if (updatedScheduling.SchedulingDateHour != null)
            {
                searchScheduling.SchedulingDateHour = updatedScheduling.SchedulingDateHour;

            }
            if (updatedScheduling.IdSituationNavigation.SituationDescription != null)
            {
                searchScheduling.IdSituationNavigation.SituationDescription = updatedScheduling.IdSituationNavigation.SituationDescription;
            }

            if (updatedScheduling.SchedulingDescription != null)
            {
                searchScheduling.SchedulingDescription = updatedScheduling.SchedulingDescription;
            }

            context.Schedulings.Update(updatedScheduling);

            context.SaveChanges();
        }
    }
}
