using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface IUserTypeRepository
    {
        List<Usertype> ReadAll();

        Usertype SearchByID(int idUserType);

        void Create(Usertype newUserType);

        void UpdateURL(int idUserType, Usertype updatedUserType);

        void Delete(int idUserType);
    }
}
