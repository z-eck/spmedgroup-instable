using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class MedicRepository : IMedicRepository
    {
        readonly SPMGContext context = new();
        public void Create(Medic newMedic)
        {
            context.Medics.Add(newMedic);

            context.SaveChanges();
        }

        public void Delete(int idMedic)
        {
            context.Medics.Remove(SearchByID(idMedic));

            context.SaveChanges();
        }

        public List<Medic> ReadAll()
        {
            return context.Medics
                .Select(m => new Medic
                {
                    IdMedic = m.IdMedic,
                    Crm = m.Crm,
                    MedicName = m.MedicName,
                    MedicLastname = m.MedicLastname,
                    IdSpecialtyNavigation = new Specialty()
                    {
                        SpecialtyName = m.IdSpecialtyNavigation.SpecialtyName
                    },
                    IdClinicNavigation = new Clinic()
                    {
                        ClinicName = m.IdClinicNavigation.ClinicName,
                        Cnpj = m.IdClinicNavigation.Cnpj,
                        CorporateName = m.IdClinicNavigation.CorporateName,
                        ClinicAddress = m.IdClinicNavigation.ClinicAddress
                    },
                })
                .OrderBy(m => m.IdMedic)
                .ToList();
        }

        public Medic SearchByID(int idMedic)
        {
            return context.Medics
                .Select(m => new Medic
                {
                    IdMedic = m.IdMedic,
                    Crm = m.Crm,
                    MedicName = m.MedicName,
                    MedicLastname = m.MedicLastname,
                    IdSpecialtyNavigation = new Specialty()
                    {
                        SpecialtyName = m.IdSpecialtyNavigation.SpecialtyName
                    },
                    IdClinicNavigation = new Clinic()
                    {
                        ClinicName = m.IdClinicNavigation.ClinicName,
                        Cnpj = m.IdClinicNavigation.Cnpj,
                        CorporateName = m.IdClinicNavigation.CorporateName,
                        ClinicAddress = m.IdClinicNavigation.ClinicAddress
                    },
                })
                .FirstOrDefault(m => m.IdMedic == idMedic);
        }

        public void UpdateURL(int idMedic, Medic updatedMedic)
        {
            Medic searchMedic = context.Medics.Find(idMedic);

            if (updatedMedic.MedicName != null)
            {
                searchMedic.MedicName = updatedMedic.MedicName;
            }

            if (updatedMedic.MedicLastname != null)
            {
                searchMedic.MedicLastname = updatedMedic.MedicLastname;
            }

            if (updatedMedic.Crm != null)
            {
                searchMedic.Crm = updatedMedic.Crm;
            }

            context.Medics.Update(searchMedic);

            context.SaveChanges();
        }
    }
}
