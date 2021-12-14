using Microsoft.AspNetCore.Http;
using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly SPMGContext context = new();
        public void Create(User newUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idUser)
        {
            throw new NotImplementedException();
        }

        public User Login(string email, string passwd)
        {
            throw new NotImplementedException();
        }

        public List<User> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void SaveProfileDB(IFormFile photo, int idUser)
        {
            throw new NotImplementedException();
        }

        public void SaveProfilelDir(IFormFile photo, int idUser)
        {
            throw new NotImplementedException();
        }

        public User SearchByID(int idUser)
        {
            throw new NotImplementedException();
        }

        public string SearchProfileDB(int idUser)
        {
            throw new NotImplementedException();
        }

        public string SearchProfileDir(int idUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateURL(int idUser, User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
