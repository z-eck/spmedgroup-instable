using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface ISpecialtyRepository
    {
        List<Specialty> ReadAll();

        Specialty SearchByID(int idSpecialty);

        void Create(Specialty newSpecialty);

        void UpdateURL(int idSpecialty, Specialty updatedSpecialty);

        void Delete(int idSpecialty);
    }
}
