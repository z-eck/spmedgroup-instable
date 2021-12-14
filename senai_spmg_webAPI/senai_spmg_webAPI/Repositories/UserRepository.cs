using Microsoft.AspNetCore.Http;
using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly SPMGContext context = new();
        public void Create(User newUser)
        {
            context.Users.Add(newUser);
  
            context.SaveChanges();
        }

        public void Delete(int idUser)
        {
            context.Users.Remove(SearchByID(idUser));

            context.SaveChanges();
        }

        public User Login(string email, string passwd)
        {
            return context.Users.FirstOrDefault(u => u.Email == email && u.Passwd == passwd);
        }

        public List<User> ReadAll()
        {
            return context.Users
                .Select(u => new User()
                {
                    IdUser = u.IdUser,
                    Email = u.Email,
                    IdUserType = u.IdUserType,

                    IdUserTypeNavigation = new Usertype()
                    {
                        IdUserType = u.IdUserTypeNavigation.IdUserType,
                        UserTypeDescription = u.IdUserTypeNavigation.UserTypeDescription
                    }
                })
                .ToList();
        }

        public void SaveProfileDB(IFormFile photo, int idUser)
        {
            Userimg userImage = new Userimg();

            using (var ms = new MemoryStream())
            {
                photo.CopyTo(ms);
                userImage.BinaryNumber = ms.ToArray();
                userImage.ArchiveName = photo.FileName;
                userImage.MimeType = photo.FileName.Split('.').Last();
                userImage.IdUser = idUser;
            }

            Userimg existingphoto = new Userimg();
            existingphoto = context.Userimgs.FirstOrDefault(ui => ui.IdUser == idUser);

            if (existingphoto != null)
            {
                existingphoto.BinaryNumber = userImage.BinaryNumber;
                existingphoto.ArchiveName = userImage.ArchiveName;
                existingphoto.MimeType = userImage.MimeType;
                existingphoto.IdUser = idUser;

                context.Userimgs.Update(existingphoto);
            }
            else
            {
                context.Userimgs.Add(userImage);
            }

            context.SaveChanges();
        }

        public void SaveProfilelDir(IFormFile photo, int idUser)
        {
            string newName = idUser.ToString() + ".png";

            using (var stream = new FileStream(Path.Combine("profile", newName), FileMode.Create))
            {
                photo.CopyTo(stream);
            }
        }

        public User SearchByID(int idUser)
        {
            return context.Users
                .Select(u => new User()
                {
                    IdUser = u.IdUser,
                    Email = u.Email,
                    IdUserType = u.IdUserType,

                    IdUserTypeNavigation = new Usertype()
                    {
                        IdUserType = u.IdUserTypeNavigation.IdUserType,
                        UserTypeDescription = u.IdUserTypeNavigation.UserTypeDescription
                    }
                })
                .FirstOrDefault(u => u.IdUser == idUser);
        }

        public string SearchProfileDB(int idUser)
        {
            Userimg userImage = new Userimg();

            userImage = context.Userimgs.FirstOrDefault(ui => ui.IdUser == idUser);

            if (userImage != null)
            {
                return Convert.ToBase64String(userImage.BinaryNumber);
            }

            return null;
        }

        public string SearchProfileDir(int idUser)
        {
            string newName = idUser.ToString() + ".png";
            string path = Path.Combine("Profile", newName);

            if (File.Exists(path))
            {
                byte[] archiveBytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(archiveBytes);
            }

            return null;
        }

        public void UpdateURL(int idUser, User updatedUser)
        {
            User searchUser = context.Users.Find(idUser);

            if (updatedUser.Email != null)
            {
                searchUser.Email = updatedUser.Email;
            }

            if (updatedUser.Passwd != null)
            {
                searchUser.Passwd = updatedUser.Passwd;
            }

            if (updatedUser.IdUserType != null)
            {
                searchUser.IdUserType = updatedUser.IdUserType;
            }

            context.Users.Update(searchUser);

            context.SaveChanges();
        }
    }
}
