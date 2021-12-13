using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Medic
    {
        public Medic()
        {
            Schedulings = new HashSet<Scheduling>();
        }

        public short IdMedic { get; set; }
        public int IdUser { get; set; }
        public short? IdSpecialty { get; set; }
        public byte? IdClinic { get; set; }

        [Required(ErrorMessage = "Informe o nome do médico.")]
        public string MedicName { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome do médico.")]
        public string MedicLastname { get; set; }

        [Required(ErrorMessage = "Informe o CRM do médico.")]
        public string Crm { get; set; }

        public virtual Clinic IdClinicNavigation { get; set; }
        public virtual Specialty IdSpecialtyNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Scheduling> Schedulings { get; set; }
    }
}
