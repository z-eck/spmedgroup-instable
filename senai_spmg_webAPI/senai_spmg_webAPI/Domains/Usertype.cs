using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Usertype
    {
        public Usertype()
        {
            Users = new HashSet<User>();
        }

        public byte IdUserType { get; set; }


        [Required(ErrorMessage = "Informe o tipo de usuário.")]
        public string UserTypeDescription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
