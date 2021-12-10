using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Patient
    {
        public Patient()
        {
            Schedulings = new HashSet<Scheduling>();
        }

        public int IdPatient { get; set; }
        public int IdUser { get; set; }
        public int? IdAddress { get; set; }

        [Required(ErrorMessage = "Informe o nome do paciente.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento do paciente.")]
        public DateTime? BirthDate { get; set; }
        public string DddPhone { get; set; }
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Informe o RG do paciente.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Informe o cpf do paciente.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe o número da residência do paciente.")]
        public string AddressNumber { get; set; }

        public virtual Localaddress IdAddressNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Scheduling> Schedulings { get; set; }
    }
}
