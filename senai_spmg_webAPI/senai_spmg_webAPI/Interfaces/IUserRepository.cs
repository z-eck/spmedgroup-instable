using Microsoft.AspNetCore.Http;
using senai_spmg_webAPI.Domains;
using System.Collections.Generic;

namespace senai_spmg_webAPI.Interfaces
{
    interface IUserRepository
    {
        List<User> ReadAll();

        User Login(string email, string passwd);

        User SearchByID(int idUser);

        void Create(User newUser);

        void UpdateURL(int idUser, User updatedUser);

        void Delete(int idUser);

        void SaveProfileDB(IFormFile photo, int idUser); // <--
        void SaveProfilelDir(IFormFile photo, int idUser); // <--
        string SearchProfileDB(int idUser);
        string SearchProfileDir(int idUser);
    }
}
