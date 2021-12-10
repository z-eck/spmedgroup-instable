using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface ILocalAddressRepository
    {
        List<Localaddress> ReadAll();

        Localaddress SearchByID(int idAddress);

        void Create(Localaddress newAddress);

        void UpdateURL(int idAddress, Localaddress updatedAddress);

        void Delete(int idAddress);
    }
}
