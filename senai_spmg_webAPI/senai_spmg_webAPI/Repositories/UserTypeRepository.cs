using senai_spmg_webAPI.Contexts;
using senai_spmg_webAPI.Domains;
using senai_spmg_webAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_spmg_webAPI.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        readonly SPMGContext context = new();
        public void Create(Usertype newUserType)
        {
            context.Usertypes.Add(newUserType);

            context.SaveChanges();
        }

        public void Delete(int idUserType)
        {
            context.Usertypes.Remove(SearchByID(idUserType));

            context.SaveChanges();
        }

        public List<Usertype> ReadAll()
        {
            return context.Usertypes
                .Select(t => new Usertype
                {
                    IdUserType = t.IdUserType,
                    UserTypeDescription = t.UserTypeDescription,
                })
                .ToList();
        }

        public Usertype SearchByID(int idUserType)
        {
            return context.Usertypes
                .Select(t => new Usertype
                {
                    IdUserType = t.IdUserType,
                    UserTypeDescription = t.UserTypeDescription,
                })
                .FirstOrDefault(t => t.IdUserType == idUserType);
        }

        public void UpdateURL(int idUserType, Usertype updatedUserType)
        {
            Usertype searchUserType = context.Usertypes.Find(idUserType);

            if (updatedUserType.UserTypeDescription != null)
            {
                searchUserType.UserTypeDescription = updatedUserType.UserTypeDescription;

                context.Usertypes.Update(searchUserType);

                context.SaveChanges();
            }
        }
    }
}
