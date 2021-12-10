using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface IClinicRepository
    {
        List<Clinic> ReadAll();

        Clinic SearchByID(int idClinic);

        void UpdateURL(int idClinic, Clinic updatedClinic);
    }
}
