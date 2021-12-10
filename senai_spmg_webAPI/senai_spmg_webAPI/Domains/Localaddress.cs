using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Localaddress
    {
        public Localaddress()
        {
            Patients = new HashSet<Patient>();
        }

        public int IdAddress { get; set; }
        public string Place { get; set; }

        [Required(ErrorMessage = "Informe o nome da rua.")]
        public string AddressName { get; set; }
        public string District { get; set; }

        [Required(ErrorMessage = "Informe a cidade.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Informe a Unidade Federativa (ex.: A UF de São Paulo é 'SP'.")]
        public string Fu { get; set; }

        [Required(ErrorMessage = "Informe o CEP.")]
        public string Cep { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
