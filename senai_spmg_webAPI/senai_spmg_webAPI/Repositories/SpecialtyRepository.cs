using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        readonly SPMGContext context = new();

        public void Create(Specialty newSpecialty)
        {
            context.Specialties.Add(newSpecialty);

            context.SaveChanges();
        }

        public void Delete(int idSpecialty)
        {
            context.Specialties.Remove(SearchByID(idSpecialty));

            context.SaveChanges();
        }

        public List<Specialty> ReadAll()
        {
            return context.Specialties.ToList();
        }

        public Specialty SearchByID(int idSpecialty)
        {
            return context.Specialties.FirstOrDefault(sp => sp.IdSpecialty == idSpecialty);
        }

        public void UpdateURL(int idSpecialty, Specialty updatedSpecialty)
        {
            Specialty searchSpecialty = context.Specialties.Find(idSpecialty);

            if (updatedSpecialty.SpecialtyName != null)
            {
                searchSpecialty.SpecialtyName = updatedSpecialty.SpecialtyName;

                context.Specialties.Update(searchSpecialty);

                context.SaveChanges();
            }
        }
    }
}

