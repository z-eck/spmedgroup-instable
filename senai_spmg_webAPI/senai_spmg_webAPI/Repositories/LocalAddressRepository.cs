using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class LocalAddressRepository : ILocalAddressRepository
    {
        readonly SPMGContext context = new();

        public void Create(Localaddress newAddress)
        {
            context.Localaddresses.Add(newAddress);

            context.SaveChanges();
        }

        public void Delete(int idAddress)
        {
            context.Localaddresses.Remove(SearchByID(idAddress));

            context.SaveChanges();
        }

        public List<Localaddress> ReadAll()
        {
            return context.Localaddresses.ToList();
        }

        public Localaddress SearchByID(int idAddress)
        {
            return context.Localaddresses.FirstOrDefault(la => la.IdAddress == idAddress);
        }

        public void UpdateURL(int idAddress, Localaddress updatedAddress)
        {
            Localaddress searchAddress = context.Localaddresses.Find(idAddress);

            if (updatedAddress.AddressName != null)
            {
                searchAddress.AddressName = updatedAddress.AddressName;
            }

            if (updatedAddress.Cep != null)
            {
                searchAddress.Cep = updatedAddress.Cep;
            }

            if (updatedAddress.City != null)
            {
                searchAddress.City = updatedAddress.City;
            }

            if (updatedAddress.District != null)
            {
                searchAddress.District = updatedAddress.District;
            }

            if (updatedAddress.Fu != null)
            {
                searchAddress.Fu = updatedAddress.Fu;
            }

            if (updatedAddress.Place != null)
            {
                searchAddress.Place = updatedAddress.Place;
            }

            context.Localaddresses.Update(updatedAddress);

            context.SaveChanges();
        }
    }
}
