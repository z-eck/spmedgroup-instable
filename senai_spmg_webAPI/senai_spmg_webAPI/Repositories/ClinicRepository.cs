using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        readonly SPMGContext context = new();

        public List<Clinic> ReadAll()
        {
            return context.Clinics.ToList();
        }

        public Clinic SearchByID(int idClinic)
        {
            return context.Clinics.FirstOrDefault(cl => cl.IdClinic == idClinic);
        }

        public void UpdateURL(int idClinic, Clinic updatedClinic)
        {
            Clinic searchClinic = context.Clinics.Find(idClinic);

            if (updatedClinic.ClinicName != null)
            {
                searchClinic.ClinicName = updatedClinic.ClinicName;
            }

            if (updatedClinic.ClinicAddress != null)
            {
                searchClinic.ClinicAddress = updatedClinic.ClinicAddress;
            }

            if (updatedClinic.Cnpj != null)
            {
                searchClinic.Cnpj = updatedClinic.Cnpj;
            }

            if (updatedClinic.CorporateName != null)
            {
                searchClinic.CorporateName = updatedClinic.CorporateName;
            }

            context.Clinics.Update(searchClinic);

            context.SaveChanges();

        }
    }
}
