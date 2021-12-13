using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Specialty
    {
        public Specialty()
        {
            Medics = new HashSet<Medic>();
        }

        public short IdSpecialty { get; set; }

        [Required(ErrorMessage = "Informe o nome da especialidade.")]
        public string SpecialtyName { get; set; }

        public virtual ICollection<Medic> Medics { get; set; }
    }
}
