using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface IPatientRepository
    {
        List<Patient> ReadAll();

        Patient SearchByID(int idPatient);

        void Create(Patient newPatient);

        void UpdateURL(int idPatient, Patient updatedPatient);

        void Delete(int idPatient);
    }
}
