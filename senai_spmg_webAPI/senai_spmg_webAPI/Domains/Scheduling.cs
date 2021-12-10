using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmg_webAPI.Domains
{
    public partial class Scheduling
    {
        public int IdScheduling { get; set; }

        [Required(ErrorMessage = "Informe o médico.")]
        public short IdMedic { get; set; }

        [Required(ErrorMessage = "Informe o paciente.")]
        public int IdPatient { get; set; }
        public byte? IdSituation { get; set; }
        public string SchedulingDescription { get; set; }

        [Required(ErrorMessage = "Informe a data e a hora da consulta.")]
        public DateTime? SchedulingDateHour { get; set; }

        public virtual Medic IdMedicNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Situation IdSituationNavigation { get; set; }
    }
}
