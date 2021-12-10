using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface IMedicRepository
    {
        List<Medic> ReadAll();

        Medic SearchByID(int idMedic);

        void Create(Medic newMedic);

        void UpdateURL(int idMedic, Medic updatedMedic);

        void Delete(int idMedic);
    }
}
