using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmg_webAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        readonly SPMGContext context = new();
        public void Create(Patient newPatient)
        {
            context.Patients.Add(newPatient);

            context.SaveChanges();
        }

        public void Delete(int idPatient)
        {
            context.Patients.Remove(SearchByID(idPatient));

            context.SaveChanges();
        }

        public List<Patient> ReadAll()
        {
            return context.Patients
                .Select(p => new Patient
                {
                    IdPatient = p.IdPatient,
                    PatientName = p.PatientName,
                    BirthDate = p.BirthDate,
                    DddPhone = p.DddPhone,
                    PhoneNumber = p.PhoneNumber,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    IdAddressNavigation = new Localaddress()
                    {
                        Cep = p.IdAddressNavigation.Cep,
                        Fu = p.IdAddressNavigation.Fu,
                        City = p.IdAddressNavigation.City,
                        District = p.IdAddressNavigation.District,
                        Place = p.IdAddressNavigation.Place,
                        AddressName = p.IdAddressNavigation.AddressName,
                    },
                    AddressNumber = p.AddressNumber,
                })
                .OrderBy(p => p.PatientName)
                .ToList();
        }

        public Patient SearchByID(int idPatient)
        {
            return context.Patients
                .Select(p => new Patient
                {
                    IdPatient = p.IdPatient,
                    PatientName = p.PatientName,
                    BirthDate = p.BirthDate,
                    DddPhone = p.DddPhone,
                    PhoneNumber = p.PhoneNumber,
                    Rg = p.Rg,
                    Cpf = p.Cpf,
                    IdAddressNavigation = new Localaddress()
                    {
                        Cep = p.IdAddressNavigation.Cep,
                        Fu = p.IdAddressNavigation.Fu,
                        City = p.IdAddressNavigation.City,
                        District = p.IdAddressNavigation.District,
                        Place = p.IdAddressNavigation.Place,
                        AddressName = p.IdAddressNavigation.AddressName,
                    },
                    AddressNumber = p.AddressNumber,
                })
                .FirstOrDefault(p => p.IdPatient == idPatient);
        }

        public void UpdateURL(int idPatient, Patient updatedPatient)
        {
            Patient searchPatient = context.Patients.Find(idPatient);

            if (updatedPatient.PatientName != null)
            {
                searchPatient.PatientName = updatedPatient.PatientName;
            }

            if (updatedPatient.BirthDate != null)
            {
                searchPatient.BirthDate = updatedPatient.BirthDate;
            }

            if (updatedPatient.Cpf != null)
            {            
                searchPatient.Cpf = updatedPatient.Cpf;              
            }

            if (updatedPatient.IdAddress != null)
            {
                searchPatient.IdAddress = updatedPatient.IdAddress;
            }

            if (updatedPatient.PhoneNumber != null)
            {
                searchPatient.PhoneNumber = updatedPatient.PhoneNumber;
            }

            if (updatedPatient.DddPhone != null)
            {
                searchPatient.DddPhone = updatedPatient.DddPhone;
            }

            if (updatedPatient.Rg != null)
            {
                searchPatient.Rg = updatedPatient.Rg;
            }

            if (updatedPatient.AddressNumber != null)
            {
                searchPatient.AddressNumber = updatedPatient.AddressNumber;
            }

            context.Patients.Update(searchPatient);

            context.SaveChanges();
        }
    }
}
