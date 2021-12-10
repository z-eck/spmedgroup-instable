using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface ISituationRepository
    {
        List<Situation> ReadAll();

        Situation SearchByID(int idSituation);
    }
}
