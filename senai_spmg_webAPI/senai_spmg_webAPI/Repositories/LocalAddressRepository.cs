using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
    }
}
