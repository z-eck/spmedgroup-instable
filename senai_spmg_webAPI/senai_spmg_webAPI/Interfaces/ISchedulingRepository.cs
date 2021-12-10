using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface ISchedulingRepository
    {
        List<Scheduling> ReadAll();

        List<Scheduling> ReadMine(int idUser);

        Scheduling SearchByID(int idScheduling);

        void Create(Scheduling newScheduling);

        void UpdateURL(int idScheduling, Scheduling updatedScheduling);

        void Delete(int idScheduling);

        void ChangeSituation(int idScheduling, string situation);
    }
}
