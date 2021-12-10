using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class User
    {
        public int IdUser { get; set; }
        public byte? IdUserType { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "O campo senha deve ter no máximo 16 e no mínimo 6 caracteres.")]
        public string Passwd { get; set; }

        public virtual Usertype IdUserTypeNavigation { get; set; }
        public virtual Medic Medic { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Userimg Userimg { get; set; }
    }
}
